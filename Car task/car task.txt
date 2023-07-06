create database car_task
use car_task

-- DMl Select, insert ,delete, update
-- DQL select (Join,Order by ,.....)
-- DDL Create Alter Drop 


-- DDL (Create DB,T) (Alter T) ,(DropDB,T) 
--Batch = series of one or more statements submitted and executed at the same time.

create table customers
(customer_id int PRIMARY KEY,
customer_name nvarchar(50))
--insert values
insert into customers (customer_id,customer_name) values (1,'Ahmed')
insert into customers (customer_id,customer_name) values (2,'Mohamed')
insert into customers (customer_id,customer_name) values (3,'Mahmoud')
insert into customers (customer_id,customer_name) values (4,'Osama')
insert into customers (customer_id,customer_name) values (5,'Samir')


-- Multivalue
--composite primary key
create table cus_phone 
(customer_id int,
phone_number int,
PRIMARY KEY (customer_id , phone_number))

--insert values
insert into cus_phone (customer_id,phone_number) values (1,01012)
insert into cus_phone (customer_id,phone_number) values (1,01211)
insert into cus_phone (customer_id,phone_number) values (2,01013)
insert into cus_phone (customer_id,phone_number) values (3,01214)
insert into cus_phone (customer_id,phone_number) values (4,01215)


-- Multivalue
--composite primary key
create table cus_email
(customer_id int,
email_address nvarchar(100),
PRIMARY KEY(customer_id,email_address))

--insert values 
insert into cus_email (customer_id,email_address) values (1,'Ahmed@gmail.com')
insert into cus_email (customer_id,email_address) values (1,'Ahmed@Yahoo.com')
insert into cus_email (customer_id,email_address) values (2,'Mohamed@gmail.com')
insert into cus_email (customer_id,email_address) values (3,'Mahmoud@gmail.com')
insert into cus_email (customer_id,email_address) values (5,'samir@gmail.com')

create table cars
(car_id int PRIMARY KEY,
car_model nvarchar(50),
car_color nvarchar(50),
car_price decimal(18,6))
--insert values 
insert into cars (car_id,car_model,car_color,car_price) values (1,'Toyota','red', 1.500000)
insert into cars (car_id,car_model,car_color,car_price) values (2,'Mercedes-Benz','black', 2.100000)
insert into cars (car_id,car_model,car_color,car_price) values (3,'BMW','blue', 3.100000)
insert into cars (car_id,car_model,car_color,car_price) values (4,'Kia','white', 1.100000)
insert into cars (car_id,car_model,car_color,car_price) values (5,'Ford','green',1.700000)
insert into cars (car_id,car_model,car_color,car_price) values (6,'Audi','green',1.800000)

--composite primary key
create table cus_cars
(car_id int,
customer_id int,
PRIMARY KEY(car_id,customer_id))
--insert values
insert into cus_cars(customer_id,car_id) values (1,1)
insert into cus_cars(customer_id,car_id) values (1,2)
insert into cus_cars(customer_id,car_id) values (2,1)
insert into cus_cars(customer_id,car_id) values (2,3)
insert into cus_cars(customer_id,car_id) values (3,2)
insert into cus_cars(customer_id,car_id) values (3,3)


create table employees 
(employee_id int PRIMARY KEY,
employee_name nvarchar(50))

insert into employees (employee_id,employee_name) values (1,'Emp1')
insert into employees (employee_id,employee_name) values (2,'Emp2')
insert into employees (employee_id,employee_name) values (3,'Emp3')
insert into employees (employee_id,employee_name) values (4,'Emp4')

--composite primary key
create table car_employee
(car_id int,
employee_id int,
PRIMARY KEY(car_id,employee_id))
 --insert values
 insert into car_employee (car_id,employee_id) values (1,1)
 insert into car_employee (car_id,employee_id) values (1,2)
 insert into car_employee (car_id,employee_id) values (2,1)
 insert into car_employee (car_id,employee_id) values (2,3)


