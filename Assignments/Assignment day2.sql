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


 --Write a SQL query to retrieve the name, account type and email of all customers.  
 select first_name,last_name,email from customers;

  --Write a SQL query to list all transaction corresponding customer.
  select transaction_id,account_id,Transaction_type from Transactions group by customers

  --Write a SQL query to increase the balance of a specific account by a certain amount.
  update Accounts set balance = balance + 1300 where customer_ID = 105
  select* from Accounts


  --. Write a SQL query to Combine first and last names of customers as a full_name.
 select concat(first_name,'',last_name)  as full_name from customers;

 --Write a SQL query to remove accounts with a balance of zero where the account type is savings.
 delete from Accounts where balance = 0.00 and account_type = 'savings' ;
 select * from Accounts

  --Write a SQL query to Find customers living in a specific city.
  select*from customers where addresses = 'chidambaram';

   --Write a SQL query to Get the account balance for a specific account.
   select account_id,balance from Accounts where account_id=9878

   --. Write a SQL query to List all current accounts with a balance greater than $1,000
   select account_id from Accounts where account_type = 'current' and balance>=1000;

    --Write a SQL query to Retrieve all transactions for a specific account.
	select * from Transactions where amount = 250.47

--	Write a SQL query to Calculate the interest accrued on savings accounts based on a given interest rate.
 --interest = balance*interest_rate
  select account_id  ,balance ,(balance*2) as interest_accrued from Accounts where account_type = 'savings';

  --Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit.
  select account_id from Accounts where balance <290.00;

  --Write a SQL query to Find customers not living in a specific city. 
  select* from customers where addresses !='chidambaram'









