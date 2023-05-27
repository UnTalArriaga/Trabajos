SELECT * FROM Products;
--Ejercicio 1
SELECT SupplierID, SUM(UnitsInStock) AS Stock FROM Products
GROUP BY SupplierID
ORDER BY Stock DESC
--Ejercicio 2
SELECT SupplierID, SUM(UnitsInStock * UnitPrice) AS Dinerita FROM Products
GROUP BY SupplierID
ORDER BY Dinerita DESC
--Ejercicio 3
SELECT SupplierID, count(*) AS #Orden FROM Products
WHERE UnitsOnOrder>0
GROUP BY SupplierID

SELECT * FROM Products
WHERE UnitsInStock=0 OR SupplierID=14
--Ejercicio 4
SELECT SupplierID, SUM(UnitsOnOrder * UnitPrice) AS Dinerita FROM Products
GROUP BY SupplierID
ORDER BY Dinerita DESC
--Ejercicio 5
SELECT CategoryID FROM Products
GROUP BY CategoryID
--Forma correcta
SELECT DISTINCT CategoryID FROM Products
--Ejercicio 6
SELECT CategoryID, COUNT(*) AS #ProdXCat FROM Products
GROUP BY CategoryID
--Ejercicio 7
SELECT CategoryID, SupplierID, SUM(UnitsInStock*UnitPrice) AS DineritaEnStock FROM Products
GROUP BY CategoryID, SupplierID
ORDER BY CategoryID ASC

--Ejercicio 8
SELECT CategoryID, SUM(ReorderLevel) AS NivelReOrder FROM Products
GROUP BY CategoryID

--Ejercicio 9
SELECT CategoryID, SupplierID, SUM(UnitsInStock*UnitPrice) AS DineritaEnStock FROM Products
GROUP BY CategoryID, SupplierID
HAVING SUM(UnitsInStock*UnitPrice)>3000
ORDER BY CategoryID ASC

--Ejercicio 10.a
SELECT CategoryID, COUNT(*) AS #ProdXCat, SUM(UnitsInStock*UnitPrice) AS Stock$ FROM Products
GROUP BY CategoryID
--Ejercicio 10.b
SELECT CategoryID, COUNT(*) AS #ProdXCat, SUM(UnitsInStock*UnitPrice) AS StockMoney FROM Products
GROUP BY CategoryID
HAVING COUNT(*) > 7
--Ejercicio 10.a
SELECT CategoryID, COUNT(*) AS #ProdXCat, SUM(UnitsInStock*UnitPrice) AS Stock$ FROM Products
GROUP BY CategoryID
HAVING SUM(UnitsInStock*UnitPrice) > 11000 AND COUNT(CategoryID) > 7
--Ejercicio 11
SELECT EmployeeID, ShipVia, COUNT(EmployeeID) AS  #ORDENES FROM Orders
GROUP BY EmployeeID, ShipVia
HAVING COUNT(EmployeeID) >30
ORDER BY EmployeeID ASC
--Ejercicio 12
SELECT OrderID, 
	SUM(UnitPrice*Quantity) AS SubTotal, 
	SUM(UnitPrice*Quantity*Discount) AS Descuento,
	SUM(UnitPrice*Quantity - Discount*UnitPrice*Quantity) AS Total,
	0.2*SUM(UnitPrice*Quantity) AS VeinteDescuento
FROM [Order Details]
GROUP BY OrderID
HAVING 	SUM(UnitPrice*Quantity*Discount) <= SUM(UnitPrice*Quantity)*0.2
ORDER BY SUM(UnitPrice*Quantity - Discount*UnitPrice*Quantity) DESC
--12.a
SELECT OrderID, 
	SUM(UnitPrice*Quantity) AS SubTotal, 
	SUM(UnitPrice*Quantity*Discount) AS Descuento,
	SUM(UnitPrice*Quantity - Discount*UnitPrice*Quantity) AS Total,
	0.2*SUM(UnitPrice*Quantity) AS VeinteDescuento
FROM [Order Details]
GROUP BY OrderID
HAVING 	(SUM(UnitPrice*Quantity*Discount) <= SUM(UnitPrice*Quantity)*0.2) AND SUM(UnitPrice*Quantity*Discount)>0
ORDER BY SUM(UnitPrice*Quantity - Discount*UnitPrice*Quantity) DESC
