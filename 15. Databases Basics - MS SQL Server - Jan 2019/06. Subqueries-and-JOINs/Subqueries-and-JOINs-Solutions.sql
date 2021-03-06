--Problem_01 
SELECT top(5) [EmployeeID] 
              ,[JobTitle] 
              ,E.[AddressID] 
              ,[dbo].[ADDRESSES].AddressText 
FROM   [dbo].[EMPLOYEES] E 
       INNER JOIN [dbo].[ADDRESSES] 
               ON [dbo].[ADDRESSES].AddressID = E.AddressID 
ORDER  BY E.[AddressID] asc 

--Problem_02 
SELECT top(50) [FirstName] 
               ,[LastName] 
               ,[dbo].TOWNS.Name 
               ,[dbo].[ADDRESSES].AddressText 
FROM   [dbo].[EMPLOYEES] E 
       INNER JOIN [dbo].[ADDRESSES] 
               ON [dbo].[ADDRESSES].AddressID = E.AddressID 
       INNER JOIN [dbo].TOWNS 
               ON [dbo].[ADDRESSES].TownID = [dbo].TOWNS.TownID 
ORDER  BY [FirstName] 
          ,LastName asc 

--Problem_03 
SELECT [EmployeeID] 
       ,[FirstName] 
       ,[LastName] 
       ,[dbo].[DEPARTMENTS].Name 
FROM   [dbo].[EMPLOYEES] E 
       INNER JOIN [dbo].[DEPARTMENTS] 
               ON [dbo].[DEPARTMENTS].DepartmentID = E.DepartmentID 
WHERE  [dbo].[DEPARTMENTS].Name = 'Sales' 
ORDER  BY [EmployeeID] 

--Problem_04 
SELECT TOP(5) [EmployeeID] 
              ,[FirstName] 
              ,Salary 
              ,[dbo].[DEPARTMENTS].Name 
FROM   [dbo].[EMPLOYEES] E 
       INNER JOIN [dbo].[DEPARTMENTS] 
               ON [dbo].[DEPARTMENTS].DepartmentID = E.DepartmentID 
WHERE  Salary > 15000 
ORDER  BY E.DepartmentID ASC 

--Problem_05 
SELECT TOP(3) E.[EmployeeID] 
              ,[FirstName] 
FROM   [dbo].[EMPLOYEES] E 
       left JOIN [dbo].[EMPLOYEESPROJECTS] 
              ON [dbo].[EMPLOYEESPROJECTS].EmployeeID = E.EmployeeID 
       left JOIN [dbo].[PROJECTS] 
              ON [dbo].[PROJECTS].[ProjectID] = 
                 [dbo].[EMPLOYEESPROJECTS].ProjectID 
WHERE  [dbo].[PROJECTS].ProjectID is null 
ORDER  BY E.[EmployeeID] ASC 

--Problem_06 
SELECT [FirstName] 
       ,[LastName] 
       ,[HireDate] 
       ,[dbo].[DEPARTMENTS].Name 
FROM   [dbo].[EMPLOYEES] E 
       INNER JOIN [dbo].[DEPARTMENTS] 
               on [dbo].[DEPARTMENTS].DepartmentID = E.DepartmentID 
WHERE  HireDate > '1999-01-01' 
   AND ( [dbo].[DEPARTMENTS].Name = 'Sales' 
          OR [dbo].[DEPARTMENTS].Name = 'Finance' ) 
ORDER  BY HireDate 

--Problem_07 
SELECT TOP(5) E.EmployeeID 
              ,[FirstName] 
              ,[dbo].[PROJECTS].Name as ProjectName 
FROM   [dbo].[EMPLOYEES] E 
       INNER JOIN [dbo].[DEPARTMENTS] 
               on [dbo].[DEPARTMENTS].DepartmentID = E.DepartmentID 
       INNER JOIN [dbo].[EMPLOYEESPROJECTS] 
               on [dbo].[EMPLOYEESPROJECTS].EmployeeID = E.EmployeeID 
       INNER JOIN [dbo].[PROJECTS] 
               on [dbo].[PROJECTS].ProjectID = 
                  [dbo].[EMPLOYEESPROJECTS].ProjectID 
WHERE  [dbo].[PROJECTS].StartDate > '2002-08-13' 
   AND [dbo].[PROJECTS].EndDate is null 
