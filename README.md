# EF Migrations demo

An example ASP.NET application with EF Migrations following below doc

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

I have used two databases for this app. One is for dev env and another is for prd env. To create and 
update dev database, I have used EF Migrations (add migrations and update database). To create and 
update prd database, I have generated script through EF Migrations and executed in prd database during
the deployment.

## Initial create

For dev env

```
dotnet ef migrations add InitialCreate

dotnet ef database update
```

For prd env

```
dotnet ef migrations script
```

Copy the generated script from terminal and executed in prd database.

## Add student subject

For dev env

```
dotnet ef migrations add AddStudentSubject

dotnet ef database update
```

For prd env

```
dotnet ef migrations script InitialCreate
```

Copy the generated script from terminal and executed in prd database.
