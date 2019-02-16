Create Database RentACar
Go
Use RentACar
Go

--Problem_01
Create Table Clients(
	Id int Identity(1,1) Primary Key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	Gender char(1) CHECK(Gender IN ('M', 'F')),
	BirthDate DateTime,
	CreditCard nvarchar(30) not null,
	CardValidity DateTime,
	Email nvarchar(50) not null
)

Create Table Towns(
	Id int Identity(1,1) Primary Key,
	Name nvarchar(50) not null
)
 
Create Table Offices(
	Id int Identity(1,1) Primary Key,
	Name nvarchar(40) not null,
	ParkingPlaces int,
	TownId int not null Foreign Key References Towns(Id)
)

Create Table Models(
	Id int Identity(1,1) Primary Key,
	Manufacturer nvarchar(50) not null,
	Model nvarchar(50) not null,
	ProductionYear DateTime,
	Seats int,
	Class nvarchar(10),
	Consumption decimal(14,2)
)

Create Table Vehicles(
	Id int Identity(1,1) Primary Key,
	ModelId int not null Foreign Key References Models(Id),
	OfficeId int not null Foreign Key References Offices(Id),
	Mileage int
)

Create Table Orders(
	Id int Identity(1,1) Primary Key,
	ClientId int not null Foreign Key References Clients(Id),
	TownId int not null Foreign Key References Towns(Id),
	VehicleId int not null Foreign Key References Vehicles(Id),
	CollectionDate DateTime not null,
	CollectionOfficeId int not null Foreign Key References Offices(Id),
	ReturnDate DateTime,
	ReturnOfficeId int Foreign Key References Offices(Id),
	Bill decimal(14,2),
	TotalMileage int
)

--Problem_02
Insert into dbo.Models
(Manufacturer,	Model,	ProductionYear,	Seats,	Class,	Consumption)
Values
('Chevrolet',	'Astro',	'2005-07-27 00:00:00.000',	4,	'Economy',	12.60),
('Toyota',	'Solara',	'2009-10-15 00:00:00.000',	7,	'Family',	13.80),
('Volvo',	'S40',	'2010-10-12 00:00:00.000',	3,	'Average',	11.30),
('Suzuki',	'Swift',	'2000-02-03 00:00:00.000',	7,	'Economy',	16.20)

Insert into dbo.Orders
(ClientId,	TownId,	VehicleId,	CollectionDate,	CollectionOfficeId,	ReturnDate,	ReturnOfficeId,	Bill, TotalMileage)
Values
(17,	2,	52,	'2017-08-08', 	30,	'2017-09-04', 	42,	2360.00,	7434),
(78,	1,	50,	'2017-04-22', 	10,	'2017-05-09', 	12,	2326.00,	7326),
(27,	1,	28,	'2017-04-25', 	21,	'2017-05-09', 	34,	597.00,	1880	)

--Problem_03
Update dbo.Models
Set Class = 'Luxury'
Where dbo.Models.Consumption > 20

--Problem_04
Delete From dbo.Orders
Where ReturnDate is null

--Problem_05
SELECT [Manufacturer]
      ,[Model]
   FROM [dbo].[Models]
   Order by Manufacturer, Id desc

--Problem_06
Select FirstName, LastName from dbo.Clients
Where Year(BirthDate) Between 1977 AND 1994
Order by FirstName, LastName, Id

--Problem_07
Select dbo.Towns.Name, dbo.Offices.Name, ParkingPlaces
From dbo.Offices
inner join dbo.Towns
on dbo.Towns.Id = dbo.Offices.TownId
Where ParkingPlaces > 25
Order by dbo.Towns.Name, dbo.Offices.Id

--Problem_08
Select m.Model, m.Seats, v.Mileage 
From dbo.Vehicles v
Inner join dbo.Models m
on m.Id = v.ModelId
Where v.Id NOT IN
	(Select VehicleId
	From dbo.Orders
	Where dbo.Orders.ReturnDate IS NULL)
Order by v.Mileage, m.Seats Desc, m.Id

--Problem_09
SELECT [dbo].[Towns].[Name]
	  ,Count(dbo.Offices.Id) as	OfficesNumber
  FROM [dbo].[Towns]
  Inner join [dbo].[Offices]
  on [dbo].[Offices].TownId = [dbo].[Towns].Id
  Group By [dbo].[Towns].[Name]
  Order by OfficesNumber desc, [dbo].[Towns].[Name]

--Problem_10
Select m.Manufacturer, m.Model, Count(o.Id) as TimesOrdered
from dbo.Vehicles v
INNER join dbo.Models m
on m.Id = v.ModelId
LEFT join dbo.Orders o
On o.VehicleId = v.Id
Group by m.Manufacturer, m.Model
Order by TimesOrdered desc, m.Manufacturer desc, m.Model

