use hexaware;


create table Accounts(account_number BigInt primary Key, account_Type varchar(30),
account_balance decimal(18,2), owner varchar(30));

insert into Accounts values(101,'savings',1550,'Owner 1');
insert into Accounts values(102,'current',2000,'Owner 2');


create table Customer(customer_id int Unique,first_name varchar(30) unique,last_name varchar(30)unique,Email varchar(30)Unique,phone varchar(30)unique,customer_address varchar(50)unique);

insert into Customer values(1,'nim','siv','nims@mail.com','9786524347','24 North st'); 
insert into Customer values(2,'kumar','karthik','ks@mail.com','34545245432','23 south st');

create table Transactions(accountNo bigint,Transaction_description varchar(50),date_time dateTime,transaction_type varchar(50),transaction_amount decimal(18,2));

insert into Transactions values(1001,'EB bill','2000-12-03','gpay',1500);
insert into Transactions values(1002,'water bill','2023-10-05','paytm',2500);
insert into Transactions values(1003,'Wifi bill','2015-06-04','phonepe',3000);


select * from Transactions;
select * from Accounts;
select * from Customer;

drop table Customer
drop table Accounts
drop table Transactions
