Create Database TripService;
GO
USE TripService;
GO

--Problem_01 
CREATE TABLE CITIES 
             ( 
                          ID            INT PRIMARY KEY IDENTITY(1,1), 
                          [NAME]        NVARCHAR(20) NOT NULL, 
                          [COUNTRYCODE] CHAR(2) NOT NULL 
             )CREATE TABLE HOTELS 
             ( 
                          ID            INT PRIMARY KEY IDENTITY(1,1), 
                          [NAME]        NVARCHAR(30) NOT NULL, 
                          CITYID        INT NOT NULL FOREIGN KEY REFERENCES CITIES(ID), 
                          EMPLOYEECOUNT INT NOT NULL, 
                          BASERATE      DECIMAL(18,2) 
             )CREATE TABLE ROOMS 
             ( 
                          ID      INT PRIMARY KEY IDENTITY(1,1), 
                          PRICE   DECIMAL(18,2) NOT NULL, 
                          [TYPE]  NVARCHAR(20) NOT NULL, 
                          BEDS    INT NOT NULL, 
                          HOTELID INT NOT NULL FOREIGN KEY REFERENCES HOTELS(ID) 
             )CREATE TABLE TRIPS 
             ( 
                          ID          INT PRIMARY KEY IDENTITY(1,1), 
                          ROOMID      INT NOT NULL FOREIGN KEY REFERENCES ROOMS(ID), 
                          BOOKDATE    DATE NOT NULL, 
                          ARRIVALDATE DATE NOT NULL, 
                          RETURNDATE  DATE NOT NULL, 
                          CANCELDATE  DATE, 
                          CONSTRAINT [BKDATE] CHECK (BOOKDATE < ARRIVALDATE), 
                          CONSTRAINT [ARVDATE] CHECK (ARRIVALDATE < RETURNDATE), 
             )CREATE TABLE ACCOUNTS 
             ( 
                          ID         INT PRIMARY KEY IDENTITY(1,1), 
                          FIRSTNAME  NVARCHAR(50) NOT NULL, 
                          MIDDLENAME NVARCHAR(20), 
                          LASTNAME   NVARCHAR(50) NOT NULL, 
                          CITYID     INT NOT NULL FOREIGN KEY REFERENCES CITIES(ID), 
                          BIRTHDATE  DATE NOT NULL, 
                          EMAIL      VARCHAR(100) NOT NULL UNIQUE 
             )CREATE TABLE ACCOUNTSTRIPS 
             ( 
                          ACCOUNTID INT NOT NULL FOREIGN KEY REFERENCES ACCOUNTS(ID), 
                          TRIPID    INT NOT NULL FOREIGN KEY REFERENCES TRIPS(ID), 
                          LUGGAGE   INT NOT NULL DEFAULT 0, 
                          PRIMARY KEY (ACCOUNTID, TRIPID), 
                          CONSTRAINT CK_LUGGAGE CHECK (LUGGAGE >= 0) 
             ) 

--Problem_02
INSERT INTO DBO.ACCOUNTS 
            ( 
                        FIRSTNAME, 
                        MIDDLENAME, 
                        LASTNAME, 
                        CITYID, 
                        BIRTHDATE, 
                        EMAIL 
            ) 
            VALUES 
            ( 
                        'John', 
                        'Smith', 
                        'Smith', 
                        34, 
                        '1975-07-21', 
                        'j_smith@gmail.com' 
            ) 
            , 
            ( 
                        'Gosho', 
                        NULL, 
                        'Petrov', 
                        11, 
                        '1978-05-16' , 
                        'g_petrov@gmail.com' 
            ) 
            , 
            ( 
                        'Ivan', 
                        'Petrovich', 
                        'Pavlov', 
                        59, 
                        '1849-09-26', 
                        'i_pavlov@softuni.bg' 
            ) 
            , 
            ( 
                        'Friedrich', 
                        'Wilhelm', 
                        'Nietzsche', 
                        2, 
                        '1844-10-15', 
                        'f_nietzsche@softuni.bg' 
            )INSERT INTO DBO.TRIPS 
            ( 
                        ROOMID, 
                        BOOKDATE, 
                        ARRIVALDATE, 
                        RETURNDATE, 
                        CANCELDATE 
            ) 
            VALUES 
            ( 
                        101, 
                        '2015-04-12', 
                        '2015-04-14', 
                        '2015-04-20', 
                        '2015-02-02' 
            ) 
            , 
            ( 
                        102, 
                        '2015-07-07', 
                        '2015-07-15', 
                        '2015-07-22', 
                        '2015-04-29' 
            ) 
            , 
            ( 
                        103, 
                        '2013-07-17', 
                        '2013-07-23', 
                        '2013-07-24', 
                        NULL 
            ) 
            , 
            ( 
                        104, 
                        '2012-03-17', 
                        '2012-03-31', 
                        '2012-04-01', 
                        '2012-01-10' 
            ) 
            , 
            ( 
                        109, 
                        '2017-08-07', 
                        '2017-08-28', 
                        '2017-08-29', 
                        NULL 
            ) 

