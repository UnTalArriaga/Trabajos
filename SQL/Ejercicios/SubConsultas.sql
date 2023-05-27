--1
	SELECT * FROM Products
	WHERE CategoryID IN 
	(
	SELECT CategoryID FROM Products
	GROUP BY CategoryID
	HAVING SUM(UnitsInStock)>350
	);

--2
	SELECT * FROM Products
	WHERE CategoryID IN
	(
	SELECT CategoryID FROM Products
	GROUP BY CategoryID
	HAVING SUM(UnitPrice*UnitsInStock)>= 3500 AND SUM(UnitPrice*UnitsInStock)<=4000
	)

--3
	SELECT CategoryID, AVG(UnitsInStock*UnitPrice)AS Promedio FROM Products
	GROUP BY CategoryID
	HAVING AVG(UnitsInStock*UnitPrice)>
	(
	SELECT AVG(UnitsInStock*UnitPrice) FROM Products
	);

--4
	SELECT * FROM Products
	WHERE CategoryID IN
	(
	SELECT CategoryID FROM Products
	GROUP BY CategoryID
	HAVING AVG(UnitsOnOrder) > 0.1*AVG(UnitsInStock)
	);
--5
	SELECT * FROM Products
	WHERE SupplierID IN
	(
	SELECT SupplierID FROM Products
	GROUP BY SupplierID
	HAVING SUM(UnitsOnOrder)=0
	);
--6
	SELECT CategoryID, (UnitPrice*0.5+UnitPrice) AS Venta FROM Products
	WHERE CategoryID =
	(
	SELECT CategoryID FROM Products
	GROUP BY CategoryID
	HAVING MIN(UnitPrice) <= ALL
		(
		SELECT MIN(UnitPrice) FROM Products
		GROUP BY CategoryID
		)
	)	
--6a
	SELECT SupplierID, SUM(UnitsInStock) AS STOCK FROM Products
	GROUP BY SupplierID
	HAVING SUM(UnitsInStock) <= ALL
	(
	SELECT SUM(UnitsInStock) FROM Products
	GROUP BY CategoryID
	)
	ORDER BY SUM(UnitsInStock)
--7
	--Agrupamos por proveedor porque si tiene mas de un producto regresa mas registros
	SELECT SupplierID, SUM(UnitsInStock*UnitPrice) AS Dinero FROM Products
	GROUP BY SupplierID
	HAVING SupplierID =
	(
	--Compara que el dinero en stock sea mayor la mayor de la lista
	SELECT SupplierID FROM Products
	GROUP BY SupplierID
	HAVING SUM(UnitsInStock*UnitPrice) >= ALL
		(
		--Esta consulta regresa las el dinero en stock por porveedor
		SELECT SUM(UnitsInStock*UnitPrice) FROM Products
		GROUP BY SupplierID
		)
	)
--8
	--Compara que el precio del porducto sea mayor que todos los precios de las categorias 2 y 4
	SELECT ProductID, ProductName, UnitPrice FROM Products
	WHERE UnitPrice >= ALL
	(
	--Regresa los precios de los productos de la categorias 2 y 4
	SELECT UnitPrice FROM Products
	WHERE CategoryID IN (2,4)
	)
--9
	--Compara que el precio del producto sea por lo menos mayor a un precio de algun producto de las categorias 2 y 4
	SELECT ProductID, ProductName, UnitPrice FROM Products
	WHERE CategoryID IN
	(
	SELECT CategoryID FROM Products
	WHERE UnitPrice >= ANY 
		(
		--Regresa los precios de los productos de la categorias 2 y 4
		SELECT UnitPrice FROM Products
		WHERE CategoryID IN (2,4)
		)
	)