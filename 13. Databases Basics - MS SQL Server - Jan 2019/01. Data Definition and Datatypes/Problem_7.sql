create table People (
	Id int not null primary key,
	[Name] nvarchar(200) not null,
	Picture varBinary(MAX),
	Height decimal(18, 2),
	[Weight] decimal(18, 2),
	Gender char (1) NOT NULL,
	Birthdate date not null,
	Biography nvarchar(MAX)
)

ALTER TABLE People ADD CONSTRAINT CHK_T_VarB__2MB CHECK (DATALENGTH(Picture) <= 2097152);

INSERT INTO People
(Id, [Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
values
(1, 'Gosho', (SELECT * FROM OPENROWSET(BULK '~\index.jpg', SINGLE_BLOB) as Picture), 12314.32, 12334.23, 'm', '2018-01-01', 'something nice'),
(2, 'Gosha', (SELECT * FROM OPENROWSET(BULK '~\index.jpg', SINGLE_BLOB) as Picture), 12314.32, 12334.23, 'f', '2018-01-01', 'something nice'),
(3, 'Pesho', (SELECT * FROM OPENROWSET(BULK '~\index.jpg', SINGLE_BLOB) as Picture), 12314.32, 12334.23, 'f', '2018-01-01', 'something nice'),
(4, 'Pesha', (SELECT * FROM OPENROWSET(BULK '~\index.jpg', SINGLE_BLOB) as Picture), 12314.32, 12334.23, 'm', '2018-01-01', 'something nice'),
(5, 'Dam', (SELECT * FROM OPENROWSET(BULK '~\index.jpg', SINGLE_BLOB) as Picture), 12314.32, 12334.23, 'f', '2018-01-01', 'something nice')