--Problem_03
UPDATE [DBO].[ROOMS] 
SET    PRICE = PRICE * 1.14 
WHERE  HOTELID      IN (5,7,9) 
--Problem_04DELETE 
FROM   [DBO].[ACCOUNTSTRIPS] 
WHERE  ACCOUNTID = 47 

--Problem_05
SELECT   [ID] , 
         [NAME] 
FROM     [DBO].[CITIES] 
WHERE    [COUNTRYCODE] = 'BG' 
ORDER BY [NAME] 

--Problem_06
SELECT   CONCAT(FIRSTNAME, ' ' + MIDDLENAME, ' ', LASTNAME) AS [Full Name] , 
         Year([BIRTHDATE]) 
FROM     [DBO].[ACCOUNTS] 
WHERE    Year(BIRTHDATE) > 1991 
ORDER BY Year(BIRTHDATE) DESC, 
         FIRSTNAME 

--Problem_07
SELECT     [FIRSTNAME] , 
           [LASTNAME] , 
           FORMAT([BIRTHDATE], 'MM-dd-yyyy') , 
           DBO.CITIES.NAME , 
           [EMAIL] 
FROM       [DBO].[ACCOUNTS] 
INNER JOIN DBO.CITIES 
ON         DBO.CITIES.ID = CITYID 
WHERE      [EMAIL] LIKE 'e%' 
ORDER BY   DBO.CITIES.NAME DESC 

--Problem_08
SELECT    C.NAME, 
          Count(H.ID) AS Cities 
FROM      CITIES C 
LEFT JOIN HOTELS H 
ON        C.ID = H.CITYID 
GROUP BY  C.ID, 
          C.NAME 
ORDER BY  CITIES DESC, 
          C.NAME 

--Problem_09
SELECT     DBO.ROOMS.[ID] , 
           [PRICE] , 
           DBO.HOTELS.NAME , 
           DBO.CITIES.NAME 
FROM       [DBO].[ROOMS] 
INNER JOIN DBO.HOTELS 
ON         DBO.HOTELS.ID = HOTELID 
INNER JOIN DBO.CITIES 
ON         DBO.CITIES.ID = CITYID 
WHERE      TYPE = 'First Class' 
ORDER BY   PRICE DESC, 
           DBO.ROOMS.ID 

--Problem_10
SELECT     T.ID , 
                      CONCAT(A.FIRSTNAME, ' ', A.LASTNAME) AS [Full Name] , 
           T.LONGESTTRIP , 
           T.SHORTESTTRIP 
FROM       ( 
                      SELECT     A.[ID] , 
                                 Max(Datediff(DAY, [ARRIVALDATE] ,[RETURNDATE])) AS LongestTrip , 
                                 Min(Datediff(DAY, [ARRIVALDATE] ,[RETURNDATE])) AS ShortestTrip 
                      FROM       [DBO].[ACCOUNTS] A 
                      INNER JOIN [DBO].[ACCOUNTSTRIPS] AT 
                      ON         AT.ACCOUNTID = A.ID 
                      INNER JOIN [DBO].[TRIPS] T 
                      ON         T.ID = AT.TRIPID 
                      WHERE      T.CANCELDATE IS NULL 
                      AND        A.MIDDLENAME IS NULL 
                      GROUP BY   A.ID) T 
INNER JOIN DBO.ACCOUNTS A 
ON         A.ID = T.ID 
ORDER BY   T.LONGESTTRIP DESC, 
           T.ID 

--Problem_11
SELECT TOP 5 
           C.ID , 
           C.NAME , 
           C.COUNTRYCODE , 
           Count(C.ID) 
FROM       [DBO].[ACCOUNTS] A 
INNER JOIN [DBO].[CITIES] C 
ON         C.ID = A.CITYID 
GROUP BY   C.COUNTRYCODE, 
           C.NAME, 
           C.ID 
ORDER BY   Count(C.ID) DESC 

--Problem_12
SELECT     A.ID , 
           A.EMAIL , 
           C.NAME , 
           Count(A.ID) 
