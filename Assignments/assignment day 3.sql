create database hmbank3
use hmbank3

--creating table for customers

create table customers(customer_id int constraint PK_CSID primary key NOT NULL,
first_name varchar(20),
last_name varchar(20),
DOB DATE NOT NULL, 
email varchar(500) UNIQUE,
phone_number varchar(20) UNIQUE NOT NULL , addresses varchar(150) NOT NULL );

insert into customers values (101,'kumar','jammy','2004-06-30','kumarjammy125@gmail.com','789632147','chidambaram');
insert into customers values (102,'nimal','siva','2007-05-25','nimalsiva11001@gmail.com','874522448','tambaram');
insert into customers values (103,'krithik','ms','2009-08-12','krithikms134@gmail.com','731546952','chengalpattu');
insert into customers values (104,'mahirat','sharma','2005-02-10','mahiratsharma412@gmail.com','14789632','cdm');
insert into customers values (105,'lucifer','kurup','2009-05-16','kurup399@gmail.com','452368422','pkm');
insert into customers values (106,'alice','sam','2003-07-23','alicesam@gmail.com','7854123681','ooty');
insert into customers values (107,'bob','rahul','2008-02-18','bobrahul@gmail.com','1245789635','kunnur');
insert into customers values (108,'sammy','brad','2009-03-26','sammybrad@gmail.com','8521463975','swizz');
insert into customers values (109,'kevin','kon','2003-05-26','kevinkon@gmail.com','7531598426','delhi');
insert into customers values (110,'sachin','peterson','2001-01-11','sson@gmail.com','7863145290','punjab');

select * from customers;

--creating table for accounts

create table Accounts(account_id int constraint PK_acid primary key NOT NULL,
customer_ID int constraint FK_csid foreign key references customers(customer_id),
account_type varchar(50),
balance decimal(10,5) NOT NULL);

insert into Accounts values (9878,105,'savings',259.30);
insert into Accounts values (9875,102,'current',260.30);
insert into Accounts values (9876,103,'zero_balance',261.30);
insert into Accounts values (9877,104,'savings',000.00);
insert into Accounts values (9871,101,'current',257.32);
insert into Accounts values (9872,106,'zero_balance',275.38);
insert into Accounts values (9873,107,'savings',268.25);
insert into Accounts values (9874,108,'current',250.15);
insert into Accounts values (9879,109,'zero_balance',282.75);
insert into Accounts values (9880,110,'savings',292.85);

insert into Accounts values(9580,104,'current',278.69);

alter table Accounts alter column balance decimal(10,5)
insert into Accounts values (9869,108,'current',1250.15);
insert into Accounts values (9889,102,'current',2260.30);

select * from Accounts;

--creating table for Transactions 

create table Transactions( transaction_id int constraint PK_trid primary key NOT NULL, 
account_id int constraint FK_accid foreign key references Accounts(account_id),
Transaction_type varchar(20) NOT NULL,
amount decimal(8,2) NOT NULL,
transaction_date date);

insert into Transactions values (8756,9878,'deposit',250.47,'2024-04-21');
insert into Transactions values (8757,9875,'withdraw',456.42,'2025-06-30');
insert into Transactions values (8758,9876,'transfer',450.44,'2025-02-21');
insert into Transactions values (8759,9877,'deposit',375.66,'2025-03-31');
insert into Transactions values (8751,9871,'withdraw',377.26,'2021-01-21');
insert into Transactions values (8752,9872,'transfer',389.56,'2027-08-21');
insert into Transactions values (8753,9873,'deposit',458.98,'2028-01-12');
insert into Transactions values (8754,9874,'withdraw',371.86,'2029-06-22');
insert into Transactions values (8755,9879,'transfer',475.12,'2026-07-06');
insert into Transactions values (8780,9880,'deposit',575.76,'2014-08-18');

select * from Transactions

