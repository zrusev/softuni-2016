Create Database School
Go
Use School
Go

--Problem_01
Create Table Students(
	Id int not null Identity(1,1) Primary Key,
	FirstName nvarchar(30) not null,
	MiddleName nvarchar(25),
	LastName nvarchar(30) not null,
	Age TINYINT not null CHECK(AGE BETWEEN 5 AND 100),
	Address nvarchar(50),
	Phone nchar(10) 
)

Create Table Subjects(
	Id int not null Identity(1,1) Primary Key,
	Name nvarchar(20) not null,
	Lessons TINYINT not null Check(Lessons > 0)
)

Create Table StudentsSubjects(
	Id int not null Identity(1,1) Primary Key,
	StudentId int not null Foreign Key References Students(Id),
	SubjectId int not null Foreign Key References Subjects(Id),
	Grade decimal(18,2) not null Check(Grade Between 2.0 AND 6.0)
)

Create Table Exams(
	Id int not null Identity(1,1) Primary Key,
	Date DateTime,
	SubjectId int not null Foreign Key References Subjects(Id)
)

Create Table StudentsExams(
	StudentId int not null Foreign Key References Students(Id),
	ExamId int not null Foreign Key References Exams(Id),
	Grade decimal(18,2) not null Check(Grade Between 2.0 AND 6.0)
	Primary Key(StudentId, ExamId)
)

Create Table Teachers(
	Id int Identity(1,1) Primary Key,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	Address nvarchar(20) not null,
	Phone nchar(10),
	SubjectId int not null Foreign Key References Subjects(Id)
)

Create Table StudentsTeachers(
	StudentId int not null Foreign Key References Students(Id),
	TeacherId int not null Foreign Key References Teachers(Id),
	Primary Key (StudentId, TeacherId)
)

--Problem_02
Insert into Teachers
(FirstName,	LastName,	Address,	Phone,	SubjectId)
values
('Ruthanne',	'Bamb',	'84948 Mesta Junction'	,3105500146,	6),
('Gerrard',	'Lowin',	'370 Talisman Plaza'	,3324874824,	2),
('Merrile',	'Lambdin',	'81 Dahle Plaza'	,4373065154,	5),
('Bert',	'Ivie',	'2 Gateway Circle'	,4409584510,	4)

Insert into Subjects
(Name,	Lessons)
Values
('Geometry'	,12),
('Health'	,10),
('Drama'	,7),
('Sports'	,9)

--Problem_03
Update [dbo].[StudentsSubjects]
Set Grade = 6.00
WHERE Grade >= 5.50
And SubjectId IN (1,2)

--Problem_04
Delete
From StudentsTeachers
Where TeacherId IN
(SELECT Id
FROM dbo.Teachers
WHERE CHARINDEX('72', Phone, 1) > 0)

Delete
FROM dbo.Teachers
WHERE CHARINDEX('72', Phone, 1) > 0

--Problem_05
Select FirstName, LastName, Age
From dbo.Students s
Where Age >= 12
order by FirstName, LastName

--Problem_06
Select CONCAT(FirstName, ' ', MiddleName, ' ', LastName) as [Full Name] , Address
From dbo.Students
Where Address like '%road%'
order by FirstName, LastName, Address

--Problem_07
Select FirstName, Address, Phone
From dbo.Students
Where MiddleName IS Not NUll
And Phone like '42%'
Order by FirstName

--Problem_08
Select s.FirstName, s.LastName, Count(st.TeacherId)
From dbo.Students s
Inner join dbo.StudentsTeachers st
on st.StudentId = s.Id
Group By s.FirstName, s.LastName
GO

--Problem_09
Select CONCAT(t.FirstName, ' ', t.LastName) as [Full Name]
	  ,s.Name + '-' + Cast(Lessons as nvarchar(10)) as Subjects
	  ,Count(st.StudentId) as Students
From dbo.Teachers t
Inner Join dbo.Subjects s On t.SubjectId = s.Id
Inner join [dbo].[StudentsTeachers] st On st.TeacherId = t.Id
group By t.FirstName, t.LastName, s.Name, Lessons
order by Students desc

--Problem_10
Select FirstName + ' ' + LastName as [Full Name]
from dbo.Students s
Where s.Id not in
(Select StudentId
From dbo.Exams e
Left Join dbo.StudentsExams st
on e.Id = st.ExamId
Where st.ExamId is not null)
order by [Full Name] 

--Problem_11
Select TOP 10 t.FirstName
		,t.LastName
		, Count(st.StudentId) as StudentsCount
From dbo.StudentsTeachers st
Inner join dbo.Teachers t
on t.Id = st.TeacherId
Group By st.TeacherId, t.FirstName ,t.LastName
Order by StudentsCount Desc, t.FirstName, t.LastName

--Problem_12
Select TOP 10 s.FirstName, s.LastName, Cast(Avg(se.Grade) as decimal(18,2)) as Grade
From dbo.StudentsExams se
inner join dbo.Students s
on s.Id = se.StudentId
Group By s.FirstName, s.LastName
order by Grade desc, s.FirstName, s.LastName

