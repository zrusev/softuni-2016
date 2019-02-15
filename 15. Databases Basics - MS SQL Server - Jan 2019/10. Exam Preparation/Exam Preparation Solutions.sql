Create database ColonialJourney
GO
USE ColonialJourney
GO

--Problem_01
Create Table Planets (
	Id int Identity(1,1) Primary Key,
	[Name] varchar(30) not null
)

Create Table Spaceports (
	Id int Identity(1,1) Primary Key,
	[Name] varchar(50) not null,
	PlanetId int not null Foreign Key References Planets(Id)
)

Create Table Spaceships (
	Id int Identity(1,1) Primary Key,
	[Name] varchar(50) not null,
	Manufacturer varchar(30) not null,
	LightSpeedRate int default 0
)

Create Table Colonists (
	Id int Identity(1,1) Primary Key,
	FirstName varchar(20) not null,
	LastName varchar(20) not null,
	Ucn varchar(10) not null Unique,
	BirthDate Date not null
)

Create Table Journeys (
	Id int Identity(1,1) Primary Key,
	JourneyStart DateTime not null,
	JourneyEnd DateTime not null,
	Purpose varchar(11) not null CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')), 
	DestinationSpaceportId int not null Foreign Key References Spaceports(Id),
	SpaceshipId int not null Foreign Key References Spaceships(Id), 
)

Create Table TravelCards (
	Id int Identity(1,1) Primary Key,
	CardNumber varchar(10) not null Unique,
	JobDuringJourney varchar(8) not null CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId int not null Foreign Key References Colonists(Id),
	JourneyId int not null Foreign Key References Journeys(Id)
)

--Problem_02
Insert into Planets
(Name)
Values
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

Insert into Spaceships
(Name,	Manufacturer,	LightSpeedRate)
Values
('Golf',	'VW',	3),
('WakaWaka',	'Wakanda',	4),
('Falcon9',	'SpaceX',	1),
('Bed',	'Vidolov',	6)

--Problem_03
Update Spaceships
SET LightSpeedRate = LightSpeedRate + 1
Where Id BETWEEN 8 AND 12

--Problem_04
Delete from TravelCards 
Where JourneyId IN 
(Select TOP 3 Id FROM Journeys Order by Id)

Delete from Journeys 
Where Id IN 
(Select TOP 3 Id FROM Journeys Order by Id)

--Problem_05
Select CardNumber, JobDuringJourney
From TravelCards
Order by CardNumber

--Problem_06
SELECT [Id]
      ,Concat([FirstName], ' ', [LastName]) as [Full Name]
      ,[Ucn]
  FROM [dbo].[Colonists]
  Order by FirstName, LastName, Id

--Problem_07
SELECT [Id]
      ,Format(Cast([JourneyStart] as Date), 'dd/MM/yyyy') as [JourneyStart]
      ,Format(Cast([JourneyEnd] as Date), 'dd/MM/yyyy') as [JourneyEnd]
  FROM [dbo].[Journeys]
  Where Purpose = 'Military'
  Order by JourneyStart

--Problem_08
SELECT [dbo].[Colonists].[Id]
	,Concat([FirstName], ' ', [LastName]) as [Full Name]
  FROM [dbo].[Colonists]
  Inner Join [dbo].[TravelCards] 
  On [dbo].[TravelCards].ColonistId = [dbo].[Colonists].Id
  Where [JobDuringJourney] = 'Pilot'
  Order by [dbo].[Colonists].[Id]

--Problem_09
SELECT Count(*) As [Count]
  FROM [dbo].[Journeys]
  Inner join [dbo].[TravelCards]
  on [dbo].[TravelCards].JourneyId = [dbo].[Journeys].Id
  Inner join [dbo].[Colonists]
  On [dbo].[Colonists].Id = [ColonistId]
  Where [Purpose] = 'Technical'

--Problem_10
SELECT TOP 1 [dbo].[Spaceships].[Name] As SpaceshipName
      ,[dbo].[Spaceports].[Name] As SpaceportName
  FROM [dbo].[Spaceships]
  Inner join [dbo].[Journeys]
  On [dbo].[Journeys].SpaceshipId = [dbo].[Spaceships].Id
  Inner join [dbo].[Spaceports]
  On [dbo].[Spaceports].Id = [dbo].[Journeys].[DestinationSpaceportId]
  order by [LightSpeedRate] Desc

--Problem_11
SELECT s.Name, s.Manufacturer
FROM Colonists c
JOIN TravelCards tc ON tc.ColonistId = c.id
JOIN Journeys j on tc.JourneyId = j.id
JOIN Spaceships s on j.SpaceshipId = s.id
WHERE DATEDIFF(YEAR, c.Birthdate, '01/01/2019') < 30 AND tc.JobDuringJourney = 'Pilot'
ORDER BY s.Name

