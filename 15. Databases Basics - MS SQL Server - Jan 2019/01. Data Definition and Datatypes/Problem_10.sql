alter table Users
add constraint DF_Pass_Constr CHECK (DATALENGTH(Password) >= 5)