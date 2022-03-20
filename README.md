<<<<<<< HEAD
## Installation
### Minimum System Requirements
- Have Node >v16
- Have ASP .NET 6

### Steps
1. Run `npm install` in /LivingLab.Web to install dependencies
2. Install ef tools if they aren't already present with `dotnet tool install --global dotnet-ef`
3. Run `dotnet ef migrations add CreateInitialDB -s LivingLab.Web -p LivingLab.Infrastructure` to create the initial DB
4. Run `dotnet ef database update -s LivingLab.Web -p LivingLab.Infrastructure` to populate the DB
5. Run project with the commands in the 'Running' section
=======
Refer to WORKFLOW.md for instructions on the development flow.

## Development Workflow
```master```: Only codes that are ready to deploy will be merged here
<br>
```dev```: This is where completed features are being merged

## Getting started
- Download .NET Core 6.0
- Have Node >v 16
- Run `npm install` 

## Running
- `cd LivingLab.Web && npm run dev`
- Then, in a separate window: `dotnet watch --project LivingLab.Web`
>>>>>>> ec72931af7e28d980af5936861aa7cac775d2555

## Running the project
1. Run `npm run dev` in /LivingLab.Web
2. Then, in a separate terminal, run `dotnet watch --project LivingLab.Web` from the root folder 


## Updates to DB 
### Migrations
`dotnet ef migrations add CreateInitialDB -s LivingLab.Web -p LivingLab.Infrastructure`

### Populating / Update Values
`dotnet ef database update -s LivingLab.Web -p LivingLab.Infrastructure`

## Structure
Items that belongs to each layer:
### Core/Domain Layer (LivingLab.Core)
- Entities (business model classes that are persisted)
- Aggregates (groups of entities)
- Interfaces
- Domain Services
- Specifications
- Custom Exceptions and Guard Clauses
- Domain Events and Handlers

### Infrastructure Layer (LivingLab.Infrastructure)
- EF Core types (DbContext, Migration)
- Data access implementation types (Repositories)
- Infrastructure-specific services (for example, FileLogger or SmtpNotifier)

### Presentation Layer (LivingLab.Web)
- View Models
- Api Models
- Binding Models
- Controllers
- Api Controllers
- Views
- Razor Pages
- Razor Components
- Identity
- Authorization
- Swagger 

### References
- [Common Web Application Architectures](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
- [Clean Architecture with .NET and .NET Core](https://medium.com/dotnet-hub/clean-architecture-with-dotnet-and-dotnet-core-aspnetcore-overview-introduction-getting-started-ec922e53bb97#:~:text=With%20Clean%20Architecture%2C%20the%20Domain,different%20kinds%20of%20business%20logic.)
- [Github Repo: Clean Architecture by Ardalis (mostly reference from here)](https://github.com/ardalis/CleanArchitecture)
- [Github Repo: Onion Architecture by Amitpnk](https://github.com/Amitpnk/Onion-architecture-ASP.NET-Core)
- [Github Repo: Clean Architecture by blazorhero](https://github.com/blazorhero/CleanArchitecture)

## FAQ
### Tailwind
An npm script has been set up with the appropriate calls to the tailwindcli (see `package.json`). Newer versions of tailwind operate in JIT mode. The tl;dr here is your css (`webroot/css/index.css`) needs to be *compiled* before it can be *included*. 

It's output will be stored at `webroot/dist/site.css`, where it will be referenced by the main layout file (`Views/Shared/_Layout.cshtml`).

#### dev
Running `npm run dev` will start tailwindcli in "watch" mode. Any changes you make will automatically be reflected.

#### prod
Running `npm run prod` will start tailwindcli in build mode. In addition to compiling your `index.css`, the resulting output will be minified as well.

### Nullable warnings
It's "safe" to ignore warnings on startup about nullables. These are scaffolded from a template. Feel free to correct them. See https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references.


#### Run migrations
- `dotnet ef database update -s LivingLab.Web -p LivingLab.Infrastructure`
Alternatively, run the web app and let dotnet run migrations automatically. If you encounter an exception page, click on "Run migrations" and refresh.

#### Clean state
<<<<<<< HEAD
- Remove `livinglab.sqlite`, rerun migrations.
=======
Remove `livinglab.sqlite`, rerun migrations.

## Github ID
### P1-01 Student ID & Name & Github ID
- 2002437 Han Yi hanyi97
- 2002362 Jia Jia jiajiatan
- 2002288 Mary Michelle mmichelle1
- 2001868 Yong Zheng PixlRainbow
### P1-02 Student ID & Name & Github ID
- 2000522 Chen Dong Don-Whis
- 2002230 Joey Chua 170joeychua
- 2000990 Lee Wei Jie Guthixo
- 2001631 Hong Ying HongYing222
>>>>>>> ec72931af7e28d980af5936861aa7cac775d2555
---

Credits: Thanks Percy for setting up the MVC skeleton + Tailwind integration.
