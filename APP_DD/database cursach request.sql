use APP 
CREATE TABLE FavoriteCars (
   Id INT PRIMARY KEY IDENTITY(1,1),
   UserId int,
   Users VARCHAR(MAX),
   CarId int,
);
CREATE TABLE Review (
   Id INT PRIMARY KEY IDENTITY(1,1),
   Comment VARCHAR(MAX),
);
go
Create TABLE Cars(
	Id INT PRIMARY KEY IDENTITY(1,1),
	model varchar(50),
	photo varchar(max),
	total int,
	IsNewOrNot bit,
	descriptionshort varchar(50),
	descriptionlarge varchar(max),
	);