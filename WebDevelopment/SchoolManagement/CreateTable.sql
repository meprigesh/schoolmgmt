create table student
(
Id int not null identity(1,1) primary key ,--primary key (identity(1,1) starts from 1 and increse by 1
Name nvarchar(50) not null,
Address nvarchar(200),
email varchar(50),
Dob datetime2,
Gender  char(1)
);