ORDER  BY E.EmployeeID 

--Problem_08 
SELECT E.EmployeeID 
       ,[FirstName] 
       ,Case 
          when Year([dbo].[PROJECTS].StartDate) = 2005 then NULL 
          else [dbo].[PROJECTS].Name 
        End as ProjectName 
FROM   [dbo].[EMPLOYEES] E 
       INNER JOIN [dbo].[DEPARTMENTS] 
               on [dbo].[DEPARTMENTS].DepartmentID = E.DepartmentID 
       INNER JOIN [dbo].[EMPLOYEESPROJECTS] 
               on [dbo].[EMPLOYEESPROJECTS].EmployeeID = E.EmployeeID 
       INNER JOIN [dbo].[PROJECTS] 
               on [dbo].[PROJECTS].ProjectID = 
                  [dbo].[EMPLOYEESPROJECTS].ProjectID 
WHERE  E.EmployeeID = 24 
ORDER  BY E.EmployeeID 

--Problem_09 
SELECT E.[EmployeeID] 
       ,E.[FirstName] 
       ,E.[ManagerID] 
       ,M.FirstName as ManagerName 
FROM   [dbo].[EMPLOYEES] E 
       INNER JOIN [dbo].[EMPLOYEES] M 
               on M.EmployeeID = E.ManagerID 
WHERE  E.ManagerID = 3 
    or E.ManagerID = 7 
ORDER  BY E.[EmployeeID] 

--Problem_10 
SELECT top(50) E.[EmployeeID] 
               ,E.[FirstName] + ' ' + E.LastName as EmployeeName 
               ,M.FirstName + ' ' + M.LastName   as ManagerName 
               ,dbo.DEPARTMENTS.Name 
FROM   [dbo].[EMPLOYEES] E 
       INNER JOIN [dbo].[EMPLOYEES] M 
               on M.EmployeeID = E.ManagerID 
       INNER JOIN [dbo].[DEPARTMENTS] 
               on [dbo].[DEPARTMENTS].DepartmentID = E.DepartmentID 
ORDER  BY E.[EmployeeID] 

--Problem_11 
SELECT TOP(1) Avg([Salary]) as MinAverageSalary 
FROM   [dbo].[EMPLOYEES] E 
GROUP  BY E.DepartmentID 
ORDER  BY Avg([Salary]) 

--Problem_12 
SELECT CountryCode 
       ,[MountainRange] 
       ,[PeakName] 
       ,[Elevation] 
FROM   [dbo].[PEAKS] 
       INNER JOIN [dbo].[MOUNTAINS] 
               on [dbo].[MOUNTAINS].Id = [dbo].[PEAKS].MountainId 
       INNER JOIN [dbo].[MOUNTAINSCOUNTRIES] 
               on [dbo].[MOUNTAINSCOUNTRIES].MountainId = [dbo].[MOUNTAINS].Id 
WHERE  [Elevation] > 2835 
   AND CountryCode = 'BG' 
ORDER  BY [Elevation] desc 

--Problem_13 
SELECT M.[CountryCode] 
       ,Count([MountainRange]) 
FROM   [dbo].[MOUNTAINS] 
       INNER JOIN [dbo].[MOUNTAINSCOUNTRIES] M 
               on M.MountainId = [dbo].[MOUNTAINS].Id 
       INNER JOIN [dbo].[COUNTRIES] 
               on [dbo].[COUNTRIES].CountryCode = M.CountryCode 
WHERE  [dbo].[COUNTRIES].CountryName IN ( 'United States', 'Russia', 'Bulgaria' 
                                        ) 
GROUP  BY M.[CountryCode] 

--Problem_14 
SELECT top(5) CountryName 
              ,[RiverName] 
FROM   [dbo].[COUNTRIES] 
       LEFT JOIN [dbo].[COUNTRIESRIVERS] 
              on [dbo].[COUNTRIESRIVERS].CountryCode = 
                 [dbo].[COUNTRIES].CountryCode 
       LEFT JOIN [dbo].[RIVERS] 
              on [dbo].[RIVERS].Id = [dbo].[COUNTRIESRIVERS].RiverId 
       LEFT JOIN [dbo].[CONTINENTS] 
              ON [dbo].[CONTINENTS].ContinentCode = 
                 [dbo].[COUNTRIES].ContinentCode 
