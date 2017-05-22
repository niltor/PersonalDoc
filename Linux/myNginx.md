### api.msdev.cc
server {
        listen 80;
        server_name api.msdev.cc;
        return 301 https://$server_name$request_uri;
}
server {
        server_name api.msdev.cc;
        listen 443 ssl;

        ssl_certificate /etc/letsencrypt/live/api.msdev.cc/fullchain.pem;
        ssl_certificate_key /etc/letsencrypt/live/api.msdev.cc/privkey.pem;
        ssl_trusted_certificate /etc/letsencrypt/live/api.msdev.cc/chain.pem;

        location / {
                server_tokens off;
                proxy_pass http://localhost:10916;
                proxy_http_version 1.1;
                proxy_set_header Upgrade $http_upgrade;
                proxy_set_header Connection keep-alive;
                proxy_set_header Host $host;
                proxy_cache_bypass $http_upgrade;
        }

}

### admin.msdev.cc
server {
        listen 80;
        server_name admin.msdev.cc;
        
        location / {
                server_tokens off;
                proxy_pass http://localhost:20916;
                proxy_http_version 1.1;
                proxy_set_header Upgrade $http_upgrade;
                proxy_set_header Connection keep-alive;
                proxy_set_header Host $host;
                proxy_cache_bypass $http_upgrade;
        }
}

### msdev.cc
server {
        listen 80;
        server_name  msdev.cc www.msdev.cc;
        return 301 https://$server_name$request_uri;
}

server {
    listen 443 ssl;
    server_name www.msdev.cc msdev.cc;
    root /var/www/msdev.cc;
    index index.html;

    ssl_certificate /etc/letsencrypt/live/msdev.cc/fullchain.pem;
    ssl_certificate_key /etc/letsencrypt/live/msdev.cc/privkey.pem;
    ssl_trusted_certificate /etc/letsencrypt/live/msdev.cc/chain.pem;


    location / {
        server_tokens off;
        try_files $uri $uri /index.html;
    }
}
