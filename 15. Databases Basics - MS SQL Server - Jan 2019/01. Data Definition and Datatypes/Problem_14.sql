 CREATE DATABASE CARRENTAL

GO

USE CARRENTAL

GO

CREATE TABLE CATEGORIES
  (
     ID            INT IDENTITY(1, 1) NOT NULL PRIMARY KEY
     ,CATEGORYNAME NVARCHAR(255)
     ,DAILYRATE    INT
     ,WEEKLYRATE   INT
     ,MONTHLYRATE  INT
     ,WEEKENDRATE  INT
  )

CREATE TABLE CARS
  (
     ID            INT IDENTITY(1, 1) NOT NULL PRIMARY KEY
     ,PLATENUMBER  NVARCHAR(255)
     ,MANUFACTURER NVARCHAR(255)
     ,MODEL        NVARCHAR(255)
     ,CARYEAR      DATE
     ,CATEGORYID   INT
     ,DOORS        INT
     ,PICTURE      VARBINARY(MAX)
     ,CONDITION    NVARCHAR(255)
     ,AVAILABLE    BIT
  )

ALTER TABLE CARS
  ADD CONSTRAINT CHK_T_VARB__2MB CHECK (Datalength(PICTURE) <= 2097152);

CREATE TABLE EMPLOYEES
  (
     ID         INT IDENTITY(1, 1) NOT NULL PRIMARY KEY
     ,FIRSTNAME NVARCHAR(255)
     ,LASTNAME  NVARCHAR(255)
     ,TITLE     NVARCHAR(255)
     ,NOTES     NVARCHAR(255) NULL
  )

CREATE TABLE CUSTOMERS
  (
     ID                   INT IDENTITY(1, 1) NOT NULL PRIMARY KEY
     ,DRIVERLICENCENUMBER INT
     ,FULLNAME            NVARCHAR(255)
     ,ADDRESS             NVARCHAR(255) NULL
     ,CITY                NVARCHAR(255) NULL
     ,ZIPCODE             NVARCHAR(255) NULL
     ,NOTES               NVARCHAR(255) NULL
  )

CREATE TABLE RENTALORDERS
  (
     ID                INT IDENTITY(1, 1) NOT NULL PRIMARY KEY
     ,EMPLOYEEID       INT FOREIGN KEY REFERENCES EMPLOYEES(ID)
     ,CUSTOMERID       INT FOREIGN KEY REFERENCES CUSTOMERS(ID)
     ,CARID            INT FOREIGN KEY REFERENCES CARS(ID)
     ,TANKLEVEL        INT
     ,KILOMETRAGESTART INT
     ,KILOMETRAGEEND   INT
     ,TOTALKILOMETRAGE INT
     ,STARTDATE        DATETIME
     ,ENDDATE          DATETIME
     ,TOTALDAYS        INT
     ,RATEAPPLIED      INT
     ,TAXRATE          INT
     ,ORDERSTATUS      NVARCHAR(255)
     ,NOTES            NVARCHAR(255) NULL
  )

INSERT INTO CATEGORIES
            ([CATEGORYNAME]
             ,[DAILYRATE]
             ,[WEEKLYRATE]
             ,[MONTHLYRATE]
             ,[WEEKENDRATE])
VALUES      ('[CategoryName]'
             ,1
             ,1
             ,3
             ,4),
            ('[CategoryName]'
             ,1
             ,1
             ,3
             ,4),
            ('[CategoryName]'
             ,1
             ,1
             ,3
             ,4)

INSERT INTO CARS
            ([PLATENUMBER]
             ,[MANUFACTURER]
             ,[MODEL]
             ,[CARYEAR]
             ,[CATEGORYID]
             ,[DOORS]
             ,[PICTURE]
             ,[CONDITION]
             ,[AVAILABLE])
VALUES      ('BG123'
             ,'BMW'
             ,'3'
             ,'2015'
             ,1
             ,3
             ,NULL
             ,''
             ,1),
            ('BG123'
             ,'BMW'
             ,'3'
             ,'2015'
             ,1
             ,3
             ,NULL
             ,''
             ,1),
            ('BG123'
             ,'BMW'
             ,'3'
             ,'2015'
             ,1
             ,3
             ,NULL
             ,''
             ,1)

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
            ([DRIVERLICENCENUMBER]
             ,[FULLNAME]
             ,[ADDRESS]
             ,[CITY]
             ,[ZIPCODE]
             ,[NOTES])
VALUES      (1415151
             ,'[FullName'
             ,'[Address]'
             ,'[City]'
             ,'[ZIPCode]'
             ,'[Notes]'),
            (1415151
             ,'[FullName'
             ,'[Address]'
             ,'[City]'
             ,'[ZIPCode]'
             ,'[Notes]'),
            (1415151
             ,'[FullName'
             ,'[Address]'
             ,'[City]'
             ,'[ZIPCode]'
             ,'[Notes]')

INSERT INTO RENTALORDERS
            ([EMPLOYEEID]
             ,[CUSTOMERID]
             ,[CARID]
             ,[TANKLEVEL]
             ,[KILOMETRAGESTART]
             ,[KILOMETRAGEEND]
             ,[TOTALKILOMETRAGE]
             ,[STARTDATE]
             ,[ENDDATE]
             ,[TOTALDAYS]
             ,[RATEAPPLIED]
             ,[TAXRATE]
             ,[ORDERSTATUS]
             ,[NOTES])
VALUES      (1
             ,2
             ,1
             ,5
             ,123
             ,123
             ,15444
             ,'2015-01-05'
             ,'2016-07-08'
             ,123
             ,555
             ,13
             ,'OK'
             ,NULL),
            (1
             ,2
             ,1
             ,5
             ,123
             ,123
             ,15444
             ,'2015-01-05'
             ,'2016-07-08'
             ,123
             ,555
             ,13
             ,'OK'
             ,NULL),
            (1
             ,2
             ,1
             ,5
             ,123
             ,123
             ,15444
             ,'2015-01-05'
             ,'2016-07-08'
             ,123
             ,555
             ,13
             ,'OK'
             ,NULL)  