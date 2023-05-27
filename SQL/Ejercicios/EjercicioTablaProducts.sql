SELECT * FROM products;
--1
SELECT * FROM Products
WHERE UnitPrice=18 OR UnitPrice=17 OR UnitPrice=34;
--2
SELECT * FROM Products
WHERE UnitPrice>40 AND Discontinued=1 AND UnitsInStock<>0 ;
--3
SELECT Products.ProductName, Products.SupplierID FROM Products
WHERE UnitsInStock<10 AND UnitsOnOrder=0;
--4
SELECT * FROM Products
WHERE UnitsOnOrder>0
--5
SELECT * FROM Products
WHERE UnitsInStock<ReorderLevel AND UnitsOnOrder=0;
--6
SELECT * FROM Products
WHERE (UnitsInStock>100 AND UnitPrice>100) OR (UnitPrice<20 AND UnitsInStock>100 AND SupplierID=1);
--7
SELECT * FROM Products
WHERE SupplierID=5 AND UnitsOnOrder>0;
--8
SELECT * FROM Products
WHERE QuantityPerUnit like '%oz%';
--9
SELECT * FROM Products
WHERE QuantityPerUnit like '%bags%' OR QuantityPerUnit like '%boxes%';
--10
SELECT Products.UnitPrice, Products.ProductName FROM Products
WHERE UnitPrice like '%.00';
--11
SELECT * FROM Products
WHERE UnitsInStock>ReorderLevel AND UnitsOnOrder>0;
--12
SELECT * FROM Products
WHERE QuantityPerUnit like '%boxes%' AND QuantityPerUnit like '%pieces%';
--13 A cuantas ciudades diferentes hemos realizado envios o vendido algo
SELECT COUNT (DISTINCT Orders.ShipCity) FROM Orders;