create database Movies 
Go
use Movies
Go
create table Directors (
	Id int primary key identity not null, 
	DirectorName nvarchar(255), 
	Notes nvarchar(255)
);

create table Genres (
	Id int primary key identity not null, 
	GenreName nvarchar(255), 
	Notes nvarchar(255)
);

create table Categories (
	Id int primary key identity not null, 
	CategoryName nvarchar(255), 
	Notes nvarchar(255)
);

create table Movies (
	Id int primary key identity not null, 
	Title nvarchar(255), 
	DirectorId int not null, 
	CopyrightYear date, 
	Length int, 
	GenreId int not null, 
	CategoryId int not null, 
	Rating int, 
	Notes nvarchar(255)
);

alter table Movies
	add foreign key (DirectorId) REFERENCES Directors (Id);

alter table Movies
	add foreign key (GenreId) REFERENCES Genres (Id);

alter table Movies
	add foreign key (CategoryId) REFERENCES Categories (Id);


INSERT INTO Directors
(DirectorName, Notes)
values
(NEWID(), NEWID()),
(NEWID(), NEWID()),
(NEWID(), NEWID()),
(NEWID(), NEWID()),
(NEWID(), NEWID())

INSERT INTO Genres
(GenreName, Notes)
values
(NEWID(), NEWID()),
(NEWID(), NEWID()),
(NEWID(), NEWID()),
(NEWID(), NEWID()),
(NEWID(), NEWID())

INSERT INTO Categories
(CategoryName, Notes)
values
(NEWID(), NEWID()),
(NEWID(), NEWID()),
(NEWID(), NEWID()),
(NEWID(), NEWID()),
(NEWID(), NEWID())

INSERT INTO Movies
(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
values
(NEWID(), 1, '2018-01-01', 11, 2, 4, 55, 'String.Empty()'),
(NEWID(), 3, '2018-01-01', 11, 2, 4, 55, 'String.Empty()'),
(NEWID(), 4, '2018-01-01', 11, 2, 4, 55, 'String.Empty()'),
(NEWID(), 2, '2018-01-01', 11, 2, 4, 55, 'String.Empty()'),
(NEWID(), 3, '2018-01-01', 11, 2, 4, 55, 'String.Empty()')