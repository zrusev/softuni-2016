--Problem_02
SELECT * FROM dbo.Departments

--Problem_03
SELECT Name FROM dbo.Departments

--Problem_04
SELECT [FirstName]
      ,[LastName]
      ,[Salary]      
  FROM [dbo].[Employees]

--Problem_05
SELECT [FirstName]
      ,[MiddleName]
      ,[LastName]  
  FROM [dbo].[Employees]
  
--Problem_06
SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' as [Full Email Address]
  FROM [dbo].[Employees]

--Problem_07
SELECT DISTINCT Salary FROM [dbo].[Employees]

--Problem_08
SELECT * FROM [dbo].[Employees] WHERE JobTitle = 'Sales Representative'

--Problem_09
SELECT [FirstName]
      ,[LastName] 
	  ,JobTitle 
  FROM [dbo].[Employees] 
 WHERE Salary >= 20000
   AND Salary <= 30000

--Problem_10
SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) as [Full Name]
  FROM [dbo].[Employees] 
 WHERE Salary IN (25000, 14000, 12500, 23600)

--Problem_11
SELECT [FirstName]
      ,[LastName]
  FROM [dbo].[Employees] 
 WHERE [ManagerID] IS NULL

--Problem_12
SELECT [FirstName]
      ,[LastName]
	  ,Salary
  FROM [dbo].[Employees] 
 WHERE Salary >= 50000
 ORDER BY Salary DESC

--Problem_13
SELECT TOP(5) [FirstName]
             ,[LastName]
  FROM [dbo].[Employees] 
 ORDER BY Salary DESC.

--Problem_14
SELECT  [FirstName]
       ,[LastName]
  FROM [dbo].[Employees] 
 WHERE DepartmentID <> 4
 
--Problem_15
SELECT *
  FROM [dbo].[Employees]
ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName

--Problem_16
GO
CREATE VIEW V_EmployeesSalaries AS
SELECT [FirstName]
      ,[LastName]
      ,[Salary]      
  FROM [dbo].[Employees]
GO

--Problem_17
GO
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT([FirstName], ' ', ISNULL([MiddleName], ''), ' ', [LastName]) as [Full Name]
	  ,JobTitle
  FROM [dbo].[Employees] 
GO

--Problem_18
SELECT DISTINCT JobTitle
  FROM [dbo].[Employees] 
  
--Problem_19
SELECT TOP (10) *
  FROM [dbo].[Projects]
 ORDER BY [StartDate], Name

--Problem_20
SELECT TOP(7) [FirstName]
      ,[LastName]
      ,[HireDate]
  FROM [dbo].[Employees]
ORDER BY [HireDate] DESC

--Problem_21
SELECT Cast((Salary * 1.12) as decimal(18, 2)) AS Salary
  FROM [dbo].[Employees] e
INNER JOIN dbo.Departments d ON d.DepartmentID = e.DepartmentID
 WHERE d.[Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services') 

--Problem_22
SELECT [PeakName]      
  FROM [dbo].[Peaks]
ORDER BY [PeakName] ASC

--Problem_23
SELECT TOP(30) [CountryName]
      ,[Population]
  FROM [dbo].[Countries]
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC, [CountryName]

--Problem_24
SELECT [CountryName]
      ,[CountryCode]
	  ,CASE WHEN [CurrencyCode] = 'EUR' THEN 'Euro' ELSE 'Not Euro' END AS Currency
  FROM [dbo].[Countries]
ORDER BY CountryName 

--Problem_25
SELECT [Name]
  FROM [dbo].[Characters]
ORDER BY Name