CREATE TABLE reporteRadio (
    idControl int NOT NULL IDENTITY,
    idRadio nchar(8) NOT NULL,
    idsuc nchar(10) NOT NULL,
	numEmp char(10) NOT NULL,
	idEdo nchar(1) NOT NULL, 
	idArea nchar(1) NOT NULL,
	observaciones varchar(50),
	fechaasignacion date ,
    PRIMARY KEY (idControl),
	FOREIGN KEY (idRadio) REFERENCES catRadio( idRadio ),
	FOREIGN KEY ( idsuc) REFERENCES catSucursal( idsuc),
	FOREIGN KEY (numEmp) REFERENCES catEmp( numEmp),
	FOREIGN KEY ( idEdo) REFERENCES catEdo( idEdo),
	FOREIGN KEY ( idArea) REFERENCES catArea( idArea)
);
