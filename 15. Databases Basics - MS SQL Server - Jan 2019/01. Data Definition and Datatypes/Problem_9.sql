alter table Users 
DROP CONSTRAINT PK__Users__3214EC279743B80A;

alter table Users 
ADD CONSTRAINT PK__ID_Username  PRIMARY KEY CLUSTERED (ID, Username)   