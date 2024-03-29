CREATE TABLE TBL_EMPLEADOS
(
    ID_EMPLEADO INT PRIMARY KEY IDENTITY(1,1),
    NOMBRE VARCHAR(100) NOT NULL,
    TIPO_DNI VARCHAR(20) NOT NULL,
    DNI VARCHAR(50) NOT NULL,
    FECHA_INGRESO DATE NOT NULL,
    SALARIO_BASE MONEY NOT NULL,
    DIRECCION VARCHAR(500) NOT NULL
);

CREATE TABLE TBL_VACACIONES_GENERADAS
(
    ID_VACACIONES INT PRIMARY KEY IDENTITY(1,1),
    DESCRIPCION VARCHAR(100) NOT NULL,
    FECHA_INICIAL DATE NOT NULL,
    FECHA_FINAL DATE NOT NULL,
    DIAS_GENERADOS NUMERIC NOT NULL,
    DIAS_TOMADOS NUMERIC,
    ID_EMPLEADO INT FOREIGN KEY REFERENCES TBL_EMPLEADOS(ID_EMPLEADO) 
);

CREATE TABLE TBL_PARAMETROS
(
    ID_PARAMETROS INT PRIMARY KEY IDENTITY (1,1),
    DESCRIPCION VARCHAR(100) NOT NULL,
    VALOR_PARAM NUMERIC
);

CREATE TABLE TBL_VACACIONES_CONFIG
(
    ID_VACIONES_CONFIG INT PRIMARY KEY IDENTITY (1,1),
    ID_PARAMETRO INT FOREIGN KEY REFERENCES TBL_PARAMETROS(ID_PARAMETROS),
    ID_VACACIONES INT FOREIGN KEY REFERENCES TBL_VACACIONES_GENERADAS(ID_VACACIONES)
);

CREATE TABLE TBL_VACACIONES_SOLICITADAS
(
    ID_VACACIONES_SOLI INT PRIMARY KEY IDENTITY (1,1),
    MOTIVO VARCHAR(100) NOT NULL,
    FECHA_INICIAL DATE NOT NULL,
    FECHA_FINAL DATE NOT NULL,
    ID_VACACIONES_GENERADAS INT FOREIGN KEY REFERENCES TBL_VACACIONES_GENERADAS(ID_VACACIONES)
);

-------------------Procedimientos almacenados------------

Create Proc ListarEmpleados
As Begin
	Select ID_EMPLEADO, NOMBRE, TIPO_DNI, DNI, FECHA_INGRESO, SALARIO_BASE, DIRECCION From TBL_EMPLEADOS 
   End
Go

Create Proc RegistrarEmpleado
(@NOMBRES Varchar(50),
 @TIPO_DNI Varchar(20),
 @DNI Varchar(50),
 @FECHA_INGRESO date,
 @SALARIO_BASE MONEY,
 @DIRECCION VARCHAR(500),
 @Mensaje Varchar(50) Output
)
As Begin
	If(Exists(Select * From TBL_EMPLEADOS Where Dni=@DNI))
		Set @Mensaje='Los Datos del Cliente ya Existen.'
	Else Begin
		Insert TBL_EMPLEADOS Values(@NOMBRES,@TIPO_DNI,@DNI,@FECHA_INGRESO,@SALARIO_BASE,@DIRECCION)
		Set @Mensaje='Registrado Correctamente.'
		End
	End
Go

Create Proc ActualizarEmpleado
(@ID_EMPLEADO Integer,
 @NOMBRES Varchar(100),
 @TIPO_DNI Varchar(20),
 @DNI Varchar(50),
 @FECHA_INGRESO date,
 @SALARIO_BASE MONEY,
 @DIRECCION VARCHAR(500),
 @Mensaje Varchar(50) Output
)
As Begin
	If(Not Exists(Select * From TBL_EMPLEADOS Where ID_EMPLEADO=@ID_EMPLEADO))
		Set @Mensaje='Los Datos del Empleado no Existen.'
	Else Begin
		Update TBL_EMPLEADOS Set NOMBRE=@NOMBRES,TIPO_DNI=@TIPO_DNI,DNI=@DNI,FECHA_INGRESO=@FECHA_INGRESO,SALARIO_BASE=@SALARIO_BASE,DIRECCION=@DIRECCION 
		Where ID_EMPLEADO=@ID_EMPLEADO
		Set @Mensaje='Registro Actualizado Correctamente.'
		End
	End
Go

Create Proc EliminarEmpleado
(@ID_EMPLEADO Integer,
 @Mensaje Varchar(50) Output
)
As Begin
	If(Not Exists(Select * From TBL_EMPLEADOS Where ID_EMPLEADO=@ID_EMPLEADO))
		Set @Mensaje='Los Datos del Empleado no Existen.'
	Else Begin
		DELETE FROM TBL_EMPLEADOS Where ID_EMPLEADO=@ID_EMPLEADO
		Set @Mensaje='Registro Eliminado.'
		End
	End
Go

Create Proc FiltrarDatosCliente
@Datos Varchar(80)
As Begin
	Select IdCliente,DNI,Apellidos,Nombres,Direccion,Telefono 
	From Cliente Where Apellidos+' '+ Nombres=@Datos or Apellidos=@Datos or Nombres=@Datos
End
Go