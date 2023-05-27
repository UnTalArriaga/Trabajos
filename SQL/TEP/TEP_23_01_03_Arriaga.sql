--EJERCICIO 1.A
SELECT SupplierID, SUM(UnitsInStock) AS TOTAL
FROM Products
GROUP BY SupplierID
ORDER BY TOTAL DESC
--EJERCICIO 1.B
SELECT CompanyName, SUM(UnitsInStock) AS TOTAL
FROM Products AS P, Suppliers AS S
WHERE P.SupplierID = S.SupplierID
GROUP BY CompanyName
ORDER BY TOTAL DESC

--EJERCICIO 2.A
SELECT CompanyName, COUNT(UnitsInStock) AS TOTAL
FROM Products AS P, Suppliers AS S
WHERE P.SupplierID = S.SupplierID
AND P.UnitsInStock >= 0
AND CategoryID = 4
GROUP BY CompanyName
ORDER BY TOTAL ASC

--EJERCICIO 2.B
SELECT SupplierID
FROM Products
GROUP BY SupplierID
HAVING SUM(UnitPrice*UnitsInStock) < SUM(UnitPrice*UnitsOnOrder)
ORDER BY SupplierID ASC

--EJERCICIO 3
SELECT CompanyName, MAX(UnitPrice) AS MAXIMO, MIN(UnitPrice) AS MINIMO
FROM Products AS P, Suppliers AS S
WHERE P.SupplierID = S.SupplierID
AND P.UnitsInStock >= 0
GROUP BY CompanyName
ORDER BY CompanyName ASC

--EJERCICIO 4
SELECT ProductName
FROM Products 
WHERE ProductName <> ALL 
(
	SELECT ProductName
	FROM Products AS P INNER JOIN [Order Details] AS OD ON P.ProductID = OD.ProductID
	INNER JOIN Orders AS O ON O.OrderID = OD.OrderID
	WHERE YEAR(O.OrderDate) = 1996
)

--EJERCICIO 5.A
SELECT CategoryName, SUM(OD.UnitPrice*OD.Quantity - P.UnitPrice*OD.Quantity) as PERDIDA
FROM Categories AS C INNER JOIN Products AS P ON C.CategoryID = P.CategoryID
INNER JOIN [Order Details] AS OD ON OD.ProductID = P.ProductID
GROUP BY CategoryName
ORDER BY PERDIDA ASC

--EJERCICIO 5.B
SELECT LastName, SUM(OD.UnitPrice*OD.Quantity - P.UnitPrice*OD.Quantity) as PERDIDA
FROM [Order Details] AS OD INNER JOIN Orders AS O ON O.OrderID = OD.OrderID
INNER JOIN Employees AS E ON E.EmployeeID = O.EmployeeID
INNER JOIN Products AS P ON P.ProductID = OD.ProductID
GROUP BY LastName
ORDER BY PERDIDA DESC
