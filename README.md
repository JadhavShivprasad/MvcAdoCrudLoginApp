# MvcAdoCrudLoginApp

A simple ASP.NET MVC web application that demonstrates CRUD operations using ADO.NET and includes login functionality with session-based authentication.

## 🔧 Features

- User login with session management
- CRUD operations for:
  - Students
  - Employees
  - Departments
- Clean and structured MVC architecture
- Connected with SQL Server using ADO.NET
- Role-based navigation and form validation

## 🛠️ Technologies Used

- ASP.NET MVC 5
- ADO.NET
- SQL Server
- HTML/CSS
- Visual Studio 2022

## 📁 Folder Structure

MvcAdoCrudLoginApp/
├── Controllers/
│ ├── StudentController.cs
│ ├── EmployeeController.cs
│ └── DepartmentController.cs
├── Models/
│ ├── Student.cs
│ ├── Employee.cs
│ └── Department.cs
├── Views/
│ ├── Student/
│ ├── Employee/
│ └── Department/
└── Web.config
├── Global.asax
└── ...


## 🚀 Getting Started

### Prerequisites

- Visual Studio 2019 or 2022
- SQL Server (Express or LocalDB)
- .NET Framework 4.7.2 or later

### DATABASE Changes

1. Execute file **DropAndCreateScript.sql** in MSSQL for table and stored procedure.
2. Execute file **InsertForUserAdmin.sql** in MSSQL for user creation in Users Table.

### Setup Instructions

1. **Clone the repository:**

``bash
git clone https://github.com/your-username/MvcAdoCrudLoginApp.git

2. **Open Solution in VS22:**

3. **Update Web.config connection string:**

    <connectionStrings>
      <add name="DefaultConnection"
           connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=shiv_DB;Persist Security Info=True;User ID=sa;Password=YourPassword;"
           providerName="System.Data.SqlClient" />
    </connectionStrings>
    
Replace YOUR_SERVER_NAME and YourPassword with your actual SQL Server credentials.

5. **Build and Run the application (F5).**

6. **Login using your test credentials**

### Screenshots

**Login Page**

<img width="1366" height="644" alt="image" src="https://github.com/user-attachments/assets/67186b08-e4f3-4649-b34a-8a8dc3165d56" />


**Employee List with Edit Delete functionality**

<img width="1366" height="643" alt="image" src="https://github.com/user-attachments/assets/81c2f0f8-17c4-47a5-8787-4be81eccf09a" />


**Create Employee**

<img width="1366" height="639" alt="image" src="https://github.com/user-attachments/assets/a0609f89-b95e-4ce1-ad14-36e512601b38" />


**Department Dropdown**

<img width="1366" height="640" alt="image" src="https://github.com/user-attachments/assets/65f7c469-1352-45f1-8bf3-c35b72d910b2" />


**Department Add Edit page**

<img width="1366" height="642" alt="image" src="https://github.com/user-attachments/assets/d9f22543-8494-48a0-80f0-aab785bd435c" />


**Student List with Edit Delete functionality**

<img width="1366" height="642" alt="image" src="https://github.com/user-attachments/assets/90c28752-822c-4a7d-a9ed-3b841435293f" />


**Student add form**

<img width="1366" height="639" alt="image" src="https://github.com/user-attachments/assets/6214b8eb-756a-4c71-959a-c0c2b8095d8f" />


