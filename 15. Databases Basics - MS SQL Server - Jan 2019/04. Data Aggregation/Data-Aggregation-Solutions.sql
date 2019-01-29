--Problem_01
SELECT COUNT(*) AS [Count]
  FROM [dbo].[WizzardDeposits]

--Problem_02
SELECT MAX([MagicWandSize]) AS LongestMagicWand
  FROM [dbo].[WizzardDeposits]

--Problem_03
SELECT [DepositGroup]
	  ,MAX([MagicWandSize]) AS LongestMagicWand
  FROM [dbo].[WizzardDeposits]
  GROUP BY [DepositGroup]

--Problem_04
SELECT TOP (2) [DepositGroup]
  FROM [dbo].[WizzardDeposits]
  GROUP BY [DepositGroup]
  ORDER BY AVG([MagicWandSize])

--Problem_05
SELECT [DepositGroup]
	  ,SUM([DepositAmount]) AS TotalSum
  FROM [dbo].[WizzardDeposits]
  GROUP BY [DepositGroup]

--Problem_06
SELECT [DepositGroup]
	  ,SUM([DepositAmount]) AS TotalSum
  FROM [dbo].[WizzardDeposits]
  GROUP BY [DepositGroup], [MagicWandCreator]
  HAVING [MagicWandCreator] = 'Ollivander family'

--Problem_07
SELECT [DepositGroup]
	  ,SUM([DepositAmount]) AS TotalSum
  FROM [dbo].[WizzardDeposits]
  GROUP BY [DepositGroup], [MagicWandCreator]
  HAVING [MagicWandCreator] = 'Ollivander family'
  AND SUM([DepositAmount]) <= 150000
  ORDER BY SUM([DepositAmount]) DESC

--Problem_08
SELECT [DepositGroup]
	  ,[MagicWandCreator]
	  ,MIN([DepositCharge]) AS MinDepositCharge
  FROM [dbo].[WizzardDeposits]
  GROUP BY [DepositGroup], [MagicWandCreator]
  ORDER BY [MagicWandCreator], [DepositGroup]

--Problem_09
SELECT t.AgeGroups
	  ,SUM(t.CNT) AS WizardCount
FROM 
(SELECT CASE WHEN [Age] >= 0 AND [Age] <= 10 THEN '[0-10]'
			 WHEN [Age] >= 11 AND [Age] <= 20 THEN '[11-20]' 
			 WHEN [Age] >= 21 AND [Age] <= 30 THEN '[21-30]' 
			 WHEN [Age] >= 31 AND [Age] <= 40 THEN '[31-40]' 
			 WHEN [Age] >= 41 AND [Age] <= 50 THEN '[41-50]' 
			 WHEN [Age] >= 51 AND [Age] <= 60 THEN '[51-60]' 
			 ELSE '[61+]' END AS AgeGroups
      ,Count(Age) as CNT
  FROM [dbo].[WizzardDeposits]
  GROUP BY Age) t
  GROUP BY t.AgeGroups

--Problem_10
SELECT DISTINCT SUBSTRING([FirstName], 1, 1) as FirstLetter
  FROM [dbo].[WizzardDeposits]
  GROUP BY [FirstName], [DepositGroup]
  HAVING [DepositGroup] = 'Troll Chest'
  
--Problem_11
SELECT [DepositGroup]
      ,[IsDepositExpired]
	  ,AVG([DepositInterest]) as AverageInterest
  FROM [dbo].[WizzardDeposits]
  WHERE [DepositStartDate] >= '1985-01-01'
  GROUP BY [DepositGroup], [IsDepositExpired]
  ORDER BY [DepositGroup] DESC, [IsDepositExpired]

--Problem_12
SELECT SUM(t3.DIFF)
FROM
(SELECT t1.[FirstName]
      ,t1.[LastName]
	  ,t1.DepositAmount - t2.[DepositAmount] as DIFF
  FROM [dbo].[WizzardDeposits] t1
  JOIN [dbo].[WizzardDeposits] t2 ON t1.Id + 1 = t2.Id) t3

--Problem_13
SELECT [DepartmentID]
      ,SUM([Salary])
  FROM [dbo].[Employees]
 GROUP BY [DepartmentID]
 ORDER BY 1

--Problem_14
SELECT [DepartmentID]
      ,MIN([Salary])
  FROM [dbo].[Employees]
  WHERE [HireDate] >= '2000-01-01'
  AND DepartmentID IN (2, 5, 7)
  GROUP BY [DepartmentID]

--Problem_15
SELECT [EmployeeID]
      ,[FirstName]
      ,[LastName]
      ,[MiddleName]
      ,[JobTitle]
      ,[DepartmentID]
      ,[ManagerID]
      ,[HireDate]
      ,[Salary]
      ,[AddressID]
  INTO #TempTable
  FROM [dbo].[Employees]
  WHERE [Salary] > 30000

DELETE FROM #TempTable  
WHERE [ManagerID] = 42

UPDATE #TempTable 
SET Salary = Salary + 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID]
      ,AVG([Salary])
  FROM #TempTable 
 GROUP BY [DepartmentID]
 ORDER BY [DepartmentID]

--Problem_16
SELECT [DepartmentID]
      ,MAX([Salary])
  FROM [dbo].[Employees]
 GROUP BY [DepartmentID]
 HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

--Problem_17
 SELECT COUNT(*) AS [Count]
  FROM [dbo].[Employees]
  WHERE [ManagerID] IS NULL

--Problem_18
SELECT t.DepartmentID
	  ,t.Salary 
FROM
(SELECT [DepartmentID]
      ,[Salary]
	  ,RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS Rank  
  FROM [dbo].[Employees]
  GROUP BY [DepartmentID], [Salary]) t
  WHERE t.Rank = 3

--Problem_19
SELECT TOP(10) e.[FirstName]
			  ,e.[LastName]
			  ,e.DepartmentID
FROM [dbo].[Employees] e
JOIN (SELECT [DepartmentID]
	        ,AVG(Salary) AS AvgSalaryPerDep
        FROM [dbo].[Employees]
    GROUP BY [DepartmentID]) t 
	      ON t.DepartmentID =  e.DepartmentID
WHERE e.Salary > t.AvgSalaryPerDep
ORDER BY e.DepartmentID