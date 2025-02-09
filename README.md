# employee-list-app

Overview

This is a simple Employee List Application that provides functionalities to:

• Create a new employee

• Update an existing employee's information

• View current employees

• Remove current employee

• View all list of employees

The frontend of the application was not completed. However, all backend functionalities were successfully implemented using C# with Entity Framework and stored procedures.

Technologies Used

• Backend: C# (.NET Core)

• Database: Microsoft SQL Server (MSSQL)

• ORM: Entity Framework

Steps to Run
1. Go to database folder and import the EmployeeDB.bacpac in your SQL Server and name it as EmployeeDB. (Import Data-tier Application)

2. Configure connection string in your appsettings.json. 

"ConnectionStrings": {
  "DefaultConnection": "Server=LAPTOP-IF7ITJBP\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
}, //Change the server to you server name

3. Run & Test API in Swagger
• Press F5 to start the project.
• Test the API endpoints.
