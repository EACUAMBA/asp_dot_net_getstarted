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

