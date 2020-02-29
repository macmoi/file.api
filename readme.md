# File API

This is the File.Api project. It is a small REST API that implements some DDD patterns. This API simply takes care of registering some users and adding attachments to each of them. Limited to demonstration purposes only. We do not have authorization layers or validation of file types.

This API simply takes care of registering some users and adding attachments to each of them. This means that a User can have mutiple attachments to it, and Attachments can have only one user. (One to many from User to Attachment)
Limited to demonstration purposes only. We do not have authorization layers or validation of file types.

------------------------------------------
## Directory Structure

```bash
.
├── file.Api
│   ├── Controllers
│   ├── Extensions
│   ├── Mappers
│   ├── Properties
│   ├── Resources
│   └── Utils
├── file.api.sln
├── file.Core
│   ├── Models
│   ├── Repositories
│   └── Services
├── file.Persistance
│   ├── Migrations
│   └── Repositories
└── file.Services
```
---------------------------
## Deploy API

This project use [MySQL](https://www.sitepoint.com/how-to-install-mysql/) as DBMS and [NETCore 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) so in order tu run this api on your machine, is necessary to have this tools installed.

Once you have all installed we need a couple more things to do.

### **Installing EFCore tools**

NETCore CLI
```bash
dotnet tool install --global dotnet-ef
```
With Visual Studio installed you already have this tools on your machine. Just be sure that you are running NETCore 3.1
### **Executing migrations**

For more information check official [microsoft documentation](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs).

NETCore CLI
```bash
dotnet ef database update
```
Visual Studio Terminal
```bash
Update-Database
```
### **Running the Api**

Execute the following commands on the root folder of the project (Where the solution file are)

**NETCore CLI**

```bash
> dotnet restore #if you come from frontend word this is similar to npm install
```

```bash
> cd file.Api
> dotnet run
```
For **Visual Studio**, the IDE detects the configuration on sln file and executes the entry project in this case our web api project. To execute the project just click on Run button.

-------------------------------------
## Deploy with Docker

Comming soon...
