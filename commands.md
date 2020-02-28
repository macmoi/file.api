# file.api

Commands used for creation of this web api. By: Moises Piñate 😁️

-----------------------------
## New solution

```bash
dotnet new sln (this creates a new solution file)
```
-----------------------------
## Creating the projects

Each command creates a new project that represents a abstraction layer of reponsibilities
for the api application

```bash
dotnet new webapi -o file.Api
dotnet new classlib -o file.Core
dotnet new classlib -o file.Services
dotnet new classlib -o file.Persistance
```

-----------------------------
## Adding projects to solution

This commnand adds each created project to a solution file

```bash
dotnet sln add file.Api/file.Api.csproj file.Core/file.Core.csproj file.Services/file.Services.csproj file.Persistance/file.Persistance.csproj
```

------------------------------
## Referencing projects

Here is where specify what projects needs references from other projects. For instance, `file.Api` project needs references of `file.Services` and `file.Core` projects, in order to have access to their classes and interfaces.

```bash
dotnet add file.Api/file.Api.csproj reference file.Core/file.Core.csproj file.Services/file.Services.csproj
dotnet add file.Persistance/file.Persistance.csproj reference file.Core/file.Core.csproj
dotnet add file.Services/file.Services.csproj reference file.Core/file.Core.csproj
dotnet add file.Api/file.Api.csproj reference file.Core/file.Core.csproj file.Services/file.Services.csproj file.Persistance/file.Persistance.csproj
```
-------------------------------
## Configuring EF Core 

EF Core is necessary to access to our database, in our case we're going to use MySQL Server as DBMS but any other DBMS can be used (i.e: SQL Server, PostgreSQL, MongoDB, Oracle...). To achieve this we need to add the dependencies to our project, and also we need to add EFCore to our system because NETCore dosen't come with the ORM by default.

```bash
dotnet tool install --global dotnet-ef
```

Now we can execute the `dotnet ef` command on the CLI

Next step to do is add dependencies on the Persistance project. To achieve that we execute the following commands inside the root folder of the project (the same folder where solution file are):
```bash
dotnet add file.Persistance/file.Persistance.csproj package Microsoft.EntityFrameworkCore
dotnet add file.Persistance/file.Persistance.csproj package Microsoft.EntityFrameworkCore.Design
dotnet add file.Persistance/file.Persistance.csproj package Pomelo.EntityFrameworkCore.MySql --version 3.1.1

dotnet add file.Api/file.Api.csproj package Microsoft.EntityFrameworkCore
dotnet add file.Api/file.Api.csproj package Microsoft.EntityFrameworkCore.Design
dotnet add file.Api/file.Api.csproj package Pomelo.EntityFrameworkCore.MySql --version 3.1.1
```
As you can see, we are using the [Pomelo.EntityFrameworkCore.MySql]() Dependencies, the reason is because Oracle haven't updated their [official driver](https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html) for MySQL to the last version of NETCore. Pomelo is an Open Source driver developed by the community to bring support for .NETCore 3.X

-------------------------
## Adding initial migrations

For create DB and add the initial migrations we execute this command
```bash
dotnet ef --startup-project file.Api/file.Api.csproj migrations add InitialMigration -p file.Persistance/file.Persistance.csproj -v
```
The `--startup-project` flag indicates that `file.Api` will be the entry project for our solution and with the `-p` flag we are indicating that all the migrations will be added on the `file.Persistance` project.

-----------------------
## Executing migrations

Once initial migrations are generated, we need to apply them to our database, for that execute the next command on CLI
```bash
dotnet ef --startup-project file.Api/file.Api.csproj database update
```