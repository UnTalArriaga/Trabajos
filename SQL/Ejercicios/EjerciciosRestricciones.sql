--Ejercicio 1
CREATE TABLE PRESTAMO(
nom_us VARCHAR(20) NOT NULL,
nom_lib VARCHAR(30) NOT NULL,
t_prest INT NOT NULL,
f_prest DATE DEFAULT GETDATE(),
CONSTRAINT CK_t_prest CHECK (t_prest <=5),
CONSTRAINT PK_PRESTAMO PRIMARY KEY (nom_us, nom_lib, f_prest)
);
--INSERT ACEPTADOS
INSERT INTO PRESTAMO VALUES('JUAN', 'SEDA', 3, '');
INSERT INTO PRESTAMO VALUES('JUAN', 'LAS BATALLAS EN EL DESIERTO', 5, '');
--INSERT RECHAZADOS
INSERT INTO PRESTAMO VALUES('JUAN', 'SEDA', 3, '');
INSERT INTO PRESTAMO VALUES('JUAN', 'LA BIBLIA', 10, '');
SELECT * FROM PRESTAMO;


--Ejercicio 2
CREATE TABLE PRODUCTO(
producto VARCHAR(20)NOT NULL,
stock INT NOT NULL,
tipo VARCHAR(8) NOT NULL,
precio NUMERIC(8,2) DEFAULT(15.00),
rfc VARCHAR(13),
CONSTRAINT CK_stock CHECK(stock>=0 AND stock<=250),
CONSTRAINT CK_tipo CHECK(tipo IN('lácteos', 'cereales', 'Jugos')),
CONSTRAINT PK_PRODUCTO PRIMARY KEY (producto, rfc)
);

--Ejercicio 3
CREATE TABLE EMPLEADO(
nombre VARCHAR(30),
puesto VARCHAR (15) CONSTRAINT DF_puesto  DEFAULT 'ayudante general',
codigo VARCHAR (7),
CONSTRAINT UK_nombre UNIQUE (nombre),
CONSTRAINT UK_codigo UNIQUE (codigo),
CONSTRAINT CK_puesto CHECK(puesto IN('ingeniero', 'secretaria', 'tecnico', 'mensajero')),
CONSTRAINT CK_codigo CHECK (codigo like '[A-Z][A-Z][A-Z][0-9][0-9][0-9][0-9]')
);

--Ejercicio 4
CREATE TABLE TITULO(
nombre VARCHAR(30),
cedula INT,
grado VARCHAR(12) CONSTRAINT DF_grado  DEFAULT 'Técnico',
carrera VARCHAR(100),
institucion VARCHAR(100),
año INT,
CONSTRAINT UK_TITULO_AÑO UNIQUE (nombre, grado, año),
CONSTRAINT UK_TITULO_INSTITUCION UNIQUE (nombre, grado, institucion),
CONSTRAINT CK_grado CHECK(grado IN('Licenciatura', 'Maestría', 'Doctorado')),
CONSTRAINT PK_TITULO PRIMARY KEY (cedula)
);

--Ejercicio 5
CREATE TABLE PELICULA(
clave INT,
titulo VARCHAR(100),
director VARCHAR(30),
duracion INT,
año INT,
genero VARCHAR(50),
clasificacion VARCHAR(3) CONSTRAINT DF_clasificacion  DEFAULT 'B15',
CONSTRAINT PK_PELICULA PRIMARY KEY(clave),
CONSTRAINT UK_DIRECTOR_AÑO UNIQUE (director, año),
CONSTRAINT UK_DIRECTOR_GENERO UNIQUE (director, genero),
CONSTRAINT CK_DURACION CHECK(duracion >= 120),
CONSTRAINT CK_AÑO CHECK(año>2018 AND año<2022),
CONSTRAINT CK_GENERO
	CHECK(genero  IN('Acción', 'Ciencia', 'Ficción', 'Comedia', 'Drama', 'Fantasía', 'Terror', 'Suspenso')),
CONSTRAINT CK_clasificacion CHECK (clasificacion IN('A', 'B', 'B15', 'C', 'D')),
);



DROP TABLE PRESTAMO;
DROP TABLE PRODUCTO;
DROP TABLE EMPLEADO;
DROP TABLE TITULO;
DROP TABLE PELICULA;