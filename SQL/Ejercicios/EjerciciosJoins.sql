--1
SELECT O.OrderID, O.Discount, P.ProductName 
FROM [Order Details] AS O, Products AS P
WHERE O.ProductID = P.ProductID
--2
SELECT P.ProductName, S.CompanyName
FROM Products AS P, Suppliers AS S
WHERE P.SupplierID = S.SupplierID
ORDER BY S.CompanyName
--3
SELECT SUM(P.UnitPrice*P.UnitsInStock) AS MoneyStock, S.CompanyName
FROM Products AS P, Suppliers AS S
WHERE P.SupplierID = S.SupplierID
GROUP BY S.CompanyName
--4
SELECT C.Description
FROM [Order Details] AS O, Products AS P, Categories AS C
WHERE	O.ProductID = P.ProductID AND
		P.CategoryID = C.CategoryID
--5
SELECT	O.ShipCountry, 
		SUM((OD.UnitPrice*OD.Quantity)-(OD.UnitPrice*OD.Quantity*Discount))
		AS DineroTotal
FROM Orders AS O, [Order Details] AS OD
WHERE O.OrderID = OD.OrderID
GROUP BY O.ShipCountry
ORDER BY SUM((OD.UnitPrice*OD.Quantity)-(OD.UnitPrice*OD.Quantity*Discount)) DESC
--6
SELECT O.OrderID, O.ProductID, P.ProductName, 
		O.UnitPrice AS PrecioOrden, P.UnitPrice AS PrecioProducto
FROM [Order Details] AS O, Products AS P
WHERE	P.ProductID = O.ProductID AND
		O.UnitPrice <> P.UnitPrice
--6A
SELECT COUNT(DISTINCT O.OrderID) AS NumOrdenes
FROM [Order Details] AS O, Products AS P
WHERE	P.ProductID = O.ProductID AND
		O.UnitPrice <> P.UnitPrice
--6B
SELECT O.OrderID, COUNT(DISTINCT O.ProductID) AS NumErrores
FROM [Order Details] AS O, Products AS P
WHERE	P.ProductID = O.ProductID AND
		O.UnitPrice <> P.UnitPrice
GROUP BY O.OrderID
--7
SELECT S.CompanyName, SUM(Quantity) AS TotalUnidades
FROM Suppliers AS S, Products AS P, [Order Details] AS OD
WHERE	S.SupplierID = P.SupplierID AND
		P.ProductID = OD.ProductID
GROUP BY S.CompanyName
ORDER BY SUM(Quantity) DESC

--8
SELECT O.OrderID, SUM((O.UnitPrice-P.UnitPrice)*O.Quantity) AS Perdida
FROM [Order Details] AS O, Products AS P
WHERE	P.ProductID = O.ProductID AND
		O.UnitPrice <> P.UnitPrice
GROUP BY O.OrderID
ORDER BY SUM((O.UnitPrice-P.UnitPrice)*O.Quantity) ASC

--9
SELECT	O.ShipCountry, 
		SUM(OD.Quantity) AS ProdTotal
FROM Orders AS O, [Order Details] AS OD
WHERE O.OrderID = OD.OrderID
GROUP BY O.ShipCountry
ORDER BY SUM(OD.Quantity) DESC
--10
SELECT O.ShipCountry, COUNT(DISTINCT OD.ProductID) AS CANTIDAD
FROM Orders AS O, [Order Details] AS OD
WHERE	O.OrderID = OD.OrderID 
GROUP BY O.ShipCountry
ORDER BY COUNT(DISTINCT OD.ProductID) DESC
--11

SELECT O.ShipCountry, P.ProductName, SUM (OD.Quantity) AS ProductoMenosOrdenado
FROM Orders AS O, [Order Details] AS OD, Products AS P
WHERE	O.OrderID = OD.OrderID AND P.ProductID=OD.ProductID 
GROUP BY O.ShipCountry, P.ProductName
HAVING  SUM (OD.Quantity) =
	(
	SELECT MIN(SUB.MINIMO)
	FROM 
		(
		SELECT O. ShipCountry, P.ProductName, SUM(OD.Quantity) AS MINIMO
		FROM Orders AS O, [Order Details] AS OD, Products AS P
		WHERE	O.OrderID = OD.OrderID AND P.ProductID=OD.ProductID 
		GROUP BY O.ShipCountry, P.ProductName
		--ORDER BY O.ShipCountry, MINIMO
		)AS SUB
	WHERE O.ShipCountry=SUB.ShipCountry
	)
ORDER BY O.ShipCountry 
