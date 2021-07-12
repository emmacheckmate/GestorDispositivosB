create table controlD(
numSerie varchar(12) not null,
descripcion varchar(30),
tipo_d int not null,
foreign key ( tipo_d ) references catDisp( clave_disp),
primary key (numSerie)
);