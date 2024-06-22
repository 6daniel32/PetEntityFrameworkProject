# PetEntityFrameworkProject
Pet project to try out with Entity Framework

## Generating user secrets
### 1. Adding a unique identifier to .csproj
    > dotnet user-secrets init<br>
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
