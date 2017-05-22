

### api.msdev.cc
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


    [Install]
    WantedBy=multi-user.target

### msdev.cc
SPA 

### admin.msdev.cc

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


    [Install]
    WantedBy=multi-user.target