alter table Transactions add constraint FFK_accid foreign key (account_id) references Accounts(account_id) on delete cascade;


 --Tasks 3: Aggregate functions, Having, Order By, GroupBy and Joins:
 --1. Write a SQL query to Find the average account balance for all customers.
 select avg(balance) as average_balance_all from  Accounts;

 --2. Write a SQL query to Retrieve the top 10 highest account balances.  
 select top 10* from Accounts order by balance desc 

 --3. Write a SQL query to Calculate Total Deposits for All Customers in specific date.
 select sum(amount) from Transactions where Transaction_type ='deposit' and transaction_date = '2028-01-12'

 --4. Write a SQL query to Find the Oldest and Newest Customers.
 select  min(customer_id) as oldest_customer ,max(customer_id) as new_customer from customers

 --5. Write a SQL query to Retrieve transaction details along with the account type
 select t.transaction_id,a.account_type from Transactions t join Accounts a on t.account_id = a.account_id;

 --6. Write a SQL query to Get a list of customers along with their account details
 select c.first_name,c.last_name,a.account_type,a.balance from customers c join Accounts a on a.customer_ID = c.customer_ID 

 --7. Write a SQL query to Retrieve transaction details along with customer information for a specific account.
 select t.transaction_id,t.Transaction_type,t.account_id,t.amount,c.first_name,c.last_name from customers c 
 join Accounts a on c.customer_id = a.customer_ID
 join Transactions t on t.account_id = a.account_id where a.account_id = 9875

 --8. Write a SQL query to Identify customers who have more than one account.
 select c.first_name,c.last_name,count(a.account_id) as acc_count  from customers c join Accounts a on a.customer_ID = c.customer_ID  group by c.first_name,c.last_name,a.account_id having count(a.account_id)>1

 --9. Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals.
 select account_id,sum(case when transaction_type = 'deposit' then amount else 0 end) - 
 sum(case when transaction_type = 'withdrawal' then amount else 0 end) as b_diff
 from Transactions group by account_id;

 --10. Write a SQL query to Calculate the average daily balance for each account over a specified period
 select a.account_id,avg(a.balance) as average_balance from Accounts a join Transactions t on a.account_id = t.account_id
 where t.transaction_date between '2014-08-18' and '2025-06-30'group by (a.account_id)

 --11. Calculate the total balance for each account type.
 select account_type, sum(balance) as total_balance from Accounts group by account_type;

 --12. Identify accounts with the highest number of transactions order by descending order.
 select t.account_id,count(t.transaction_id) as high_num_trans from Transactions t group by t.account_id order by (high_num_trans)desc;

 --13. List customers with high aggregate account balances, along with their account types
 select c.first_name,c.last_name,a.account_type,sum(a.balance) as high_balance from customers c join Accounts a on a.customer_ID = c.customer_ID  
 group by c.first_name,c.last_name,a.account_type,c.customer_ID order by  high_balance desc;

 --14. Identify and list duplicate transactions based on transaction amount, date, and account.
 select t.amount,t.transaction_date,t.account_id from Transactions t group by t.amount,t.transaction_date,t.account_id having count(*)>1


 --Tasks 4: Subquery and its type:
 --1. Retrieve the customer(s) with the highest account balance
 select * from customers where customer_id in (select customer_id from Accounts where balance = (select max(balance) from Accounts));

 --2. Calculate the average account balance for customers who have more than one account.
 select avg(a.balance) as average_acc_balance from Accounts a where a.account_id in (select t.account_id from Transactions t group by (t.account_id) having count(t.account_id)>1);

 --3. Retrieve accounts with transactions whose amounts exceed the average transaction amount.
 select transaction_id,Transaction_type from Transactions where amount>(select avg(amount ) from Transactions);

 --4. Identify customers who have no recorded transactions.
 select c.customer_id,c.first_name,c.last_name from customers c where c.customer_id not in(select customer_id from Transactions);

 --5. Calculate the total balance of accounts with no recorded transactions.
  select sum(balance) as total_balance from Accounts   where account_id not in (select account_id from Transactions )

  --6. Retrieve transactions for accounts with the lowest balance.
  select transaction_id from Transactions where account_id in (select account_id from Accounts where balance = (select min(balance) from Accounts));

--7. Identify customers who have accounts of multiple types.
select c.first_name,c.last_name from customers c where c.customer_id in (select a.customer_ID from Accounts a group by a.customer_id having count(a.account_id)>1);

--8. Calculate the percentage of each account type out of the total number of accounts.
select a.account_type,count(a.account_id) as acc_count, (count(a.account_id)*100/(select count(*) from Accounts)) as percentage_total
from Accounts a group by a.account_type

--9. Retrieve all transactions for a customer with a given customer_id.
select t.transaction_id,t.transaction_type from Transactions t where t.account_id in (select a.account_id from Accounts a group by a.customer_ID,account_id having customer_id='105');

--10. Calculate the total balance for each account type, including a subquery within the SELECT clause.
select a.account_type,sum(a.balance) as total_balance from Accounts a group by a.account_type


