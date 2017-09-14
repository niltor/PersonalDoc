

### proxy.conf
        proxy_redirect                  off;
        proxy_set_header                Host                    $host;
        proxy_set_header                X-Real-IP               $remote_addr;
        proxy_set_header                X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header    X-Forwarded-Proto $scheme;
        client_max_body_size    10m;
        client_body_buffer_size 128k;
        proxy_connect_timeout   90;
        proxy_send_timeout              90;
        proxy_read_timeout              90;
        proxy_buffers                   32 4k;




### admin.msdev.cc
 server {
        listen 80;
        server_name admin.msdev.cc;
        return 301 https://$host$request_uri;
}
server{
        listen 443 ssl;
        server_name admin.msdev.cc;
        ssl_certificate /etc/letsencrypt/live/admin.msdev.cc/fullchain.pem;
        ssl_certificate_key /etc/letsencrypt/live/admin.msdev.cc/privkey.pem;
        ssl_trusted_certificate /etc/letsencrypt/live/admin.msdev.cc/chain.pem;

        location /task/runtask {
                proxy_pass http://localhost:20916/task/runtask;
                proxy_http_version 1.1;
                proxy_set_header Upgrade \$http_upgrade;
                proxy_set_header Connection "upgrade";
                proxy_set_header Host \$host;
        }

        add_header Strict-Transport-Security "max-age=63072000; includeSubdomains; preload";
        add_header X-Frame-Options DENY;
        add_header X-Content-Type-Options nosniff;

        location / {
                server_tokens off;
                proxy_pass http://localhost:20916;
        }
}

### msdev.cc
server {
        listen *:80;
        server_name msdev.cc www.msdev.cc;
        return 301 https://$host$request_uri;
}

server {
    listen 443 ssl;
    server_name www.msdev.cc msdev.cc;

    ssl_certificate /etc/letsencrypt/live/msdev.cc/fullchain.pem;
    ssl_certificate_key /etc/letsencrypt/live/msdev.cc/privkey.pem;
    ssl_trusted_certificate /etc/letsencrypt/live/msdev.cc/chain.pem;

    add_header Strict-Transport-Security "max-age=63072000; includeSubdomains; preload";
    add_header X-Frame-Options DENY;
    add_header X-Content-Type-Options nosniff;

    location / {
        server_tokens off;
        proxy_pass http://localhost:5000;
    }
}
