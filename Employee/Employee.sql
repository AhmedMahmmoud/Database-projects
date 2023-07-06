
use Employee

select Employees.Name,Orders.Product 
from Employees,Orders
where Employees.Employee_ID =Orders.Employee_ID


SELECT Employees.Name
FROM Employees, Orders
WHERE Employees.Employee_ID=Orders.Employee_ID
AND Orders.Product='Printer'

select Employees.Name,Orders.Product
from Employees
inner join Orders
on Employees.Employee_ID=Orders.Employee_ID

select Employees.Name,Orders.Product
from Employees
full join Orders
on Employees.Employee_ID=Orders.Employee_ID

select MAX (Prod_ID) from Orders
select Min (Prod_ID) from Orders
select Avg (Prod_ID) from Orders
SELECT count (DISTINCT Employee_ID) From Orders

 
SELECT Employees.Name,Orders.Product 
INTO Empl_Ord_backup 
FROM Employees 
INNER JOIN Orders 
ON Employees.Employee_ID=Orders.Employee_ID 

select Employees.Name,Orders.Prod_ID,Orders.Product
into emnopidop_backup
from Employees
inner join Orders
on Employees.Employee_ID=Orders.Employee_ID

create view vWcoulmn_emp_proudct
as 
select Employees.Name,Orders.Product 
from Employees 
join Orders on
Employees.Employee_ID=Orders.Employee_ID

SELECT * FROM [coulmn_emp_proudct] 
sp_helptext coulmn_emp_proudct