FROM       [DBO].[ACCOUNTSTRIPS] AT 
INNER JOIN [DBO].[ACCOUNTS] A 
ON         A.ID = AT.ACCOUNTID 
INNER JOIN [DBO].[CITIES] C 
ON         C.ID = A.CITYID 
INNER JOIN DBO.TRIPS T 
ON         T.ID = AT.TRIPID 
INNER JOIN DBO.ROOMS R 
ON         R.ID = T.ROOMID 
INNER JOIN DBO.HOTELS H 
ON         H.ID = R.HOTELID 
WHERE      A.CITYID = H.CITYID 
GROUP BY   A.ID, 
           A.EMAIL, 
           C.NAME 
ORDER BY   Count(A.ID) DESC, 
           A.ID 

--Problem_13
SELECT TOP 10 
         C.ID, 
         C.NAME, 
         Sum(H.BASERATE + R.PRICE) AS [Total Revenue], 
         Count(*)                  AS Trips 
FROM     CITIES C 
JOIN     HOTELS H 
ON       C.ID = H.CITYID 
JOIN     ROOMS R 
ON       H.ID = R.HOTELID 
JOIN     TRIPS T 
ON       R.ID = T.ROOMID 
WHERE    Year(T.BOOKDATE) = 2016 
GROUP BY C.ID, 
         C.NAME 
ORDER BY [TOTAL REVENUE] DESC, 
         TRIPS DESC 

--Problem_14
SELECT     T.ID , 
           H.NAME , 
           R.TYPE , 
           CASE 
                      WHEN T.CANCELDATE IS NOT NULL THEN 0 
                      ELSE Sum(R.PRICE + H.BASERATE) 
           END AS Revenue 
FROM       DBO.TRIPS T 
INNER JOIN DBO.ROOMS R 
ON         R.ID = T.ROOMID 
INNER JOIN DBO.HOTELS H 
ON         H.ID = R.HOTELID 
INNER JOIN ACCOUNTSTRIPS AT 
ON         T.ID = AT.TRIPID 
GROUP BY   T.ID , 
           H.NAME , 
           R.TYPE , 
           T.CANCELDATE 
ORDER BY   R.TYPE, 
           T.ID 

--Problem_15
SELECT   ACCOUNTID, 
         EMAIL, 
         COUNTRYCODE, 
         TRIPS 
FROM     ( 
                  SELECT   A.ID AS AccountId, 
                           A.EMAIL, 
                           C.COUNTRYCODE, 
                           Count(*)                                                                      AS Trips,
                           DENSE_RANK() OVER ( PARTITION BY C.COUNTRYCODE ORDER BY Count(*) DESC, A.ID ) AS Rank
                  FROM     ACCOUNTS A 
                  JOIN     ACCOUNTSTRIPS AT 
                  ON       A.ID = AT.ACCOUNTID 
                  JOIN     TRIPS T 
                  ON       AT.TRIPID = T.ID 
                  JOIN     ROOMS R 
                  ON       T.ROOMID = R.ID 
                  JOIN     HOTELS H 
                  ON       R.HOTELID = H.ID 
                  JOIN     CITIES C 
                  ON       H.CITYID = C.ID 
                  GROUP BY C.COUNTRYCODE, 
                           A.EMAIL, 
                           A.ID) AS RANKSPERCOUNTRY 
WHERE    RANK = 1 
ORDER BY TRIPS DESC, 
         ACCOUNTID 

--Problem_16
SELECT   [TRIPID] , 
         Sum(LUGGAGE) AS Luggage , 
         '$' + Cast( 
         CASE 
                  WHEN Sum(LUGGAGE) > 5 THEN Sum(LUGGAGE) * 5 
                  ELSE 0 
         END AS VARCHAR(10)) AS Fee 
FROM     [DBO].[ACCOUNTSTRIPS] 
GROUP BY TRIPID 
HAVING   Sum(LUGGAGE) > 0 
ORDER BY LUGGAGE DESC 

--Problem_17
SELECT   T.ID, 
                  CONCAT(A.FIRSTNAME, ' ' + A.MIDDLENAME, ' ', A.LASTNAME) AS [Full Name], 
         AC.NAME                                                           AS [From], 
         HC.NAME                                                           AS [To], 
         CASE 
                  WHEN CANCELDATE IS NOT NULL THEN 'Canceled' 
                  ELSE CONCAT(Datediff(DAY, T.ARRIVALDATE, T.RETURNDATE), ' days') 
         END   AS Duration 
