# CleanArchitectureBaseTemplate
Personal Clean Architecture template for monolithic .NET 10 backends, based on the structure of `AuthServer`.

## Usage

Install the template once (from this repo's root):

```bash
dotnet new install .
```

Create a new solution (the name replaces `CleanArchitecture` in namespaces, projects, folders and files):

```bash
dotnet new cleanarch -n Acme.Shop
# optional ports for launchSettings:
dotnet new cleanarch -n Acme.Shop --httpPort 5200 --httpsPort 7200
```

Update / remove: `dotnet new install . ` again after changes, `dotnet new uninstall <path-to-this-repo>`.

## Structure

```
Backend/
  CleanArchitecture.API              Controllers, HTTP models, exception handler, Swagger, Program.cs
  CleanArchitecture.Application      Services, DTOs, repository/service abstractions, app exceptions, resx messages
  CleanArchitecture.Domain           Entities, value objects, domain exceptions
  CleanArchitecture.Infrastructure   EF Core (SQL Server) DbContext, configurations, repositories
```

Dependencies: `API -> Application, Infrastructure` · `Infrastructure -> Application, Domain` · `Application -> Domain`.

Each layer exposes an `Add<Layer>Module()` extension that `Program.cs` composes.

The `Sample` feature (Domain/Application/Infrastructure/API) is a minimal end-to-end example; replace it with the real domain.

## Error handling

Every expected error derives from `AppException` (Domain), which carries a transport-agnostic `ErrorKind`
(`Validation`, `NotFound`, `Conflict`, `Unauthorized`, `Forbidden`) and a stable `Code` for clients:

```csharp
public class OrderNotFoundException(string message)
    : AppException(ErrorKind.NotFound, "order.not_found", message);
```

`AppExceptionHandler` is the only place mapping `ErrorKind` to HTTP status, so adding exceptions never touches it
(only a new `ErrorKind` does). `DomainException` is a `Validation` error. Anything that is not an `AppException`
returns a generic 500 and is logged, without leaking details.

Design note: the HTTP status is deliberately not on the exception, to keep Domain/Application free of HTTP concerns.

## After creating a solution

1. Set the connection string in `appsettings.Development.json`.
2. Create the first migration:
   ```bash
   dotnet ef migrations add InitialCreate -p <Name>.Infrastructure -s <Name>.API -o Database/App/Migrations
   dotnet ef database update -p <Name>.Infrastructure -s <Name>.API
   ```
3. `dotnet run --project <Name>.API` and open `/swagger`.

Package versions are centralized in `Backend/Directory.Packages.props`; shared compiler settings in `Backend/Directory.Build.props`.
