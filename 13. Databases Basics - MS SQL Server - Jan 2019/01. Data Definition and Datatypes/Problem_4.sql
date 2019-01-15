INSERT INTO dbo.Towns
(Id, [Name])
values
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna');

INSERT INTO dbo.Minions 
(Id,[Name],Age,TownId)
values
(1,	'Kevin',	22,	1),
(2,	'Bob',	15,	3),
(3,	'Steward',	NULL,	2)