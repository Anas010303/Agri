# Agri-Energy Connect Platform Prototype

## Introduction

This is a prototype web application developed as part of the Agri-Energy Connect Platform project. The application is built using ASP.NET Core and Entity Framework Core in Visual Studio with C#. It demonstrates a functional model of the intended final product, focusing on managing information about farmers and their products.

## Features

- Relational database to manage farmers and products.
- Sample data to simulate real-world scenarios.
- User roles: Farmer and Employee.
- Secure login functionality with role-specific access.
- Product addition feature for farmers.
- New farmer profile creation and product filtering for employees.
- User-friendly interface with responsive design.
- Data validation and error handling.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- Bootstrap
- HTML/CSS
- Visual Studio 2022

## Setup Instructions

### Prerequisites

1. Visual Studio 2022 (with .NET Core and ASP.NET workloads installed).
2. SQL Server (or SQL Server Express).

### Step-by-Step Instructions

1. **Clone the Repository**

git clone https://github.com/your-username/agri-energy-connect-platform.git
cd agri-energy-connect-platform 
2. **Open the Project in Visual Studio** 
Open Visual Studio and select `File > Open > Project/Solution`. Navigate to the cloned repository folder and open the solution file `AgriEnergyConnect.sln`. 
3. **Configure the Database Connection** 
Update the connection string in `appsettings.json` to point to your SQL Server instance: 
"ConnectionStrings": {
 "DefaultConnection": "Server=your_server_name;Database=AgriEnergyConnect;Trusted_Connection=True;MultipleActiveResultSets=true"
} 
4. **Apply Migrations and Seed the Database** 
Open the Package Manager Console in Visual Studio (`Tools > NuGet Package Manager > Package Manager Console`) and run the following commands: 
Update-Database 
5. **Build the Project** 
Build the project by selecting `Build > Build Solution` or pressing `Ctrl+Shift+B`. 
## Building and Running the Prototype 
1. **Run the Application** 
Press `F5` or select `Debug > Start Debugging` to run the application. This will launch the web application in your default browser. 
2. **Login** 
Use the default credentials to login as a Farmer or Employee: 
- Farmer: `example@example.com` / `Anas123`
- Employee: `example2@example.com` / `Anas1234` 
## System Functionalities 
### For Farmers 
- **Add New Products:** Farmers can add new products with details like name, category, and production date.
- **View Own Products:** Farmers can view a list of their own products. 
### For Employees 
- **Add New Farmer Profiles:** Employees can add new farmer profiles with essential details.
- **View and Filter Products:** Employees can view and filter a comprehensive list of products from any farmer based on criteria such as date range and product type. 
## User Roles 
### Farmer 
- Can add products to their profile.
- Can view their own product listings. 
### Employee 
- Can add new farmer profiles.
- Can view all products from specific farmers.
- Can use filters for product searching. 
## Notes 
- Ensure that the database connection string is correctly configured in `appsettings.json`.
- For any issues, please refer to the project's GitHub repository for additional documentation and issue tracking. 
## Conclusion 
This prototype web application demonstrates the key functionalities required for the Agri-Energy Connect Platform project. It provides a solid foundation for further development and refinement based on stakeholder feedback and additional requirements.
