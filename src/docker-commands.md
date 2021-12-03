# Docker Commands

Check running  containers
```powershell
docker ps
```

Check existing images
```powershell
docker images
```

Check existing images - retrieve only images ID
```powershell
docker images -q
```

Start App docker containers
```powershell
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```

Build (new/updated) and start all App containers
```powershell
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up --build
```

Stop App docker containers
```powershell
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
```

Delete images
```powershell
docker rmi $(docker images -q)
```

Install Redis Image
```powershell
docker pull redis
```

Run Redis Containers, defining the port and image name.  
The parameter "-d" means "detach" that the image will run on background
```powershell
docker run -d -p 6379:6379 --name aspnetrun-redis redis
```

Run Redis Containers, when the containers is stopped
```powershell
docker run aspnetrun-redis
```

Stop Redis Containers, when the containers is runnig
```powershell
docker stop aspnetrun-redis
```

Remove Redis Containers, when the containers is stopped
```powershell
docker rm aspnetrun-redis
```


For troubleshooting we can check the logs.  
The parameter "-f" define the image name
```powershell
docker logs -f aspnetrun-redis
```

Open redis container to use redis-cli.  
The parameter "-it" means interactive terminal
```powershell
docker exec -it aspnetrun-redis /bin/bash
redis-cli
```
