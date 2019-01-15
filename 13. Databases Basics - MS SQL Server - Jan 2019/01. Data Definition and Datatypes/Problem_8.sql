Create table Users (
	ID BIGINT not null primary key IDENTITY,
	Username UNIQUEIDENTIFIER default NEWID() not null,
	Password nvarchar(26),
	ProfilePicture varBinary(MAX),
	LastLoginTime datetime,
	IsDeleted bit
)

ALTER TABLE Users ADD CONSTRAINT CHK_T_VarB__900Kb CHECK (DATALENGTH(ProfilePicture) <= 900);

insert into Users
(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
values
(default, '123', null, GETDATE(), 1),
(default, '123', null, GETDATE(), 1),
(default, '123', null, GETDATE(), 1),
(default, '123', null, GETDATE(), 1),
(default, '123', null, GETDATE(), 1)