--Problem_11
WITH t AS
(Select o.ClientId 
	  ,m.Class as [Class]
	  ,COUNT(m.Class) as [Count]
From dbo.Orders o
Inner join dbo.Vehicles v on v.Id = o.VehicleId
Inner join dbo.Models m on m.Id = v.ModelId
Group by o.ClientId, m.Class)

SELECT Concat(c.FirstName, ' ', c.LastName) as [Full Name]
	  ,t2.Class
FROM
(Select t.*
		,DENSE_RANK() OVER (Partition By t.ClientId Order By t.Count DESC) as RNK
From t
Group by t.ClientId, t.Class, t.Count) t2
Inner join dbo.Clients c on c.Id = t2.ClientId
WHERE t2.RNK = 1
Order by [Full Name], t2.Class, t2.ClientId

--Problem_12
with t as
(Select  o.ClientId
		,CASE WHEN Year(c.BirthDate) >= 1970 AND Year(c.BirthDate) <= 1979 THEN '70'+char(39)+'s' 
		 WHEN Year(c.BirthDate) >= 1980  AND Year(c.BirthDate) <= 1989 THEN '80'+char(39)+'s'
		 WHEN Year(c.BirthDate) >= 1990 AND Year(c.BirthDate) <= 1999 THEN '90'+char(39)+'s'
		 ELSE 'Others' END as AgeGroup
		,o.Bill
		,v.Mileage
From dbo.Orders o
Inner join dbo.Clients c
On o.ClientId = c.Id
Inner join dbo.Vehicles v
On v.Id = o.VehicleId)

Select t.AgeGroup
		,SUM(t.Bill) as Revenue
		,AVG(t.Mileage) as AverageMileage
From t
Group By t.AgeGroup
GO

--Problem_13
WITH t AS
(Select TOP 7 m.Model, m.Id, avg(m.Consumption) as AverageConsumption 
From dbo.Orders o
Inner join dbo.Vehicles v On v.Id = o.VehicleId
Inner join dbo.Models m On m.Id = v.ModelId
Group By m.Model, m.Id
Order by COUNT(m.Model) DESC)

Select m.Manufacturer, CAST(m.Consumption as decimal(14, 6))
from t
Inner join dbo.Models m
on m.Id = t.Id
Where t.AverageConsumption Between 5 AND 15
GO

--Problem_17
Create Function udf_CheckForVehicle(@townName nvarchar(50), @seatsNumber int)
RETURNS nvarchar(max)
AS
	BEGIN
		Declare @result nvarchar(max) = 
			(SELECT TOP 1 CONCAT(o.Name, ' - ', m.Model)
			  FROM dbo.Vehicles v
			  Inner join [dbo].[Offices] o
			  on v.OfficeId = o.Id
			  Inner join dbo.Towns t
			  on t.Id = o.TownId
			  Inner join dbo.Models m
			  on m.Id = v.ModelId
			  Where t.Name = @townName
			  AND m.Seats = @seatsNumber
			  Order by o.Name);
		
		If (@@ROWCOUNT = 0)
			BEGIN
				RETURN 'NO SUCH VEHICLE FOUND';
			END
		
		RETURN @result;
	END
GO

--Problem_18
Create Procedure usp_MoveVehicle @vehicleId int, @officeId int
AS 
	BEGIN
		Declare @maxLots int = (SELECT o.ParkingPlaces
									  FROM [dbo].[Orders] ord
									  Inner join dbo.Offices o on ord.Id = o.TownId
									  where ord.ReturnDate IS NOT NULL
									  and o.Id = @officeId
									  Group By o.TownId
										  ,o.ParkingPlaces);

		Declare @vehicleOfficeId int = (Select OfficeId From dbo.Vehicles where Id = @vehicleId);

		Declare @occupiedLots int = (SELECT o.ParkingPlaces
									  FROM [dbo].[Orders] ord
									  Inner join dbo.Offices o on ord.Id = o.TownId
									  where ord.ReturnDate IS NOT NULL
									  and o.Id = @vehicleOfficeId
									  Group By o.TownId
										  ,o.ParkingPlaces);

		IF (@occupiedLots >= @maxLots)
			BEGIN 
				RAISERROR('Not enough room in this office!', 16, 1);
				RETURN;
			END
		ELSE
			BEGIN
				UPDATE dbo.Vehicles
				SET OfficeId = @officeId
				WHERE Id = @vehicleId
			END
	END
GO

--Problem_19
Create Trigger Tr_Custom
ON [dbo].Orders
FOR UPDATE
AS 
	BEGIN
		Declare @vehicleId int = (Select [VehicleId] from inserted);
		Declare @TotalMileage int = (Select [TotalMileage] from inserted);
		Declare @currentMileage int = (Select [Mileage] From [dbo].[Vehicles] Where Id = @vehicleId);

		--IF (@currentMileage = 0)
			BEGIN
				Update dbo.Vehicles
				Set Mileage += @TotalMileage
				Where Id = @vehicleId
			END
	END

