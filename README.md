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

> // The configuration manager is available as a property in both the WebApplicationBuilder and the 
> // WebApplication instances.
> WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
> // Clear the default providers before adding the new ones. 
> builder.Configuration.Sources.Clear();
> // Add configuration providers, along with the filename that we will use.
> builder.Configuration.AddJsonFile("appsettings.json", optional: true);
> // Variables in the config file are now available in the ConfigurationManager instance
> var isPurchasesEnabled = builder.Configuration["FeatureFlags:PurchasesEnabled"];

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

## Setting up a database connection
TODO