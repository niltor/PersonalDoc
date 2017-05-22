### 安装nginx
sudo apt-get isntall nginx;
### 安装dotnet
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list' \
;sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893 \
;sudo apt-get update

;sudo apt-get install dotnet-dev-1.0.4

### 写入nginx配置



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

cat > api.msdev.cc.service <<EOF

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

cat > admin.msdev.cc.service <<EOF

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

### 建立软链接
systemctl enable api.msdev.cc.service;
systemctl enable admin.msdev.cc.service;

### 启动服务
systemctl start api.msdev.cc.service;
systemctl start admin.msdev.cc.service;