FROM     TRIPS AS T 
JOIN     ACCOUNTSTRIPS AT 
ON       T.ID = AT.TRIPID 
JOIN     ACCOUNTS A 
ON       AT.ACCOUNTID = A.ID 
JOIN     ROOMS R 
ON       T.ROOMID = R.ID 
JOIN     HOTELS H 
ON       R.HOTELID = H.ID 
JOIN     CITIES HC 
ON       H.CITYID = HC.ID 
JOIN     CITIES AC 
ON       A.CITYID = AC.ID 
ORDER BY [FULL NAME], 
         T.ID 

--Problem_18
CREATE FUNCTION UDF_GETAVAILABLEROOM(@HOTELID INT, @DATE DATE, @PEOPLE INT) RETURNS VARCHAR(MAX) AS BEGIN
DECLARE @BOOKEDROOMS TABLE 
                           ( 
                                                      ID INT 
                           ) 
INSERT INTO @BOOKEDROOMS 
SELECT DISTINCT R.ID 
FROM            ROOMS R 
LEFT JOIN       TRIPS T 
ON              R.ID = T.ROOMID 
WHERE           R.HOTELID = @HOTELID 
AND             @DATE BETWEEN T.ARRIVALDATE AND             T.RETURNDATE 
AND             T.CANCELDATE IS NULL 
DECLARE @ROOMS TABLE 
                     ( 
                                          ID         INT, 
                                          PRICE      DECIMAL(15, 2), 
                                          TYPE       VARCHAR(20), 
                                          BEDS       INT, 
                                          TOTALPRICE DECIMAL(15, 2) 
                     ) 
INSERT INTO @ROOMS 
SELECT TOP 1 
          R.ID, 
          R.PRICE, 
          R.TYPE, 
          R.BEDS, 
          @PEOPLE * (H.BASERATE + R.PRICE) AS TotalPrice 
FROM      ROOMS R 
LEFT JOIN HOTELS H 
ON        R.HOTELID = H.ID 
WHERE     R.HOTELID = @HOTELID 
AND       R.BEDS >= @PEOPLE 
AND       R.ID NOT IN 
          ( 
                 SELECT ID 
                 FROM   @BOOKEDROOMS) 
ORDER BY  TOTALPRICE DESC 
DECLARE @ROOMCOUNT INT = 
( 
       SELECT Count(*) 
       FROM   @ROOMS) 
IF (@ROOMCOUNT < 1) 
BEGIN 
  RETURN 'No rooms available' 
END 
DECLARE @RESULT VARCHAR(MAX) = 
( 
       SELECT CONCAT('Room ', ID, ': ', TYPE, ' (', BEDS, ' beds) - ', '$', TOTALPRICE) 
       FROM   @ROOMS) 
RETURN @RESULT 
END 

--Problem_19
CREATE PROCEDURE DBO.USP_SWITCHROOM 
  @TRIPID       INT, 
  @TARGETROOMID INT 
ASDECLARE @TARGETHOTELID INT = 
  ( 
             SELECT     R.[HOTELID] 
             FROM       [DBO].[ROOMS] R 
             INNER JOIN [DBO].[TRIPS] 
             ON         [DBO].[TRIPS].ROOMID = R.ID 
             WHERE      [DBO].[TRIPS].ID = @TRIPID);DECLARE @ROOMHOTELID INT = 
  ( 
         SELECT R.HOTELID 
         FROM   [DBO].[ROOMS] R 
         WHERE  R.ID = @TARGETROOMID);IF (@TARGETHOTELID != @ROOMHOTELID) 
  BEGIN 
    RAISERROR('Target room is in another hotel!', 16, 1); 
  ENDDECLARE @TRIPACCOUNTS INT = 
  ( 
         SELECT Count(*) 
         FROM   ACCOUNTSTRIPS 
         WHERE  TRIPID = @TRIPID);DECLARE @ROOMBEDS INT = 
  ( 
         SELECT R.BEDS 
         FROM   [DBO].[ROOMS] R 
         WHERE  R.ID = @TARGETROOMID);IF (@TRIPACCOUNTS > @ROOMBEDS) 
  BEGIN 
    RAISERROR('Not enough beds in target room!', 16, 1); 
  ENDUPDATE TRIPS 
  SET    ROOMID = @TARGETROOMID 
  WHERE  ID = @TRIPID 

--Problem_20
CREATE TRIGGER T_CANCELTRIP 
  ON TRIPS INSTEAD OF 
  DELETE AS BEGIN 
  UPDATE TRIPS 
  SET    CANCELDATE = Getdate() 
  WHERE  ID IN 
         ( 
                SELECT ID 
                FROM   DELETED 
                WHERE  CANCELDATE IS NULL) 
END