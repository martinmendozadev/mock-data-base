CREATE DATABASE bd_operacional_ventas;
USE BD_Operacional_Ventas;

CREATE TABLE productos 
	(idProducto VARCHAR(7) PRIMARY KEY, 
    nombre VARCHAR (35), 
    precio SMALLINT, 
    categoria VARCHAR (35), 
    subcategoria VARCHAR (35));
    
CREATE TABLE tiendas
	(idTienda VARCHAR(7) PRIMARY KEY, 
    nombre VARCHAR(50),
    ciudad VARCHAR(35), 
    estado VARCHAR(35), 
    region VARCHAR(35));
    
CREATE TABLE tiempo (
	idTiempo VARCHAR(6) PRIMARY KEY, 
    fecha DATETIME
);
    
CREATE TABLE ventas (
	NoTicket VARCHAR(6), 
    idTienda VARCHAR(7), 
    idProducto VARCHAR(7), 
    cantidad TINYINT, 
    precio_venta SMALLINT, 
    idTiempo DATETIME,
    FOREIGN KEY (idTienda) REFERENCES tiendas (idTienda),
    FOREIGN KEY (idProducto) REFERENCES productos (idProducto)/*,
    FOREIGN KEY (idTiempo) REFERENCES tiempo (idTiempo)*/
);
  
INSERT INTO productos VALUES 
	("P1","Lala",20,"Lacteos","Leches"),
	("P2","Alpura",25,"Lacteos","Leches"),
    ("P3","yogurt de fresa",30,"Lacteos","yogurt"),
	("P4","pepino",8,"verdura","verdura verde"),
	("P5","Chivas Regal",600,"halcol","Whisky "),
	("P6","Don julio",700,"halcol","tequila"),
    ("P7","queo guajaca",30,"Lacteos","queso"),
	("P8","pan binbo",45,"pan","pan de caja"),
	("P9","azucar",40,"endulsante","endulsante natural"),
	("P10","mermelada macornie",38,"mermeladas","mermeladas de fresa"),
    ("P11","queso rallado",10,"Lacteos","queso"),
	("P12","queo manchego",39,"Lacteos","queso"),
	("P13","queso gouda",80,"Lacteos","queso"),
	("P14","aceitunas",45,"enlatados","vinagre"),
    ("P15","mantequilla sin sal",15,"Lacteos","mat"),
	("P16","pan de ajo",60,"pan","pan artesanal"),
	("P17","galletas emperador chocolate",11,"galletas","galleteas emperador"),
	("P18","zalchichas de pabo",60,"embutidos","fud"),
    ("P19","chorizo",20,"embutidos","embuitods"),
	("P20","chocomilk",35,"leche en polvo","chocolates"),
	("P21","arroz",15,"granos","semillas"),
	("P22","frijol",50,"semillas","granos"),
    ("P23","nutrioli aceite",28,"aceite","cocina"),
	("P24","cafe",95,"cafeteria","cafeina"),
	("P25","tortillinas",12,"tortilla","harinas"),
	("P26","sal",9,"condimento","condimentos"),
	("P27","pimienta",25,"condimento","condimentos"),
    ("P28","sodas de mango",19,"gaseosa","refresco"),
	("P29","avena",25,"semillas","semillas"),
	("P30","agua epura",18,"agua","agua pura")
;