--Problem_13
Select s.FirstName, s.LastName, t.Grade
From 
(SELECT [Id]
      ,[StudentId]
      ,[SubjectId]
      ,[Grade]
	  ,Row_Number() OVER (Partition By StudentId Order by Grade DESC) as Rnk
  FROM [dbo].[StudentsSubjects]) t
Inner join dbo.Students s on s.Id = t.StudentId
WHERE t.Rnk = 2
order by s.FirstName, s.LastName
GO

--Problem_14
Select CONCAT(s.FirstName, Case when s.MiddleName Is null Then ' ' Else ' ' + s.MiddleName + ' ' End, s.LastName) as [Full Name]
From dbo.Students s
left join dbo.StudentsSubjects ss
on ss.StudentId = s.Id
Where ss.StudentId is null
Order by [Full Name]

--Problem_15
SELECT
    data.[Teacher Full Name],
    data.[Subject Name],
    data.[Student Full Name],
    CAST(data.AVGrade AS decimal(18,2)) AS Grade
FROM(
        SELECT
            t.FirstName + ' ' + t.LastName AS [Teacher Full Name],
            sub.[Name] AS [Subject Name],
            s.FirstName + ' ' + s.LastName AS [Student Full Name],
            DENSE_RANK() OVER (PARTITION BY t.FirstName ORDER BY AVG(ss.Grade) DESC) AS GradeRank,
            AVG(ss.Grade) AS AVGrade
        FROM Teachers AS t
        JOIN Subjects AS sub ON sub.Id = t.SubjectId
        JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
        JOIN Students AS s ON s.Id = st.StudentId
        JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id AND ss.SubjectId = sub.Id
        GROUP BY t.FirstName, t.LastName, sub.[Name], s.FirstName, s.LastName
    ) AS data
WHERE data.GradeRank = 1   
ORDER BY data.[Subject Name], data.[Teacher Full Name], data.AVGrade DESC

--Problem_16
Select s.Name, Avg(ss.Grade)
From dbo.StudentsSubjects ss
inner join dbo.Subjects s
on s.Id = ss.SubjectId
Group By ss.SubjectId, s.Name
Order by ss.SubjectId

--Problem_17
Select   [Quarter]
		,SubjectName
		,COUNT(se.StudentId) as StudentsCount
From
(SELECT Case when Month([Date]) >= 1 AND Month([Date]) <= 3 THEN 'Q1'
			WHEN Month([Date]) >= 4 AND Month([Date]) <= 6 THEN 'Q2'
			WHEN Month([Date]) >= 7 AND Month([Date]) <= 9 THEN 'Q3'
			WHEN Month([Date]) >= 10 AND Month([Date]) <= 12 THEN 'Q4'
			ELSE 'TBA' END as [Quarter]
	  ,s.Name as SubjectName
	  ,e.Id
  FROM [dbo].[Exams] e
  inner join [dbo].[Subjects] s on e.SubjectId = s.Id) t
  Inner join dbo.StudentsExams se on se.ExamId = t.Id
  where se.Grade >= 4.00
  Group By Quarter, SubjectName
order by [Quarter]
Go

--Problem_18
Create function dbo.udf_ExamGradesToUpdate(@studentId int, @grade decimal(18,2))
RETURNS nvarchar(max)
AS
	BEGIN
		Declare @exists int = (Select count(*) from dbo.Students where Id = @studentId);

		If (@exists = 0)
			BEGIN 
				Return 'The student with provided id does not exist in the school!';
			END 

		If (@grade > 6.00)
			BEGIN
				Return 'Grade cannot be above 6.00!';
			END

		Declare @topGrade decimal(18,2) = @grade + 0.50;

		Declare @totalCount int = (SELECT COUNT(*)
									  FROM [dbo].[StudentsExams]
									  Where StudentId = @studentId
									  And Grade Between @grade AND @topGrade);

		Declare @firstName nvarchar(50) = (  Select FirstName From dbo.Students Where Id = @studentId);

		Return 'You have to update ' + Cast(@totalCount as nvarchar(10)) + ' grades for the student ' + @firstName
	END
GO

--Problem_19
Create Procedure dbo.usp_ExcludeFromSchool @StudentId int
AS 
	BEGIN
		Declare @exists int = (Select Count(*) From dbo.Students where Id = @StudentId);

		If (@exists = 0)
			BEGIN
				RAISERROR('This school has no student with the provided id!', 16, 1);
				RETURN;
			END
		
		  Delete from dbo.StudentsExams Where StudentId = @StudentId;
		  Delete from dbo.StudentsSubjects where StudentId = @StudentId;
		  Delete from dbo.StudentsTeachers Where StudentId = @StudentId;
		  Delete From dbo.Students Where Id = @StudentId;
	END
GO

--Problem_20
Create Table ExcludedStudents(
	StudentId int, 
	StudentName nvarchar(30)
)
Go

Create Trigger TR_Exclude
ON Students
AFTER DELETE
AS
	BEGIN
		Insert into ExcludedStudents
		(StudentId, StudentName)
		Select Id, FirstName + ' ' + LastName
		From deleted;
	END
