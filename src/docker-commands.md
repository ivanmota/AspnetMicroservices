# Docker Commands

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
