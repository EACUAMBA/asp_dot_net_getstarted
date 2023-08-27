* Learning Razor Pages

*** Used commands
```bash
dotnet new webapp -o RazorPagesMovie
#The dotnet new command creates a new Razor Pages project in the RazorPagesMovie folder.
```

```bash
code -r RazorPagesMovie
#The code command opens the RazorPagesMovie folder in the current instance of Visual Studio Code.
```

```bash
dotnet dev-certs https --trust
#Trusting the HTTPS development certificate
```

To run in VSCode use **F5** only.

```bash
#Add NuGet packages and EF tools
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
The preceding commands add:
The command-line interface (CLI) tools for EF Core
The aspnet-codegenerator scaffolding tool.
Design time tools for EF Core
The EF Core SQLite provider, which installs the EF Core package as a dependency.
Packages needed for scaffolding: Microsoft.VisualStudio.Web.CodeGeneration.Design and Microsoft.EntityFrameworkCore.SqlServer.

```bash
dotnet aspnet-codegenerator razorpage -m Movie -dc RazorPagesMovie.Data.RazorPagesMovieContext -udl -outDir Pages/Movies --referenceScriptLibraries --databaseProvider sqlite
```
The following table details the ASP.NET Core code generator options.

Option	Description
-m	The name of the model.
-dc	The DbContext class to use including namespace.
-udl	Use the default layout.
-outDir	The relative output folder path to create the views.
--referenceScriptLibraries	Adds _ValidationScriptsPartial to Edit and Create pages

```bash
#Use the -h option to get help on the dotnet aspnet-codegenerator razorpage command:
dotnet aspnet-codegenerator razorpage -h
```

```bash
#Create the initial database schema using EF's migration feature
dotnet ef migrations add InitialCreate
#The migrations command generates code to create the initial database schema. The schema is based on the model specified in DbContext. The InitialCreate argument is used to name the migrations. Any name can be used, but by convention a name is selected that describes the migration.

dotnet ef database update
#The update command runs the Up method in migrations that have not been applied. In this case, update runs the Up method in the Migrations/<time-stamp>_InitialCreate.cs file, which creates the database.
```