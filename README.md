


## Database
### SQL Server
```shell
docker pull mcr.microsoft.com/mssql/server
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

Note: for Arm processors (Mac M1) use
```shell
docker pull mcr.microsoft.com/azure-sql-edge
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge
```

### EF Tools
```shell
dotnet tool install --global dotnet-ef
```

### Migrations

```shell
 dotnet ef migrations add AddProducts 
 dotnet ef database update AddProducts
```