WHERE  [dbo].[COUNTRIES].ContinentCode = 'AF' 
ORDER  BY CountryName 

--Problem_15 
SELECT T.[ContinentCode] 
       ,T.[CurrencyCode] 
       ,T.CurrencyUsage 
FROM   (SELECT [ContinentCode] 
               ,[CurrencyCode] 
               ,Count([CountryCode])                    as CurrencyUsage 
               ,Rank() 
                  OVER ( 
                    PARTITION BY [ContinentCode] 
                    order by Count([CountryCode]) DESC) as rnk 
        FROM   [dbo].[COUNTRIES] 
        GROUP  BY [CurrencyCode] 
                  ,[ContinentCode] 
        HAVING Count([CountryCode]) > 1) T 
WHERE  T.rnk = 1 
   AND T.[ContinentCode] is not null 
ORDER  BY ContinentCode 

--Problem_16 
SELECT Count([dbo].[COUNTRIES].[CountryCode]) 
FROM   [dbo].[COUNTRIES] 
       LEFT JOIN [dbo].[MOUNTAINSCOUNTRIES] 
              on [dbo].[COUNTRIES].[CountryCode] = 
                 [dbo].[MOUNTAINSCOUNTRIES].[CountryCode] 
WHERE  [dbo].[MOUNTAINSCOUNTRIES].CountryCode is null 

--Problem_17 
SELECT TOP(5) C.[CountryName] 
              ,Max([dbo].[PEAKS].Elevation) as HighestPeakElevation 
              ,Max([dbo].[RIVERS].[Length]) as LongestRiverLength 
FROM   [dbo].[COUNTRIES] C 
       LEFT JOIN [dbo].[MOUNTAINSCOUNTRIES] 
              on [dbo].[MOUNTAINSCOUNTRIES].CountryCode = C.CountryCode 
       LEFT JOIN [dbo].[PEAKS] 
              on [dbo].[PEAKS].MountainId = 
                 [dbo].[MOUNTAINSCOUNTRIES].MountainId 
       LEFT JOIN [dbo].[COUNTRIESRIVERS] 
              on [dbo].[COUNTRIESRIVERS].CountryCode = C.[CountryCode] 
       LEFT JOIN [dbo].[RIVERS] 
              on [dbo].[RIVERS].Id = [dbo].[COUNTRIESRIVERS].RiverId 
GROUP  BY C.[CountryName] 
ORDER  BY Max([dbo].[PEAKS].Elevation) DESC 
          ,Max([dbo].[RIVERS].[Length]) DESC 

--Problem_18 
SELECT TOP(5) T.[CountryName] 
              ,T.PeakName 
              ,T.HighestPeakElevation 
              ,T.Mountain 
FROM   (SELECT [CountryName] 
               ,CASE 
                  WHEN [PeakName] IS NULL THEN '(no highest peak)' 
                  ELSE [PeakName] 
                END                                             as [PeakName] 
               ,CASE 
                  WHEN [PeakName] IS NULL THEN 0 
                  ELSE Max([dbo].[PEAKS].Elevation) 
                END                                             as 
                HighestPeakElevation 
               ,CASE 
                  WHEN [PeakName] IS NULL THEN '(no mountain)' 
                  else [dbo].[MOUNTAINS].MountainRange 
                END                                             as Mountain 
               ,Rank() 
                  OVER ( 
                    PARTITION BY [CountryName] 
                    order by Max([dbo].[PEAKS].Elevation) DESC) as rnk 
        FROM   [dbo].[COUNTRIES] C 
               LEFT JOIN [dbo].[MOUNTAINSCOUNTRIES] 
                      on [dbo].[MOUNTAINSCOUNTRIES].CountryCode = C.CountryCode 
               LEFT JOIN [dbo].[MOUNTAINS] 
                      on [dbo].[MOUNTAINS].Id = 
                         [dbo].[MOUNTAINSCOUNTRIES].MountainId 
               LEFT JOIN [dbo].[PEAKS] 
                      on [dbo].[PEAKS].MountainId = 
                         [dbo].[MOUNTAINSCOUNTRIES].MountainId 
        GROUP  BY C.[CountryName] 
                  ,[PeakName] 
                  ,[dbo].[MOUNTAINS].MountainRange) T 
WHERE  T.rnk = 1 
ORDER  BY T.CountryName 
          ,T.[PeakName] 