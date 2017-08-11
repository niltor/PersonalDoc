### 安装nginx
sudo apt-get -y install nginx;
### 安装dotnet
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list' \
;sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893 \
;sudo apt-get update
;sudo apt-get -y install dotnet-dev-1.0.4;

### 安装nodejs npm angular/cli
curl -sL https://deb.nodesource.com/setup_6.x | sudo -E bash -;
sudo apt-get install -y nodejs;
sudo apt-get install -y build-essential;
npm install -g @angular/cli;

### 安装letsencrypt
sudo apt-get install software-properties-common
sudo add-apt-repository ppa:certbot/certbot
sudo apt-get update
sudo apt-get install python-certbot-nginx
sudo certbot --nginx

### 获取证书  Can't auto now! 先解析域名再验证
##### certbot certonly --standalone -d api.msdev.cc;
##### certbot certonly --standalone -d msdev.cc -d www.msdev.cc;

### 写入nginx配置
cd /etc/nginx/sites-available/;
sudo cat > api.msdev.cc <<EOF

    server {
            listen 80;
            server_name api.msdev.cc;
            return 301 https://\$server_name\$request_uri;
    }
    server {
            server_name api.msdev.cc;
            listen 443 ssl;

            #####ssl_certificate /etc/letsencrypt/live/api.msdev.cc/fullchain.pem;
            #####ssl_certificate_key /etc/letsencrypt/live/api.msdev.cc/privkey.pem;
            #####ssl_trusted_certificate /etc/letsencrypt/live/api.msdev.cc/chain.pem;

            location / {
                    server_tokens off;
                    proxy_pass http://localhost:10916;
                    proxy_http_version 1.1;
                    proxy_set_header Upgrade \$http_upgrade;
                    proxy_set_header Connection keep-alive;
                    proxy_set_header Host \$host;
                    proxy_cache_bypass \$http_upgrade;
            }

    }
EOF

sudo cat > admin.msdev.cc <<EOF

    server {
            listen 80;
            server_name admin.msdev.cc;
            
            location /task/runtask {
                proxy_pass http://localhost:20916/task/runtask;
                proxy_http_version 1.1;
                proxy_set_header Upgrade \$http_upgrade;
                proxy_set_header Connection "upgrade";
                proxy_set_header Host \$host;
            }

            location / {
                server_tokens off;
                proxy_pass http://localhost:20916;
                proxy_http_version 1.1;
                proxy_set_header Upgrade \$http_upgrade;
                proxy_set_header Connection keep-alive;
                proxy_set_header Host \$host;
                proxy_cache_bypass \$http_upgrade;
            }
    }
EOF

sudo cat > msdev.cc <<EOF

    server {
            listen 80;
            server_name  msdev.cc www.msdev.cc;
            return 301 https://$server_name$request_uri;
    }

    server {
        listen 443 ssl;
        server_name www.msdev.cc msdev.cc;

        ssl_certificate /etc/letsencrypt/live/msdev.cc/fullchain.pem;
        ssl_certificate_key /etc/letsencrypt/live/msdev.cc/privkey.pem;
        ssl_trusted_certificate /etc/letsencrypt/live/msdev.cc/chain.pem;


        location / {
            server_tokens off;
            proxy_pass http://localhost:5000;
            proxy_http_version 1.1;
            proxy_set_header Upgrade $http_upgrade;
            proxy_set_header Connection keep-alive;
            proxy_set_header Host $host;
            proxy_cache_bypass $http_upgrade;
        }
    }

EOF

### 建立nginx软链接
cd /etc/nginx/sites-enable;
sudo ln -s /etc/nginx/sites-available/api.msdev.cc;
sudo ln -s /etc/nginx/sites-available/admin.msdev.cc;
sudo ln -s /etc/nginx/sites-available/msdev.cc;

sudo nginx -s reload

### 初始化相关目录 
#### 代码目录
sudo mkdir /var/sourcecodes;
cd /var/sourcecodes;
sudo git clone https://github.com/MSDevTeam/WebApi;
sudo git clone https://github.com/MSDevTeam/WebAdmin;
sudo git clone https://github.com/MSDevTeam/WebApp;

#### 发布目录
sudo mkdir -p /var/publish/api.msdev.cc;
sudo mkdir -p /var/publish/admin.msdev.cc;
sudo mkdir -p /var/publish/msdev.cc;
#### 运行目录
sudo mkdir -p /var/www/api.msdev.cc;
sudo mkdir -p /var/www/admin.msdev.cc;
sudo mkdir -p /var/www/msdev.cc;


### 设置服务启动
cd /etc/systemd/system/;

sudo cat > api.msdev.cc.service <<EOF

    [Unit]
    Description= api.msdev.cc.server

    [Service]
    WorkingDirectory=/var/www/api.msdev.cc
    ExecStart=/usr/bin/dotnet /var/www/api.msdev.cc/MSDev.WebApi.dll
    Restart=always
    RestartSec=10
    SyslogIdentifier=dotnet-api
    User=www-data
    Environment=ASPNETCORE_ENVIRONMENT=Production
    Environment=ASPNETCORE_URLS=http://localhost:10916 

    [Install]
    WantedBy=multi-user.target
EOF

sudo cat > admin.msdev.cc.service <<EOF

    [Unit]
    Description= admin.msdev.cc

    [Service]
    WorkingDirectory=/var/www/admin.msdev.cc
    ExecStart=/usr/bin/dotnet /var/www/admin.msdev.cc/WebAdmin.dll
    Restart=always
    RestartSec=10
    SyslogIdentifier=dotnet-admin
    User=www-data
    Environment=ASPNETCORE_ENVIRONMENT=Production
    Environment=ASPNETCORE_URLS=http://localhost:20916 

    [Install]
    WantedBy=multi-user.target
EOF

sudo cat > msdev.cc.service <<EOF
[Unit]
    Description= msdev.cc

    [Service]
    WorkingDirectory=/var/www/msdev.cc
    ExecStart=/usr/bin/dotnet /var/www/msdev.cc/WebApp.dll
    Restart=always
    RestartSec=10
    SyslogIdentifier=dotnet-msdev
    User=www-data
    Environment=ASPNETCORE_ENVIRONMENT=Production
    Environment=ASPNETCORE_URLS=http://localhost:5000

    [Install]
    WantedBy=multi-user.target
EOF

### 建立软链接
systemctl enable api.msdev.cc.service;
systemctl enable admin.msdev.cc.service;
systemctl enable msdev.cc.service;


### 启动服务
systemctl start api.msdev.cc.service;
systemctl start admin.msdev.cc.service;
systemctl start msdev.cc.service;


