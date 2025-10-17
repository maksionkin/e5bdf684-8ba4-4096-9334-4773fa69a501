# Prereconditions
- install dotnet 90. SDK


# how to run
clone the repo and run `dotnet run` to build and run the project.

it will print the port where the api is running.

then go to `http://localhost:{port}/swagger/index.html` to see the swagger ui and test the api.


# Assumptions
- sample data has `assetInfoType` property that I use for groupping and distiguishing the assets to show historical data.

# Design
- EF Core InMemory provider is used and the data is seeded when it's first requested.

# Historical Balance System
- storage depends how the original data is stored:
	-- in SQL Server it coulod be a meterialized view.
	-- Azure Data Explorer (Kusto) could be use w/o any additional storage as such queries are efficient enough to provide historical data. 
