alter table Users
ADD CONSTRAINT DF_Users_created_date DEFAULT GETDATE() FOR LastLoginTime