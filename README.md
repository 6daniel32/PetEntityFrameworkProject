# PetEntityFrameworkProject
Learning Entity Framework, configuration and secrets management.

## Managing the configuration
Configuration in ASP.Net Core is handled through the ConfigurationManager class. This class implements both,
IConfigurationBuilder and IConfigurationRoot. IConfigurationBuilder describes how to construct the final configuration representation for your app, and IConfigurationRoot holds the configuration values themselves.

The ConfigurationManager class is capable to deal with multiple configuration sources: XML, JSON, environment
variables, etc. This is achieved by adding configuration providers to the class. These configuration providers
must implement the IConfigurationProvider interface.
<br>
The ConfigurationManager already implements by default the providers of the most frequently used configuration
sources, so you don't typically need to configure that for small pet projects that are only going to be 
executed in your local machine. Here's an example on how you would typically configure the Configuration manager manually.
<br>

> // The configuration manager is available as a property in both the WebApplicationBuilder and the <br>
> // WebApplication instances. <br>
> WebApplicationBuilder builder = WebApplication.CreateBuilder(args); <br>
> // Clear the default providers before adding the new ones. <br>
> builder.Configuration.Sources.Clear(); <br>
> // Add configuration providers, along with the filename that we will use. <br>
> builder.Configuration.AddJsonFile("appsettings.json", optional: true); <br>
> // Variables in the config file are now available in the ConfigurationManager instance <br>
> var isPurchasesEnabled = builder.Configuration["FeatureFlags:PurchasesEnabled"]; <br>

It's important to be aware of the order in which the configuration providers are attached to the 
ConfigurationManager, as the variables of the latest provider will override the variables of all the previous
providers when they have the same name. Example: when you have the XML provider attached to the ConfigurationManager after the JSON provider, if both of them have a variable "PurchasesEnabled", the value
of the variable in the XML provider is going to override the value in the JSON provider.
<br>

## Managing secrets using user secrets
User secrets are used to access the secret credentials of a project in development environments. In 
production environments, other approach would need to be used. If the application is going to be deployed
in a self-contained environment, environment variables can be used. However, it's recommended to use a 
solution that will encrypt the values of your secrets, such as Azure Key Vault.

### 1. Adding a unique identifier to .csproj
> dotnet user-secrets init
<br>

### 2. Adding a secret to the user secrets of the project (example with DefaultConnection)
> dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YourConnectionString"
<br>
This will store the user secret in a concrete place in your machine, outside of your project folders.
In a windows machine, the location will be:

> "%APPDATA%\Microsoft\UserSecrets\{YOUR_PROJECT_USER_SECRETS_ID}\secrets.json"
<br>
In a mac/linux machine, the location will be:

> "~/.microsoft/usersecrets/{YOUR_PROJECT_USER_SECRETS_ID}/secrets.json"
<br>

## Database set up
This section includes setting up the database connection, as well as preparing the tools to start developing using Entity Framework Core.
<br>

### 1. Get a database that can be reached by your .NET application using a connection string
I recommend using Docker for simplicity.
<br>

### 2. Add the connection string to the ConfigurationManager of your application using user secrets as explained above
<br>

### 3. Install the database nuget packages
Package for connecting your app to a PostgreSQL database:
> dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
<br>

Package for working with EF migrations and automatically creating a DbContext class from an existing database:
> dotnet add package Microsoft.EntityFrameworkCore.Design
<br>

Package for managing EF from the CLI (needed to run your migrations):
> dotnet add package Microsoft.EntityFrameworkCore.Tools
<br>

### 4. Install the ef tool locally
First, add a tool-manifest for the project
> dotnet new tool-manifest
Second, locally install the EF tool in order to manage EF from the CLI
> dotnet tool install dotnet-ef
<br> 

### 5. Create a DbContext class
This class must inherit from Microsoft.EntityFrameworkCore.DbContext and expose a constructor that accepts the database connection options. This class adds a data context to the application, implementing both the "repository" and "unit of work" patterns. This class will also expose the Entity classes that represent a table of your database by using the DbSet<> method.
<br>

### 6. Add your DbContext to the service container of your web application
This can be done using the "AddDbContext" extension method in the "Services" property of your app. This method takes a configuration function that receives an instance of "DbContextOptionsBuilder" as a parameter. You will apply another extension method 
"Use{DatabaseProvider}" to set the database provider. Example:
> builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
<br>

### 7. Create your models and add them to your DbContext class
See the codebase for reference
<br>

### 8. Create your first migration and run it to create your tables in the database
Create migrations from your models:
> dotnet ef migrations add InitialSchema
Run your migrations:
> dotnet ef database update
<br>
