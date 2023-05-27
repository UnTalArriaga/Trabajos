--1
SELECT * FROM Customers
WHERE Country='Spain'

--2
SELECT * FROM Customers
WHERE Phone like '(%)%' AND Phone <> Fax

--3
SELECT * FROM Customers
where Phone like '__.%' 

--4
SELECT * FROM Customers
WHERE PostalCode NOT LIKE '%[A-Z]%' AND
	PostalCode NOT LIKE '%-%' AND
	PostalCode NOT LIKE '%.%'

--5
SELECT * FROM Customers
WHERE Region LIKE '[A-Z][A-Z]'
--6


--7

--8