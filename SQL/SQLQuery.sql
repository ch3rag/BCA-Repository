create database npgcbca3

use npgcbca3

--deleting table
drop table Student

--creating table
create table Student(stu_id int not null primary key,
					 stu_name varchar(25),
					 stu_fname varchar(25),
					 stu_contact bigint,
					 stu_dob datetime,
					 );
-- adding new column
alter table Student add stu_class varchar(20)

--mm/dd/yyyy
insert into Student values(717000, 'Chirag Singh Rajput', 'D.C. Rajput', 9839427124, '08/29/1997', 'B.C.A.');
insert into Student values(717001, 'Saloni Singh', 'ABCD', 7685432190, '04/22/1998', 'B.C.A.');
insert into Student values(717002, 'Prathmesh Rai', 'S.H Rai', 6625435160, '08/05/1999', 'B.C.A.');
insert into Student values(717003, 'Abhay Yadav', 'N.H Yadav', 6895235564, '08/23/1999', 'B.C.A.');
insert into Student values(717004, 'Harsh Gupta', 'G.L. Gupta', 793254524, '06/13/1999', 'B.C.A.');
insert into Student values(717006, 'Trivendra Gupta', 'P.J. Gupta', 233254524, '03/12/1997', 'B.C.A.');
insert into Student values(717005, 'Sarvesh Rawat', 'K.S. Rawat', 712253224, '12/12/1998', 'B.C.A.');
insert into Student values(717007, 'Rakesh Singh', 'P.S. Singh', 9865431789, '11/29/1998', 'B.C.A.');
insert into Student values(717008, 'Ravi Kumar', 'B.L. Kumar', 9898765467, '09/27/1998', 'B.C.A.');
insert into Student values(717009, 'Mayur Mishra', 'S.L. Mishra', 7828765467, '09/27/1998', 'B.C.A.');
select * from Student

--updating
update Student set stu_contact = 9987665678 where stu_id = 717004
update Student set stu_contact = 9247665678 where stu_id = 717005
update Student set stu_contact = 9277767688 where stu_id = 717006

--distinct
select distinct stu_class from Student


--where
select * from student where stu_id = 717000
select * from student where stu_id <> 717001
select * from student where stu_id between 717001 and 717006
--starts whith a
select * from student where stu_name like 'a%'
--having 'a' as second character
select * from student where stu_name like '_a%'
--have 'a' as second character and ends with 'h'
select * from student where stu_name like '_a%h'

insert into student(stu_id, stu_name, stu_fname, stu_contact, stu_class) values(616001, 'Kumar Abhishek', 'S.L. Kumar', 9898787867, 'B.Sc.')

-- Null
select * from student where stu_dob is not null
select * from student where stu_dob is null

