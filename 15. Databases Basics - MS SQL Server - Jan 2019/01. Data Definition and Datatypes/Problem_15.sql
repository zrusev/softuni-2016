 CREATE DATABASE HOTEL

GO

USE HOTEL

GO

CREATE TABLE EMPLOYEES
  (
     ID         INT IDENTITY(1, 1) PRIMARY KEY
     ,FIRSTNAME NVARCHAR(255) NOT NULL
     ,LASTNAME  NVARCHAR(255) NOT NULL
     ,TITLE     NVARCHAR(255) NOT NULL
     ,NOTES     NVARCHAR(255) NULL
  )

CREATE TABLE CUSTOMERS
  (
     ACCOUNTNUMBER    INT
     ,FIRSTNAME       NVARCHAR(255) NOT NULL
     ,LASTNAME        NVARCHAR(255) NOT NULL
     ,PHONENUMBER     NVARCHAR(255) 
     ,EMERGENCYNAME   NVARCHAR(255)
     ,EMERGENCYNUMBER NVARCHAR(255)
     ,NOTES           NVARCHAR(255) NULL
  )

CREATE TABLE ROOMSTATUS
  (
     ROOMSTATUS NVARCHAR(255)
     ,NOTES     NVARCHAR(255) NULL
  )

CREATE TABLE ROOMTYPES
  (
     ROOMTYPE NVARCHAR(255)
     ,NOTES   NVARCHAR(255)
  )

CREATE TABLE BEDTYPES
  (
     BEDTYPE NVARCHAR(255)
     ,NOTES  NVARCHAR(255)
  )

CREATE TABLE ROOMS
  (
     ROOMNUMBER  NVARCHAR(255)
     ,ROOMTYPE   NVARCHAR(255)
     ,BEDTYPE    NVARCHAR(255)
     ,RATE       INT
     ,ROOMSTATUS NVARCHAR(255)
     ,NOTES      NVARCHAR(255) NULL
  )

CREATE TABLE PAYMENTS
  (
     ID                 INT IDENTITY(1, 1) PRIMARY KEY
     ,EMPLOYEEID        INT FOREIGN KEY REFERENCES EMPLOYEES(ID)
     ,PAYMENTDATE       DATE NOT NULL
     ,ACCOUNTNUMBER     NVARCHAR(255) NOT NULL
     ,FIRSTDATEOCCUPIED DATE
     ,LASTDATEOCCUPIED  DATE
     ,TOTALDAYS         INT
     ,AMOUNTCHARGED     DECIMAL(18, 2)
     ,TAXRATE           INT
     ,TAXAMOUNT         DECIMAL(18, 2)
     ,PAYMENTTOTAL      DECIMAL(18, 2)
     ,NOTES             NVARCHAR(255) NULL
  )

CREATE TABLE OCCUPANCIES
  (
     ID             INT IDENTITY(1, 1) PRIMARY KEY
     ,EMPLOYEEID    INT FOREIGN KEY REFERENCES EMPLOYEES(ID)
     ,DATEOCCUPIED  DATE 
     ,ACCOUNTNUMBER NVARCHAR(255)
     ,ROOMNUMBER    SMALLINT
     ,RATEAPPLIED   INT
     ,PHONECHARGE   DECIMAL(18, 2)
     ,NOTES         NVARCHAR(255) NULL
  )

INSERT INTO EMPLOYEES
            ([FIRSTNAME]
             ,[LASTNAME]
             ,[TITLE]
             ,[NOTES])
VALUES      ('[FirstName]'
             ,'[LastName]'
             ,'[Title]'
             ,'[Notes]'),
            ('[FirstName]'
             ,'[LastName]'
             ,'[Title]'
             ,'[Notes]'),
            ('[FirstName]'
             ,'[LastName]'
             ,'[Title]'
             ,'[Notes]')