--Problem_12
SELECT p.Name PlanetName, sp.Name AS SpaceportName
FROM Planets p
JOIN Spaceports sp on p.id = sp.PlanetId
JOIN Journeys j on sp.id = j.DestinationSpaceportId
WHERE j.Purpose = 'Educational'
ORDER BY SpaceportName DESC

--Problem_13
SELECT p.Name as PlanetName
	  ,Count(j.Id) as JourneysCount
  FROM [dbo].[Spaceports] sp
  Inner join [dbo].[Planets] p
  On p.Id = sp.PlanetId
  Inner join dbo.Journeys j
  On j.DestinationSpaceportId = sp.Id
  group by p.Name
  order by JourneysCount desc,
  PlanetName

--Problem_14
SELECT TOP 1 j.[Id]
	  ,p.Name as PlanetName
	  ,sp.Name as SpaceportName
	  ,j.Purpose as JourneyPurpose
  FROM [dbo].[Journeys] j
  Inner join dbo.Spaceports sp
  on sp.Id = j.DestinationSpaceportId
  Inner join dbo.Planets p
  on p.Id = sp.PlanetId
  Order by DateDiff(Day, [JourneyStart], [JourneyEnd])

--Problem_15
SELECT TOP 1 j.Id
	  ,tc.JobDuringJourney
FROM [dbo].[Journeys] j
Inner join dbo.TravelCards tc
on tc.JourneyId = j.Id
Inner join dbo.Colonists c
on c.Id = tc.ColonistId
Where tc.JourneyId = (Select top 1 Id from [dbo].[Journeys] order by DateDiff(day, [JourneyStart], [JourneyEnd]) Desc)
Group by j.Id, tc.JobDuringJourney
Order by Count(tc.ColonistId) 

--Problem_16
Select *
FROM
(SELECT tc.JobDuringJourney
      ,Concat(c.[FirstName], ' ', c.[LastName]) as [Full Name]
	  ,RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) As Rnk
  FROM [dbo].[TravelCards] tc
  Inner join dbo.Colonists c
  on tc.ColonistId = c.Id
  Group by tc.JobDuringJourney, c.BirthDate, c.[FirstName], c.[LastName]) t
Where t.Rnk = 2

--Problem_17
SELECT p.[Name]
	   ,Count(sp.PlanetId) as [Count]
  FROM [dbo].[Planets] p
  LEFT join dbo.Spaceports sp
  on sp.PlanetId = p.Id
  Group by p.[Name]
  Order by [Count] desc, p.Name

--Problem_18
Create Function dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30)) 
RETURNS Table
AS
RETURN
	(
	SELECT p.Name as PlanetName
		,Count(c.Id) as [Count]
	FROM dbo.Planets p
	Inner join dbo.Spaceports sp
	on sp.PlanetId = p.Id
	Inner join dbo.Journeys j
	on j.DestinationSpaceportId = sp.Id
	inner join dbo.TravelCards tc
	on tc.JourneyId = j.Id
	inner join dbo.Colonists c
	on c.Id = tc.ColonistId
	GROUP BY p.Name
	Having p.Name = @PlanetName
	)

--Problem_18
CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*) FROM Journeys AS j
	JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
	JOIN Planets AS p ON p.Id = s.PlanetId
	JOIN TravelCards AS tc ON tc.JourneyId = j.Id
	JOIN Colonists AS c ON c.Id = tc.ColonistId
	WHERE p.Name = @PlanetName)
END

--Problem_19
Create Procedure dbo.usp_ChangeJourneyPurpose @JourneyId int, @NewPurpose varchar(30)
AS
	BEGIN
	Declare @DoesJourneyExists int = (Select Count(*) From dbo.Journeys Where Id = @JourneyId);
	
	If (@DoesJourneyExists = 0)
		BEGIN
			RAISERROR('The journey does not exist!', 16, 1);
			RETURN;
		END 

	DECLARE @CurrentJourneyPurpose VARCHAR(30) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

	IF (@CurrentJourneyPurpose = @NewPurpose)
		BEGIN
			RAISERROR('You cannot change the purpose!', 16, 1);
			RETURN;
		END

	UPDATE dbo.Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @JourneyId;
	END

--Problem_20
CREATE TABLE DeletedJourneys
(
	Id INT,
	JourneyStart DATETIME,
	JourneyEnd DATETIME,
	Purpose VARCHAR(11),
	DestinationSpaceportId INT,
	SpaceshipId INT
)

CREATE TRIGGER t_DeleteJourney
	ON Journeys
	AFTER DELETE
AS
	BEGIN
		INSERT INTO DeletedJourneys(Id,JourneyStart,JourneyEnd,Purpose,DestinationSpaceportId,
		SpaceshipId)
		SELECT Id,JourneyStart,JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId FROM deleted
	END