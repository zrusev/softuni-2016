alter table users
drop constraint PK__ID_Username

alter table users
ADD CONSTRAINT PK_UserID PRIMARY KEY (ID)

alter table users
add constraint DF_Username_Constr CHECK (DATALENGTH(Username) >= 3)