INSERT INTO CUSTOMERS
            ([ACCOUNTNUMBER]
             ,[FIRSTNAME]
             ,[LASTNAME]
             ,[PHONENUMBER]
             ,[EMERGENCYNAME]
             ,[EMERGENCYNUMBER]
             ,[NOTES])
VALUES      (123454
             ,'[FirstName]'
             ,'[LastName]'
             ,'[PhoneNumber]'
             ,'[EmergencyName]'
             ,'[EmergencyNumber]'
             ,'[Notes]'),
            (123454
             ,'[FirstName]'
             ,'[LastName]'
             ,'[PhoneNumber]'
             ,'[EmergencyName]'
             ,'[EmergencyNumber]'
             ,'[Notes]'),
            (123454
             ,'[FirstName]'
             ,'[LastName]'
             ,'[PhoneNumber]'
             ,'[EmergencyName]'
             ,'[EmergencyNumber]'
             ,'[Notes]')

INSERT INTO ROOMSTATUS
            ([ROOMSTATUS]
             ,[NOTES])
VALUES      ('[RoomStatus]'
             ,'[Notes]'),
            ('[RoomStatus]'
             ,'[Notes]'),
            ('[RoomStatus]'
             ,'[Notes]')

INSERT INTO ROOMTYPES
            ([ROOMTYPE]
             ,[NOTES])
VALUES      ('[RoomType]'
             ,'[Notes]'),
            ('[RoomType]'
             ,'[Notes]'),
            ('[RoomType]'
             ,'[Notes]')

INSERT INTO ROOMS
            ([ROOMTYPE]
             ,[BEDTYPE]
             ,[RATE]
             ,[ROOMSTATUS]
             ,[NOTES])
VALUES      ( '[RoomType]'
              ,'BedType]'
              ,12314
              ,'RoomStatus]'
              ,'Notes]'),
            ( '[RoomType]'
              ,'BedType]'
              ,12314
              ,'RoomStatus]'
              ,'Notes]'),
            ( '[RoomType]'
              ,'BedType]'
              ,12314
              ,'RoomStatus]'
              ,'Notes]')

INSERT INTO PAYMENTS
            ([EMPLOYEEID]
             ,[PAYMENTDATE]
             ,[ACCOUNTNUMBER]
             ,[FIRSTDATEOCCUPIED]
             ,[LASTDATEOCCUPIED]
             ,[TOTALDAYS]
             ,[AMOUNTCHARGED]
             ,[TAXRATE]
             ,[TAXAMOUNT]
             ,[PAYMENTTOTAL]
             ,[NOTES])
VALUES      (1
             ,'2015-01-01'
             ,124341
             ,'2015-01-05'
             ,'2015-01-14'
             ,123
             ,13.4
             ,13.4
             ,12.3
             ,1414.3
             ,NULL),
            (1
             ,'2015-01-01'
             ,124341
             ,'2015-01-05'
             ,'2015-01-14'
             ,123
             ,13.4
             ,13.4
             ,12.3
             ,1414.3
             ,NULL),
            (1
             ,'2015-01-01'
             ,124341
             ,'2015-01-05'
             ,'2015-01-14'
             ,123
             ,13.4
             ,13.4
             ,12.3
             ,1414.3
             ,NULL)

INSERT INTO OCCUPANCIES
            ([EMPLOYEEID]
             ,[DATEOCCUPIED]
             ,[ACCOUNTNUMBER]
             ,[ROOMNUMBER]
             ,[RATEAPPLIED]
             ,[PHONECHARGE]
             ,[NOTES])
VALUES      (1
             ,'2018-01-05'
             ,'[AccountNumber]'
             ,13
             ,1414
             ,123.4
             ,NULL),
            (1
             ,'2018-01-05'
             ,'[AccountNumber]'
             ,13
             ,1414
             ,123.4
             ,NULL),
            (1
             ,'2018-01-05'
             ,'[AccountNumber]'
             ,13
             ,1414
             ,123.4
             ,NULL)  