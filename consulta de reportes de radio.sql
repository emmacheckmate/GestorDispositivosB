/*Descripcion: Consulta todos los registros que se generan en base 
del funcionamiento del radio, sucursal, encargado, estado del reporte*/
select r.numero_reporte, r.fecha_asignacion, r.observaciones, a.nombre_area, r.numero_radio,
       r.sucursal, edo.nombre, emp.nombEmp

from [dbGestDisp ].[dbo].[reportesRadio] as r
left join [dbGestDisp ].[dbo].[catArea] as a on  a.clave_area = r.area
left join [dbGestDisp ].[dbo].[catRadio] as cr on  cr.idRadio = r.numero_radio
left join [dbGestDisp ].[dbo].[catSucursal] as su on su.idsuc = r.sucursal
left join [dbGestDisp ].[dbo].[catEdo] as edo on  edo.codigo_estado = r.estado
left join [dbGestDisp ].[dbo].[catEmp] as emp on  emp.numEmp = r.resp