create table invoices
(
primary key (invoice_id ,customer_id ,car_id ,employee_id),
invoice_id int ,
purchase_date date,
payment_amount decimal(18,4) ,
service_description nvarchar(255),
customer_id int,
car_id int,
employee_id int,

FOREIGN KEY(customer_id) REFERENCES customers (customer_id),
FOREIGN KEY (car_id) REFERENCES cars (car_id),
FOREIGN KEY (employee_id) REFERENCES employees (employee_id))





 insert into invoices (invoice_id,purchase_date,payment_amount,service_description,car_id,customer_id,employee_id) values (1,'2023-1-4',1.100000,'good',1,1,1)
 insert into invoices (invoice_id,purchase_date,payment_amount,service_description,car_id,customer_id,employee_id) values (2,'2023-2-4',1.500000,'Excellent',1,2,1)
 insert into invoices (invoice_id,purchase_date,payment_amount,service_description,car_id,customer_id,employee_id) values (3,'2023-1-2',1.700000,'good',2,2,3)
 insert into invoices (invoice_id,purchase_date,payment_amount,service_description,car_id,customer_id,employee_id) values (4,'2023-3-4',1.100000,'Very good',2,1,3)


---------------- Alter(ADD or Drop) and Drop ------
 ALTER TABLE customers ADD City varchar(30) 
 ALTER TABLE customers drop City 
 -- Drop Table 
 -- Drop Table Table name
 -- DROP DATABASE database_name 










 -- DMl Select, insert ,delete, update
 
 select purchase_date,payment_amount,employee_id from invoices
 where customer_id=1

 select  customers.customer_name ,cars.car_model
 from customers , cars
 where customers.customer_id =cars.car_id

 select email_address from cus_email
 where customer_id=1

 -- Revision DML select 
 select customer_name from customers -- Single columns such that Select related to columns
 select customer_name,customer_id from customers --  Multiple columns
 -- select * from customers -- Another Transact SQL Statment
select distinct customer_name from customers -- Not redundency 
select cars.car_model from cars where car_model ='BMW' -- Where related to Row
select car_model from cars where car_id = 1
select car_id from cars where car_id <>2 -- Using operator <> Not Equal

/* Using Like
- %a End a 
- a% begin a
- %a% Contain a */
select * from employees WHERE employee_name like '%m%' 
select * from employees WHERE employee_name like '%3'
select * from cars where car_id between 1 and 3 -- using between (Range)

 -- Revision DML insert into
 insert into customers values (7,'Omar') -- General
 -- Inserting Multiple Rows of Data  (Row Constructor)
 insert into customers values (8,'Fawzi') , (10,'Mohaned') 

 insert into customers (customer_id) values (9) -- specific column 
   
 -- Revision DML Update
-- update one column
UPDATE customers SET customer_name = 'Mona' WHERE customer_id = 9 
-- update more than one column
UPDATE invoices SET service_description = 'Bad',payment_amount= 1.300 WHERE invoice_id = 4 

-- Revision DML Delete
DELETE FROM customers WHERE customer_id = 10 -- Delete Row (Done)
-- Delete * from ....... To Delete Table

--DELETE using a Subquery
DELETE FROM customers WHERE customer_id 
IN 
(SELECT customer_id FROM customers WHERE customer_id= 9) -- Done
-- In = Determine the value to display if you are sure it exists
SELECT customer_name FROM customers WHERE customer_name IN ('Ahmed','Mohamed') 

-- Delete Table = Delete Table (Entire) and don not keep Structure
-- TrunCate Tabbe = Delete (Data) and keep Structure
--Truncate table (TableName)






-- DQl  
SELECT car_model, car_color FROM cars ORDER BY car_model -- By Deafult ASC
SELECT car_model, car_color FROM cars ORDER BY car_model DESC


select invoices.purchase_date ,invoices.payment_amount ,customers.customer_name
 from invoices 
 inner join customers
 on customers.customer_id = invoices.invoice_id
