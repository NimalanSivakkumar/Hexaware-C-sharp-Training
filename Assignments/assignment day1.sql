--Creating database
create database HMBank1 
use HMBank1

--creating table for customers

create table customers(customer_id int constraint PK_CSID primary key NOT NULL, first_name varchar(20),last_name varchar(20),DOB DATE NOT NULL, email varchar(500) UNIQUE,phone_number varchar(50) UNIQUE NOT NULL , addresses varchar(150) NOT NULL );
insert into customers values (101,'kumar','jammy','2004-06-30','kumarjammy125@gmail.com',789632147,'chidambaram');
insert into customers values (102,'nimal','siva','2007-05-25','nimalsiva11001@gmail.com',874522448,'tambaram');
insert into customers values (103,'krithik','ms','2009-08-12','krithikms134@gmail.com',731546952,'chengalpattu');
insert into customers values (104,'mahirat','sharma','2005-02-10','mahiratsharma412@gmail.com',14789632,'cdm');
insert into customers values (105,'lucifer','kurup','2009-05-16','kurup399@gmail.com',452368422,'pkm');
select * from customers;

--creating table for accounts

create table Accounts(account_id int constraint PK_acid primary key NOT NULL, customer_ID int constraint FK_csid foreign key references customers(customer_id),account_type varchar(50),balance decimal(10,5) NOT NULL);
insert into accounts values (9878,105,'savings',259.30);
insert into accounts values (9875,102,'primary',260.30);
insert into accounts values (9876,103,'secondary',261.30);
insert into accounts values (9877,104,'tertiary',262.35);
select * from Accounts;

--creating table for Transactions 

create table Transactions( transaction_id int constraint PK_trid primary key NOT NULL, account_id int constraint FK_accid foreign key references Accounts(account_id),Transaction_type varchar(20) NOT NULL,amount decimal(8,2) NOT NULL,transaction_date date);
insert into Transactions values (8756,9878,'gpay',250.47,'2024-04-21');
insert into Transactions values (8757,9875,'paytm',456.42,'2025-06-30');
insert into Transactions values (8758,9876,'upi',450.44,'2025-02-21');
insert into Transactions values (8759,9877,'neft',375.66,'2025-03-31');
select * from Transactions;

