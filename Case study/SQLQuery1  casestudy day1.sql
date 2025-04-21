
create database casestudy;
use casestudy;

create table customers (
    customer_id int primary key,
    name varchar(20) unique NOT NULL,
    email varchar(100) unique NOT NULL,
    password varchar(150) unique NOT NULL
);

insert into customers values (1,'nimal','nim01@gmail.com','Dea@123')
insert into customers values(2,'kumar','kp@mail.com','W123#')


create table products (
    product_id int primary key,
    name varchar(20) NOT NULL,
    price int NOT NULL,
    description varchar (1500),
    stockquantity int NOT NULL
);

insert into products values(1,'Bat',2000,'cricket items',2)



create table cart (
    cart_id int identity(1,1) primary key,
    customer_id int NOT NULL,
    product_id int NOT NULL,
    quantity int NOT NULL,
    foreign key (customer_id) references customers(customer_id)on delete cascade,
    foreign key (product_id) references products(product_id) on delete cascade
);


create table orders (
    order_id int identity(1,1) primary key,
    customer_id int NOT NULL,
    order_date DATETIME NOT NULL,
    total_price int NOT NULL,
    shipping_address varchar(200),
    foreign key (customer_id) references customers(customer_id) on delete cascade
);

create table order_items (
    order_item_id int identity(1,1) primary key,
    order_id int NOT NULL,
    product_id int NOT NULL,
    quantity int NOT NULL,
    foreign key (order_id) references orders(order_id) on delete cascade,
    foreign key (product_id) references products(product_id) on delete cascade
);

alter table orders
alter column total_price decimal (10, 2) NOT NULL;

alter table products
alter column price decimal(10,2) NOT NULL;

drop table order_items;





select * from customers;
select * from products;
select * from cart;
select * from orders;
select * from order_items;












