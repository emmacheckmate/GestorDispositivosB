CREATE TABLE reportesRadios
(
     numero_reporte int not null, 
	 fecha_asignacion date not null,
	 observaciones varchar(100) not null, 
	 numero_radio nchar(8) not null,
	 resp char(10) not null ,
	 sucursal nchar(10) not null,
	 area int not null,
	 primary key (numero_reporte),
	 foreign key ( numero_radio) references CatRadio(idRadio),
	 foreign key ( resp ) references CatEmp( numEmp ),
	 foreign key ( sucursal ) references catSucursal( idsuc ), 
	 foreign key (area) references CatArea( clave_area)

      
);