INSERT INTO tiendas VALUES 
	('T1','Abarrotes, Vinos, y Licores Doña Leticia','Durango','Victoria de Durango','norte'),
	('T2','Tienda María Fernanda','Ciudad de Mexico','CDMX','sur'),
	('T3','Abastos Doña Leticia','Puebla','Puebla de Zaragoza','centro'),
	('T4','Miscealanea De Gabriel','Coahuila','Saltillo','norte'),
	('T5','Deposito Don José Luis','Mexico','Toluca de Lerdo','sur'),
	('T6','Abastos Doña Patricia','Queretaro','Santiago de Queretaro','centro'),
	('T7','Deposito María de Jesús','Chiapas','Tuxla Gutierrez','sur'),
	('T8','Abarrotes, Vinos, y Licores de Stephanie','Nayarit','Tepic','centro'),
	('T9','Tienda María Elena','Guerrero','Chilpancingo','sur'),
	('T10','Abarrotes, Vinos, y Licores Doña Melanie','Tlaxcala','Taxcala de Xicohtencatl','centro'),
	('T11','Variedades Don Jose ','Chihuahua','Chihuahua','norte'),
	('T12','Variedades Isabella','Coahuila','Saltillo','norte'),
	('T13','Abastos de Alejandra','Campeche','Aguascalientes','sur'),
	('T14','Variedades María Guadalupe','Hidalgo','Pachuca de Soto','centro'),
	('T15','Abastos María Luisa','Jalisco','Guadalajara','centro'),
	('T16','Deposito María Fernanda','Guerrero','Chilpancingo','sur'),
	('T17','Abastos María Camila','Nayarit','Tepic','centro'),
	('T18','Tienda María de Jesús','Sonora','Hermosillo','norte'),
	('T19','Miscealanea de la Estacion','Guerrero','Chilpancingo','sur'),
	('T20','Miscealanea Doña Melanie','Baja California','Mexicali','norte'),
	('T21','Variedades Doña Martha','Veracruz','Xalapa','centro'),
    ('T22','Variedades Doña Martha 2','Oaxaca','Oaxaca','centro'),
	('T23','Abastos Don José Luis','Quintana Roo','Chetumal','sur'),
	('T24','Variedades De Alfredo','Veracruz','Merida','sur'),
	('T25','Miscealanea Doña María José y Alexa','Sinaloa','Culiaca Rosales','norte'),
	('T26','Miscealanea del centro','Oaxaca','Oaxaca de Juarez','sur'),
	('T27','Tienda Mía','San Luis Potosi','San Luis Potosi','centro'),
	('T28','Deposito Diego','Nayarit','Tepic','centro'),
	('T29','Abarrotes, Vinos, y Licores Mariana','Ciudad de Mexico','CDMX','sur'),
	('T30','Miscealanea de Luna','Mexico','Toluca de Lerdo','sur'),
	('T31','Abastos Alicia','Campeche','Aguascalientes','sur'),
	('T32','Miscealanea Leticia ','Michoacan de Ocampo','Morelia','centro'),
	('T33','Tienda María Luisa','San Luis Potosi','San Luis Potosi','centro'),
	('T34','Miscealanea Andrea','Jalisco','Guadalajara','centro'),
	('T35','Miscealanea del centro','Baja California','Mexicali','norte'),
	('T36','Tienda El Americano ','Puebla','Puebla de Zaragoza','centro'),
	('T37','Abarrotes, Vinos, y Licores de Doña Aitana','Coahuila','Saltillo','norte'),
	('T38','Abarrotes, Vinos, y Licores Doña Lucía','Durango','Victoria de Durango','norte'),
	('T39','Deposito Alicia','Campeche','Aguascalientes','sur'),
	('T40','Variedades De Alfredo','Hidalgo','Pachuca de Soto','centro'),
	('T41','Miscealanea María Elena','Campeche','Aguascalientes','sur'),
	('T42','Variedades Don Raúl','Coahuila','Saltillo','norte'),
	('T43','Abastos de la Estacion','Baja California','Mexicali','norte'),
	('T44','Deposito Señor Daniel','Tamaulipas','Ciudad Victoria','norte'),
	('T45','Abastos Don Raúl','Morelos','Cuernavaca','sur')
;

INSERT INTO tiempo VALUES
	('TM1','2018-01-01 00:00:00'),
	('TM2','2018-01-01 10:00:00'),
	('TM3','2018-01-01 23:59:59')
;

INSERT INTO ventas VALUES
	('TK1','T1','P1',10,50,'TM1'),
	('TK1','T1','P2',100,150,'TM2'),
	('TK1','T1','P3',1,5,'TM3'),
    ('TK2','T2','P1',10,50,'TM1'),
	('TK3','T2','P2',100,150,'TM1'),
	('TK2','T2','P3',1,5,'TM1')
;


SELECT count(idTiempo) FROM tiempo;
SELECT*FROM tiempo;
SELECT*FROM ventas  WHERE NoTicket='TK1';
SELECT*FROM tiempo  WHERE fecha='2018-01-31 00:00:00';
SELECT*FROM tiendas;
SELECT*FROM productos;

SELECT * FROM ventas 
WHERE DATE(Idtiempo) BETWEEN '2018-01-01 00:00:00' AND '2018-01-02 23:59:59';

SELECT*FROM tiempo
WHERE fecha >= '2018-09-29 23:56:56' AND fecha <='2018-09-31 23:56:56';

SELECT * FROM ventas, tiempo
WHERE ventas.idTiempo=tiempo.idTiempo AND
tiempo.fecha BETWEEN '2018-01-31 00:00:00' AND '2018-02-31 23:59:59';

DROP TABLE ventas;
DROP TABLE tiempo;
DROP DATABASE BD_Operacional_Ventas;