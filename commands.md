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

EF Core is necessary to access to our database, in our case we're going to use MySQL Server as DBMS but any other DBMS can be used (i.e: SQL Server, PostgreSQL, MongoDB, Oracle...). To archive this we need to add the dependencies to our project, and also add EFCore to our system because EFCore dosen't come as default with NETCore framework anymore.

```bash
dotnet tool install --global dotnet-ef
```

Now we can execute the `dotnet ef` command on the CLI