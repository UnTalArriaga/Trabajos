--CREANDO COPIA DE LA TABLA PRODUCTS, SOLAMENTE EL FORMATO Y DATOS
SELECT *
INTO PRODUCTO
FROM Products;

--1
CREATE PROCEDURE SP_cambiarStock
@Id_Producto INT,
@NuevoStock INT
AS
BEGIN
 UPDATE PRODUCTO
 SET UnitsInStock = @NuevoStock
 WHERE ProductID = @Id_Producto
END

--antes tenia 0 en stock
EXEC SP_cambiarStock 5, 45

SELECT * FROM PRODUCTO	
WHERE ProductID=5;

--2
CREATE PROCEDURE SP_ListarProducto
@Nombre VARCHAR(50)
AS
BEGIN
SELECT * FROM PRODUCTO
WHERE ProductName LIKE '%'+@Nombre+'%'
END

EXEC SP_ListarProducto Anton

--3
CREATE PROCEDURE SP_NumOrdenesEmpleado
@MINIMO INT
AS
BEGIN
SELECT E.FirstName, E.LastName, COUNT(OrderID) AS NumOrdenes
FROM Orders O INNER JOIN Employees E
ON O.EmployeeID=E.EmployeeID
GROUP BY E.FirstName, E.LastName
HAVING COUNT(OrderID) >=@MINIMO
ORDER BY COUNT(OrderID) ASC
END

EXEC SP_NumOrdenesEmpleado 100

--4
CREATE PROCEDURE SP_monto_vendido
@anio INT, 
@reg INT
AS
BEGIN
SELECT TOP (@reg) P.ProductName, 
		SUM(OD.UnitPrice*OD.Quantity  - OD.UnitPrice*OD.Quantity*Discount) AS DINERO
FROM Products P INNER JOIN [Order Details] OD
ON P.ProductID = OD.ProductID
INNER JOIN Orders O
ON O.OrderID = OD.OrderID 
WHERE  YEAR(OrderDate) = @anio 
GROUP BY P.ProductName
ORDER BY DINERO DESC
END

EXEC SP_monto_vendido 1996, 5

--5 
CREATE PROCEDURE SP_10REGISTROS
@NOMBRE NVARCHAR(50)
AS
BEGIN
DECLARE @CONSULTA NVARCHAR(MAX)
SET @CONSULTA = 'SELECT TOP 10 * FROM ' + QUOTENAME(@NOMBRE)
EXEC SP_executesql @CONSULTA
END

EXEC SP_10REGISTROS Products

----------------------TRIGGERs------------------------------------------------
select * 
into DetallesOrden
from [Order Details];
--1
drop trigger newOrder 
create trigger newOrder 
on DetallesOrden
for insert
as
declare @stock int
	
	set @stock = (Select UnitsInStock 
	from PRODUCTO p inner join inserted i
	on p.ProductID = i.ProductID)

	if(@stock>=(Select Quantity from inserted))
		update PRODUCTO
		set UnitsInStock = UnitsInStock - i.Quantity
		FROM PRODUCTO P inner join inserted I
		on P.ProductID = I.ProductID
	else
		begin
			print 'No hay sufieciente stock'
			rollback transaction
		end

Select * from PRODUCTO --53 en stock
where ProductID =4
Select * from DetallesOrden --#2155 ordenes


insert into DetallesOrden values(3124, 4, 22.00, 5, 0.0)

Select * from PRODUCTO --48 en stock
where ProductID =4
Select * from DetallesOrden --#2156 ordenes

insert into DetallesOrden values(3124, 4, 22.00, 50, 0.0) --Da el error correcto

--2
CREATE TABLE StockDiferencia(
ProductID int,
ProductName varchar(100),
Diferencia int
);

drop trigger noOrder

create trigger noOrder
on DetallesOrden
for insert
as
declare @stock int
declare @id int
declare @name varchar(100)
declare @dif int
	
	set @stock = (Select UnitsInStock 
	from PRODUCTO p inner join inserted i
	on p.ProductID = i.ProductID)

	set @id = (Select p.ProductID 
	from PRODUCTO p inner join inserted i
	on p.ProductID = i.ProductID)

	set @name = (Select p.ProductName 
	from PRODUCTO p inner join inserted i
	on p.ProductID = i.ProductID)

	if(@stock>=(Select Quantity from inserted))
		update PRODUCTO
		set UnitsInStock = UnitsInStock - i.Quantity
		FROM PRODUCTO P inner join inserted I
		on P.ProductID = I.ProductID
	else
		begin
			print 'StockDiferencia'
			set @dif = -@stock +(Select Quantity from inserted)
			rollback transaction
			insert into StockDiferencia
			values (@id, @name, @dif)
			commit
		end

insert into DetallesOrden values(3124, 1, 22.00, 100, 0.0) --Da el error correcto

delete StockDiferencia
select * from StockDiferencia

--3
DROP TABLE REEMBOLSO
CREATE TABLE REEMBOLSO(
ID_CLIENTE NVARCHAR,
ID_PRODUCTO INT,
CANT_DEV INT,
ID_ORDEN INT,
DIN_REEM INT
);

DROP TRIGGER SP_REEMBOLSO
CREATE TRIGGER SP_REEMBOLSO
ON DetallesOrden
FOR DELETE
AS
DECLARE @CLIENTE NVARCHAR
DECLARE @PRODUCTO INT 
DECLARE @PZS INT
DECLARE @ORDEN INT
DECLARE @REEMBOLSO INT

	SET @CLIENTE = (SELECT tmp.CustomerID FROM 
						(SELECT O.CustomerID 
						FROM Orders O INNER JOIN deleted D 
						ON O.OrderID = D.OrderID
						)tmp
					)
	SET @PRODUCTO = (SELECT ProductID FROM deleted)
	SET @PZS = (SELECT Quantity FROM deleted)
	SET @ORDEN = (SELECT OrderID FROM deleted)
	SET @REEMBOLSO = (SELECT (UnitPrice*Quantity - UnitPrice*Quantity*Discount) 
					FROM deleted)

	INSERT INTO REEMBOLSO VALUES(@CLIENTE, @PRODUCTO, @PZS, @ORDEN, @REEMBOLSO)
	UPDATE PRODUCTO
	SET UnitsInStock = UnitsInStock + @PZS
	FROM PRODUCTO 
	WHERE ProductID = @PRODUCTO

DELETE DetallesOrden
WHERE OrderID = 10248
	AND ProductID = 42

SELECT * FROM DetallesOrden
WHERE OrderID = 10248

SELECT * FROM REEMBOLSO