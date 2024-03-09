create table Customers
(
	Customer_id serial primary key,
	Customer_name varchar,
	Email varchar,
	Address varchar
);




create table Products
(
	Product_id serial primary key,
	Product_name varchar,
	Price decimal,
	Stock_quantity int
);





create table Orders
(
	Order_id serial primary key,
	Customer_id int references Customers(customer_id),
	Order_date date,
	Total_amount decimal
);



create table OrderDetails
(
	Order_detail_id serial primary key,
	Order_id int references Orders(order_id),
	Product_id int references Products(product_id),
	Quantity int,
	Unit_price decimal
);


select c.Customer_id,c.Customer_name,c.Email,c.Address from Customers as c
join Orders as o on o.Customer_id = c.Customer_id
where o.Order_date >=  and o.Order_date <= 

select Sum(od.Quantity) from OrderDetails as od
where Product_id = @product_id


select c.Customer_id,c.Customer_name,c.Email,c.Address,Avg(o.Total_amount) as Avg from Customers as c
join Orders as o on o.Customer_id = c.Customer_id
group by  c.Customer_id


select * from Orders 
where Total_amount >
