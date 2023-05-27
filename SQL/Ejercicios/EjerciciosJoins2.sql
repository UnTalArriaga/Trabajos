--1
SELECT
	C.CategoryName,
	TEMP.MinPrecio,
	TEMP.MaxPrecio
FROM
(
	SELECT
		P.CategoryID,
		MIN(P.UnitPrice) as MinPrecio,
		MAX(P.UnitPrice) as MaxPrecio
	FROM Products P
	GROUP BY P.CategoryID
) AS TEMP,
Categories C 
WHERE TEMP.CategoryID = C.CategoryID;
--2
SELECT TEMP.EmployeeID AS ID, E.LastName AS APELLIDO, TEMP.NumOrdenes
FROM
(
SELECT O.EmployeeID, count(O.OrderID) AS NumOrdenes
FROM Orders O
GROUP BY O.EmployeeID
) AS TEMP,
Employees AS E
WHERE TEMP.EmployeeID = E.EmployeeID
ORDER BY TEMP.NumOrdenes DESC;
--3
SELECT S.CompanyName, SUM(OD.Quantity) AS COMPRADOS
FROM Customers AS S, Orders AS P, [Order Details] AS OD
WHERE S.CustomerID=P.CustomerID AND P.OrderID=OD.OrderID
GROUP BY S.CompanyName
ORDER BY COMPRADOS DESC
--4
SELECT C.CustomerID, C.CompanyName, O.OrderID, O.OrderDate
FROM Customers AS C LEFT JOIN Orders AS O 
ON C.CustomerID = O.CustomerID 
ORDER BY O.OrderID;
--5
SELECT C.CustomerID, C.CompanyName, O.OrderID, O.OrderDate
FROM Customers AS C RIGHT JOIN Orders AS O 
ON C.CustomerID = O.CustomerID 
ORDER BY O.OrderID;
