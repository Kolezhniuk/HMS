# HandMadeShop

# This is repo to implement CQRS principle
# Thi was implemented with 
- Asp Core 3.1
- Web.API
- FluentValidation
- Autofac
- Serilog
- EF core
- Asp Core Identity

# Database -  RavenDB NoSql 

# Logs could be watched on Kibana

Hand Made Shop
** Possibly deprecated
 * Add migration `dotnet ef migrations add initial  --project="HandmadeShop.Domain" --startup-project="HandMadeShop.Api"
`
 * Update database `dotnet ef database update --project="HandmadeShop.Domain" --startup-project="HandMadeShop.Api"
`
 * Run kibana & elasctic search
    - run infrastructure `docker-compose up -d` 
    - watch all containers - `docker container ls -a`
    - delete container - `docker rm {container_name}`
    - verify ES is up -  http://localhost:9200 
    - go to Kibana is up -  http://localhost:5601 
    - stop all infrastructure components `docker-compose stop`
    - remove all infrastructure  containers components `docker-compose rm -f`
    
* Kafka:
    - https://github.com/TribalScale/kafka-waffle-stack
    
* Notes
    - community license of Raven Db | https://ravendb.net/license/request/community
        
