-- create procedure Insert
create proc InsertEmp_SP
@EmpID int ,
@EmpName nvarchar(50),
@City nvarchar(50),
@Age float,
@sex nvarchar(20),
@JoiningData nvarchar(max),
@Contact nvarchar(50)
as
begin 
insert into EmpTest_Tab(Emp_ID,Emp_Name,City,Age,Sex,JoiningDate,Contact)
values (@EmpID,@EmpName,@City,@Age,@sex,@JoiningData,@Contact)
end

-- Example
 exec InsertEmp_SP 1002,'Ismail','Giza',20,'Male','2/2/2024','0103456'


 --Get all records
 create proc ListEmp_SP
as
begin 
select * from EmpTest_Tab
end
----------------
exec ListEmp_SP


--Create Update Stored Procedure
create proc UpdateEmp_SP
@EmpID int ,
@EmpName nvarchar(50),
@City nvarchar(50),
@Age float,
@sex nvarchar(20),
@JoiningData nvarchar(max),
@Contact nvarchar(50)
as
begin 
update EmpTest_Tab set Emp_Name=@EmpName,City=@City,Age=@Age,Sex=@sex,JoiningDate=@JoiningData,Contact=@Contact where Emp_ID=@EmpID
end

--Delete 
create proc DeleteEmp_SP
@EmpID int

as
begin 
delete EmpTest_Tab  where Emp_ID=@EmpID
end
 -- Load Specific Employee
 create proc LoadEmp_SP
@EmpID int

as
begin 
Select * from EmpTest_Tab  where Emp_ID=@EmpID
end
