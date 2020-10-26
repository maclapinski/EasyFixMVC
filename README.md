## Easy Fix

This is a .NET MVC application that allows users to troubleshoot appliances. The user can find the description of an error code, go through troubleshooting steps related to the code and leave a comment on the repair. 
Admin functionality allows adding new fault codes and troubleshooting steps.

This project emphasizes the following concepts:
- Entity Framework showing a one-to-many relationship
- Interfaces and dependency injection
- Configuring, publishing, and deploying an application

## Deployment steps:

- Sign up for Azure
- Create an App Service in Azure (.NET Core 3.1, Windows, free tier)
- Download the Azure App Service VS Code extension
- Set up separate environments (dbs and appSettings.json files) for dev and prod
- Run the cli command: `dotnet publish --configuration Release -o publish`
- Right-click on the generated publish folder and deploy to your app service 

## Next step

- Auth and identity
