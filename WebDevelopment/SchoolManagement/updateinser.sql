--insert into student (name,address,email,dob,gender)
--values('gynendra bir bikram sha','ktm','prige@gmail.com','2020/11/15','f')

update student set Name='lalit' where id =2

select * from student where Gender='f' and  Address like'bhaktapur' 


--order student by their name
--select * from student order by Name desc

--find number of student living in each city alias==student as s
select s.address,count(*) as NumberOfStudents from student as s 
group by Address