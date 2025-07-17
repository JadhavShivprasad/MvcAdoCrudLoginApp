USE [shiv_DB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStudent]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateStudent]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateEmployee]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStudentById]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_GetStudentById]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployees]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_GetEmployees]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeById]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_GetEmployeeById]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllStudents]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllStudents]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDepartments]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllDepartments]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteStudent]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_DeleteStudent]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteEmployee]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_DeleteEmployee]
GO
/****** Object:  StoredProcedure [dbo].[sp_AuthenticateUser]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_AuthenticateUser]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddStudent]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_AddStudent]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddEmployee]    Script Date: 17-07-2025 15:22:42 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_AddEmployee]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17-07-2025 15:22:42 ******/
DROP TABLE IF EXISTS [dbo].[Users]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 17-07-2025 15:22:42 ******/
DROP TABLE IF EXISTS [dbo].[Students]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 17-07-2025 15:22:42 ******/
DROP TABLE IF EXISTS [dbo].[Employees]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 17-07-2025 15:22:42 ******/
DROP TABLE IF EXISTS [dbo].[Departments]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Department] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddEmployee]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddEmployee]
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Department NVARCHAR(50)
AS
BEGIN
    INSERT INTO Employees (Name, Email, Department)
    VALUES (@Name, @Email, @Department)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AddStudent]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddStudent]
    @Name NVARCHAR(100),
    @Email NVARCHAR(100)
AS
BEGIN
    INSERT INTO Students (Name, Email)
    VALUES (@Name, @Email)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AuthenticateUser]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AuthenticateUser]
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Users WHERE Username = @Username AND Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteEmployee]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteEmployee]
    @Id INT
AS
BEGIN
    DELETE FROM Employees WHERE EmployeeId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteStudent]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteStudent]
    @Id INT
AS
BEGIN
    DELETE FROM Students WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDepartments]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllDepartments]
AS
BEGIN
    SELECT Id, Name FROM Departments
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllStudents]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllStudents]
AS
BEGIN
    SELECT * FROM Students
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeById]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetEmployeeById]
    @Id INT
AS
BEGIN
    select A.EmployeeId, A.Name, A.Email, B.Name as Department from Employees A
			join Departments B on A.Department = B.Id WHERE A.EmployeeId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployees]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetEmployees]
AS
BEGIN
    
			select A.EmployeeId, A.Name, A.Email, B.Name as Department from Employees A
			join Departments B on A.Department = B.Id


END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStudentById]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetStudentById]
    @Id INT
AS
BEGIN
    SELECT * FROM Students WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateEmployee]
    @Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Department NVARCHAR(50)
AS
BEGIN
    UPDATE Employees SET Name = @Name, Email = @Email, Department = @Department WHERE EmployeeId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStudent]    Script Date: 17-07-2025 15:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateStudent]
    @Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100)
AS
BEGIN
    UPDATE Students
    SET Name = @Name, Email = @Email
    WHERE Id = @Id
END
GO
