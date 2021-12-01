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

Start docker containers
```powershell
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```

Stop docker containers
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

Run Redis, defining the port and image name.  
The parameter "-d" means "detach" that the image will run on background
```powershell
docker run -d -p 6379:6379 --name aspnetrun-redis redis
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
