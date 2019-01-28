-- Problem_01
SELECT [FirstName]
      ,[LastName]
  FROM [dbo].[Employees]
  WHERE [FirstName] like 'SA%'

-- Problem_02
SELECT [FirstName]
      ,[LastName]
  FROM [dbo].[Employees]
  WHERE [LastName] like '%ei%'

-- Problem_03
SELECT [FirstName]
  FROM [dbo].[Employees]
  WHERE [DepartmentID] IN (3,10)
  AND YEAR([HireDate]) >= 1995 
  AND YEAR([HireDate]) <= 2005

-- Problem_04
SELECT [FirstName]
      ,[LastName]
  FROM [dbo].[Employees]
  WHERE [JobTitle] NOT LIKE '%engineer%'

-- Problem_05
SELECT [Name]
  FROM [dbo].[Towns]
  WHERE LEN([Name]) = 5
  OR LEN([Name]) = 6
ORDER BY NAME ASC 

-- Problem_06
SELECT [TownID]
	  ,[Name]
  FROM [dbo].[Towns]
  WHERE SUBSTRING([NAME], 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY NAME ASC 

-- Problem_07
SELECT [TownID]
	  ,[Name]
  FROM [dbo].[Towns]
  WHERE SUBSTRING([NAME], 1, 1) NOT IN ('R', 'B', 'D')
ORDER BY NAME ASC 

-- Problem_08
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName]
      ,[LastName]
  FROM [dbo].[Employees]
  WHERE YEAR([HireDate]) > 2000
GO

-- Problem_09
SELECT [FirstName]
      ,[LastName]
  FROM [dbo].[Employees]
  WHERE LEN([LastName]) = 5

-- Problem_10
SELECT [EmployeeID]
      ,[FirstName]
      ,[LastName]
      ,[Salary]
	  ,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank  
  FROM [dbo].[Employees]
  WHERE Salary BETWEEN 10000 AND 50000 
  ORDER BY Salary DESC

-- Problem_11
SELECT t.* FROM
(SELECT [EmployeeID]
      ,[FirstName]
      ,[LastName]
      ,[Salary]
	  ,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank  
  FROM [dbo].[Employees]
  WHERE Salary BETWEEN 10000 AND 50000) t
  WHERE t.Rank = 2
  ORDER BY t.Salary DESC

-- Problem_12
SELECT [CountryName]
      ,[IsoCode]
  FROM [dbo].[Countries]
  WHERE LEN([CountryName]) - LEN(REPLACE(LOWER([CountryName]), 'a', '')) >= 3
  ORDER BY IsoCode

-- Problem_13
SELECT [PeakName]
	  ,[RiverName]
	  ,LOWER(SUBSTRING([PeakName], 1, LEN([PeakName]) - 1) + [RiverName]) AS Mix
  FROM [dbo].[Rivers]
  JOIN [dbo].[Peaks] ON SUBSTRING([PeakName], LEN([PeakName]), 1) = LOWER(SUBSTRING([RiverName], 1, 1))
  ORDER BY LOWER([PeakName] + [RiverName])

-- Problem_14
SELECT TOP (50) [Name]
      ,FORMAT([Start], 'yyyy-MM-dd') AS Start
  FROM [dbo].[Games]
  WHERE ([Start] >= '2011-01-01' AND [Start] < '2013-01-01')
  ORDER BY CAST([Start] AS DATE), [Name]

-- Problem_15
SELECT [Username]
      ,SUBSTRING([Email], CHARINDEX('@', [Email],1) + 1,  len(Email) - CHARINDEX('@', [Email],1)) as [Email Provider]
  FROM [Diablo].[dbo].[Users]
  ORDER BY SUBSTRING([Email], CHARINDEX('@', [Email],1) + 1,  len(Email) - CHARINDEX('@', [Email],1)), [Username]

-- Problem_16
SELECT [Username]
      ,[IpAddress]
  FROM [dbo].[Users]
  WHERE IpAddress like '[1-9][0-9][0-9].1%.%.[0-9][0-9][0-9]'
  ORDER BY [Username]

-- Problem_17
SELECT t.* FROM
(SELECT [Name]
	  ,CASE WHEN CAST([Start] AS TIME) >= '00:00' AND CAST([Start] AS TIME) < '12:00' THEN 'Morning' 
			WHEN CAST([Start] AS TIME) >= '12:00' AND CAST([Start] AS TIME) < '18:00' THEN 'Afternoon'
			WHEN CAST([Start] AS TIME) >= '18:00' AND CAST([Start] AS TIME) <= '23:59' THEN 'Evening' END AS [Parts of the day]
	  ,CASE WHEN [Duration] <= 3 THEN 'Extra Short'
			WHEN [Duration] >= 4 AND [Duration] <= 6 THEN 'Short'
			WHEN [Duration] > 6 THEN 'Long'
			ELSE 'Extra Long' END AS [Duration]
  FROM [dbo].[Games]) t
  ORDER BY t.[Name], t.[Duration], t.[Parts of the day]

-- Problem_18
SELECT ProductName
	  ,OrderDate
	  ,DATEADD(DAY, 3, OrderDate) as [Pay Due]
	  ,DATEADD(MONTH, 1, OrderDate) as [Deliver Due]
FROM Orders