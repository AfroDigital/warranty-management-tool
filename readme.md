# Warranty Manager
Warranty Manager is a web application developed for product warranty management for Zulu Enterprises. 
The web application consists of two applications.
- An Asp.Net Core Web API Application
- Am Angular Web Client

## Running The Web API
- Open the appsettings.json in the .Net Core Web Application and modify the connection strings to point to a local SQL database.
- Modify the connection string in the WarrantyManagementDbContext to match the appsettings.json connection string.
- Run EFCore database update to push the schema to the database.
- To populate the database with seed data change the Seed Database value in the appsettings.json.
- Start the application by running ``` dotnet watch run``` The application will start and will be running at ```https://localhost:5001```

## Running The Front End Web App
- Open the WarrantyManagerWeb project.
- run ```npm install```
- run  ```npm start```
- The front end application will start and will be running at ```https://localhost:4200```