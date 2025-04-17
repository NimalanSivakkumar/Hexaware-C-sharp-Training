create database codingchallenge2
use codingchallenge2


create table  users (UserId int primary key ,
    UserName varchar(50) unique Not Null,
    Password varchar(50) unique Not Null,
    Role varchar(50) Not Null
);

create table policies( PolicyId int primary key,
PolicyName varchar(100) Not Null ,PolicyDuration DateTime Not Null,
PolicyAmount Decimal(10,2) Not Null);


create table clients(ClientId int primary key Not Null,
ClientName varchar(100) unique Not null,
ContactInfo varchar(100) Unique,
PolicyId int,
foreign key(PolicyId) references policies(PolicyId)
);

create table claims(ClaimId int primary key,
ClaimNuber varchar(50) Not Null,
DateFiled Date Not Null,
ClaimAmount Decimal(10,2) Not Null,
Status varchar(50) Not Null,
PolicyId int,
ClientId int,
foreign key (PolicyId) references policies(PolicyId),
foreign Key(ClientId) references clients(ClientId)
);

create table payments(PaymentId int primary Key,
PaymentDate Date Not null,
PaymentAmount Decimal(10,2) Not Null,
ClientId Int,
foreign Key(ClientId) references clients(ClientId)
);

select * from policies;
select * from users;
select * from clients;
select * from claims;
select * from payments;




drop table payments;
drop table claims;
drop table clients;
drop table policies;
drop table users



