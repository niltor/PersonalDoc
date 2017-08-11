### API

```bash
cd /var/sourcecodes/WebApi;sudo git checkout .;sudo git pull;cd /var/sourcecodes/WebApi;sudo dotnet restore -r ubuntu.16.04-x64;sudo dotnet publish -c release -r ubuntu.16.04-x64 -o /var/publish/api.msdev.cc;cd /var/publish/api.msdev.cc/;sudo  cp -rf * /var/www/api.msdev.cc
```


### WEB

```bash
cd /var/sourcecodes/WebApp; sudo git checkout .; sudo git pull;cd /var/sourcecodes/WebApp;sudo dotnet restore -r ubuntu.16.04-x64;sudo dotnet publish -c release -r ubuntu.16.04-x64 -o /var/publish/msdev.cc;cd /var/publish/msdev.cc/;sudo  cp -rf * /var/www/msdev.cc
```


### Admin
```bash
cd /var/sourcecodes/WebAdminApp;sudo git checkout .; sudo git pull;cd /var/sourcecodes/WebAdminApp;sudo dotnet restore -r ubuntu.16.04-x64;sudo dotnet publish -c release -r ubuntu.16.04-x64 -o /var/publish/admin.msdev.cc;cd /var/publish/admin.msdev.cc/;sudo  cp -rf * /var/www/admin.msdev.cc
```