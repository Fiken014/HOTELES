USE VEHICULOS_DES_APP_ULT_GEN;
----============================================
----   TABLA HOTELES
----============================================
CREATE TABLE [dbo].[Hoteles](
	[Id_Hotel] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Hotel] [nvarchar](30) NOT NULL,
	[Nombre_Hotel] [nvarchar](50) NOT NULL,
	[Descripcion_Hotel] [nvarchar](500) NOT NULL,
	[Direccion] [nvarchar](500) NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Url_Hotel] [nvarchar](500) NOT NULL,
	[Area_Construccion] [decimal](10,2) NOT NULL,
	[Fecha_Construccion] [date] NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Hoteles] PRIMARY KEY CLUSTERED 
(
	[Id_Hotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 	ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----============================================
----   TABLA HABITACIONES
----============================================
CREATE TABLE [dbo].[Habitaciones](
	[Id_Habitacion] [int] IDENTITY(1,1) NOT NULL,
	[Id_Hotel] [int] NOT NULL,
	[Descripcion_Habitacion] [nvarchar](500) NOT NULL,
	[Tipo_Habitacion] [nvarchar](50) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Habitaciones] PRIMARY KEY CLUSTERED 
(
	[Id_Habitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----=====================================================
----   RELACION ENTRE TABLA HOTELES Y TABLA HABITACIONES
----=====================================================
ALTER TABLE [dbo].[Habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_Habitaciones_Hoteles] FOREIGN KEY([Id_Hotel])
REFERENCES [dbo].[Hoteles] ([Id_Hotel])
GO

----============================================
----   PROCEDIMIENTOS CRUD HABITACIONES
----============================================

CREATE PROCEDURE [dbo].[USP_Listar_Habitaciones]
AS BEGIN 

  SELECT HBT.[Id_Habitacion]
      ,HBT.[Descripcion_Habitacion]
      ,HBT.[Tipo_Habitacion]
	  ,HOT.[Nombre_Hotel]
  FROM [dbo].[Habitaciones] HBT
  INNER JOIN Hoteles HOT ON HOT.Id_Hotel = HBT.Id_Hotel
END
GO

CREATE PROCEDURE [dbo].[USP_Filtrar_Habitaciones]
(
@Nombre_Hotel int,
@Descripcion_Habitacion VARCHAR(500),
@Estado CHAR(1)
)
AS BEGIN 

  SELECT HBT.[Id_Habitacion]
      ,HBT.Descripcion_Habitacion
      ,HOT.[Nombre_Hotel]
      ,HBT.[Estado]
  FROM [dbo].[Habitaciones] HBT
  INNER JOIN Hoteles HOT ON HOT.Id_Hotel = HBT.Id_Hotel
  WHERE LTRIM(RTRIM(HBT.Descripcion_Habitacion)) LIKE '%' + LTRIM(RTRIM(@Descripcion_Habitacion)) + '%'
      AND HBT.Id_Hotel = CASE @Nombre_Hotel WHEN 0 THEN HBT.Id_Hotel ELSE @Nombre_Hotel END
      AND HBT.Estado = CASE @Estado WHEN '' THEN HBT.Estado ELSE @Estado END;
END
GO

CREATE PROCEDURE [dbo].[USP_Informacion_Habitaciones]
(
@Id_Habitacion INT
)
AS BEGIN 

SELECT 
		HBT.[Id_Habitacion],
		HBT.[Descripcion_Habitacion],
		HBT.[Tipo_Habitacion],
		HBT.[Id_Hotel],
		HBT.[Estado]
  FROM [dbo].[Habitaciones] HBT
  INNER JOIN [Hoteles] HOT ON HOT.Id_Hotel = HBT.Id_Hotel
  WHERE [Id_Habitacion]=@Id_Habitacion
END
GO

CREATE PROCEDURE [dbo].[USP_Insertar_Habitaciones]
(
@Descripcion_Habitacion varchar(500),
@Tipo_Habitacion varchar(50),
@Id_Hotel int,
@Estado char(1),
@IdUsuario_Global int
)
AS BEGIN 
BEGIN TRY
	IF NOT EXISTS(SELECT Id_Habitacion FROM Habitaciones WHERE Id_Hotel=@Id_Hotel AND Descripcion_Habitacion=@Descripcion_Habitacion)
	BEGIN
		INSERT INTO  [dbo].[Habitaciones]
		(
			[Descripcion_Habitacion],
			[Tipo_Habitacion],
			[Id_Hotel],
			[Estado]
		)
		VALUES
		(
			@Descripcion_Habitacion,
			@Tipo_Habitacion,
			@Id_Hotel,
			@Estado
		)

		SELECT @@IDENTITY

		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @ACC CHAR(1)
		SET @DSC = 'Inserta la información de Habitacion ' + '. Id Registro: ' + CONVERT(VARCHAR,@@IDENTITY)
		SET @ACC = 'I'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripción, Fecha
		)
		SELECT
		@IdUsuario_Global, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
	END
	ELSE
	BEGIN
		SELECT -1
	END
END TRY
BEGIN CATCH
	SELECT 0
END CATCH
END
GO

CREATE PROCEDURE [dbo].[USP_Modificar_Habitaciones]
(
@Id_Habitacion int,
@Descripcion_Habitacion varchar(500),
@Tipo_Habitacion varchar(50),
@Id_Hotel int,
@Estado char(1),
@IdUsuario_Global int
)
AS BEGIN 
BEGIN TRY
SET DATEFORMAT DMY
	IF NOT EXISTS(SELECT Id_Habitacion FROM Habitaciones WHERE Descripcion_Habitacion=@Descripcion_Habitacion AND Id_Hotel=@Id_Hotel AND Id_Habitacion NOT IN (@Id_Habitacion))
	BEGIN
		UPDATE [dbo].[Habitaciones]
		SET
			   [Descripcion_Habitacion]=@Descripcion_Habitacion
			  ,[Tipo_Habitacion]=@Tipo_Habitacion
			  ,[Id_Hotel]=@Id_Hotel
			  ,[Estado]=@Estado
		WHERE Id_Habitacion=@Id_Habitacion
		SELECT @Id_Habitacion
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @ACC CHAR(1)
		SET @DSC = 'Actualiza la información de la Habitacion ' +  '. Id Registro: ' + CONVERT(VARCHAR,@Id_Habitacion)
		SET @ACC = 'A'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripción, Fecha
		)
		SELECT
		@IdUsuario_Global, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
	END
	ELSE
	BEGIN
		SELECT -1
	END
END TRY
BEGIN CATCH
	SELECT 0
END CATCH


END
GO

CREATE PROCEDURE [dbo].[USP_Eliminar_Habitaciones]
(
@Id_Habitacion int,
@IdUsuario_Global int
)
AS BEGIN 
BEGIN TRY
	IF EXISTS(SELECT Id_Habitacion FROM Habitaciones WHERE Id_Habitacion=@Id_Habitacion)
	BEGIN
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
		DECLARE @DSC VARCHAR(MAX)
		DECLARE @NOMBRE VARCHAR(200)
		DECLARE @ACC CHAR(1)

		SELECT @NOMBRE= 'La habitacion' + RTRIM(LTRIM(Tipo_Habitacion)) + RTRIM(LTRIM(Descripcion_Habitacion)) FROM Habitaciones WHERE Id_Habitacion=@Id_Habitacion

		SET @DSC = 'Elimina la información de la habitacion ' + RTRIM(LTRIM(@NOMBRE)) + '. Id Registro: ' + CONVERT(VARCHAR,@Id_Habitacion)
		SET @ACC = 'E'

		INSERT INTO Auditoria
		(
		Id_Usuario, Accion, Descripción, Fecha
		)
		SELECT
		@IdUsuario_Global, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
		-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		DELETE FROM Habitaciones WHERE Id_Habitacion=@Id_Habitacion
		SELECT @Id_Habitacion
	END
	ELSE
	BEGIN
		SELECT -1
	END
END TRY
BEGIN CATCH
	SELECT 0
END CATCH


END
GO

----============================================
----   PROCEDIMIENTOS CRUD HOTELES
----============================================

CREATE PROCEDURE [dbo].[USP_Listar_Hoteles]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id_Hotel,
        Codigo_Hotel,
        Nombre_Hotel,
        Descripcion_Hotel,
        Direccion,
        Telefono,
        Correo,
        Url_Hotel,
        Area_Construccion,
        Fecha_Construccion,
        CASE LTRIM(RTRIM(Estado)) WHEN 'A' THEN 'Activo' ELSE 'Inactivo' END AS Estado
    FROM dbo.Hoteles;
END
GO

CREATE PROCEDURE [dbo].[USP_Filtrar_Hoteles]
(
    @Codigo_Hotel NVARCHAR(30) = NULL,
    @Nombre_Hotel NVARCHAR(50) = NULL,
    @Estado CHAR(1) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;
    SET DATEFORMAT DMY;

    SELECT 
        Id_Hotel,
        Codigo_Hotel,
        Nombre_Hotel,
        Descripcion_Hotel,
        Direccion,
        Telefono,
        Correo,
        Url_Hotel,
        Area_Construccion,
        Fecha_Construccion,
        CASE LTRIM(RTRIM(Estado)) WHEN 'A' THEN 'Activo' ELSE 'Inactivo' END AS Estado
    FROM dbo.Hoteles
    WHERE
        (@Codigo_Hotel IS NULL OR LTRIM(RTRIM(Codigo_Hotel)) LIKE '%' + LTRIM(RTRIM(@Codigo_Hotel)) + '%')
        AND (@Nombre_Hotel IS NULL OR LTRIM(RTRIM(Nombre_Hotel)) LIKE '%' + LTRIM(RTRIM(@Nombre_Hotel)) + '%')
        AND (@Estado IS NULL OR Estado = @Estado);
END
GO

CREATE PROCEDURE [dbo].[USP_Informacion_Hoteles]
(
    @IdHotel INT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET DATEFORMAT DMY;

    SELECT 
        Id_Hotel,
        Codigo_Hotel,
        Nombre_Hotel,
        Descripcion_Hotel,
        Direccion,
        Telefono,
        Correo,
        Url_Hotel,
        Area_Construccion,
        CONVERT(VARCHAR(10), Fecha_Construccion, 103) AS Fecha_Construccion, -- dd/mm/yyyy
        Estado
    FROM dbo.Hoteles
    WHERE Id_Hotel = @IdHotel;
END
GO

CREATE PROCEDURE [dbo].[USP_Insertar_Hoteles]
(
    @Codigo_Hotel NVARCHAR(30),
    @Nombre_Hotel NVARCHAR(50),
    @Descripcion_Hotel NVARCHAR(500),
    @Direccion NVARCHAR(500),
    @Telefono NVARCHAR(15),
    @Correo NVARCHAR(50),
    @Url_Hotel NVARCHAR(500),
    @Area_Construccion DECIMAL(10,2),
    @Fecha_Construccion DATE,
    @Estado CHAR(1),
    @IdUsuario_Global INT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET DATEFORMAT DMY;

    BEGIN TRY
        -- Comprobar duplicado por Codigo_Hotel (campo único lógico)
        IF EXISTS (SELECT 1 FROM dbo.Hoteles WHERE LTRIM(RTRIM(Codigo_Hotel)) = LTRIM(RTRIM(@Codigo_Hotel)))
        BEGIN
            SELECT -1 AS Resultado; -- Código duplicado
            RETURN;
        END

        INSERT INTO dbo.Hoteles
        (
            Codigo_Hotel,
            Nombre_Hotel,
            Descripcion_Hotel,
            Direccion,
            Telefono,
            Correo,
            Url_Hotel,
            Area_Construccion,
            Fecha_Construccion,
            Estado
        )
        VALUES
        (
            @Codigo_Hotel,
            @Nombre_Hotel,
            @Descripcion_Hotel,
            @Direccion,
            @Telefono,
            @Correo,
            @Url_Hotel,
            @Area_Construccion,
            CAST(@Fecha_Construccion AS DATE),
            @Estado
        );

        DECLARE @NewId INT;
        SELECT @NewId = CAST(SCOPE_IDENTITY() AS INT);

        -- Auditoría
        DECLARE @DSC VARCHAR(MAX);
        DECLARE @ACC CHAR(1) = 'I';
        SET @DSC = 'Incluye la información del Hotel ' + RTRIM(LTRIM(@Nombre_Hotel)) + 
                   ' (Codigo: ' + RTRIM(LTRIM(@Codigo_Hotel)) + '). Id Registro: ' + CONVERT(VARCHAR, @NewId);

        INSERT INTO dbo.Auditoria (Id_Usuario, Accion, Descripción, Fecha)
        SELECT @IdUsuario_Global, @ACC, RTRIM(LTRIM(@DSC)), GETDATE();

        SELECT @NewId AS Resultado;
    END TRY
    BEGIN CATCH
        SELECT 0 AS Resultado;
    END CATCH
END
GO

CREATE PROCEDURE [dbo].[USP_Modificar_Hoteles]
(
@IdHotel int,
@Codigo_Hotel NVARCHAR(30),
@Nombre_Hotel NVARCHAR(50),
@Descripcion_Hotel NVARCHAR(500),
@Direccion NVARCHAR(500),
@Telefono NVARCHAR(15),
@Correo NVARCHAR(50),
@Url_Hotel NVARCHAR(500),
@Area_Construccion DECIMAL(10,2),
@Fecha_Construccion DATE,
@Estado CHAR(1),
@IdUsuario_Global INT
)
AS BEGIN 
BEGIN TRY
SET DATEFORMAT DMY
	IF NOT EXISTS(SELECT Id_Hotel FROM Hoteles WHERE Nombre_Hotel=@Nombre_Hotel and Id_Hotel not in(@IdHotel)) 
	BEGIN

		UPDATE [dbo].[Hoteles]
		SET
			   [Codigo_Hotel]=@Codigo_Hotel,
			   [Nombre_Hotel]=@Nombre_Hotel,
			   [Descripcion_Hotel]=@Descripcion_Hotel,
			   [Direccion]=@Direccion,
			   [Telefono]=@Telefono,
			   [Correo]=@Correo,
			   [Url_Hotel]=@Url_Hotel,
			   [Area_Construccion]=@Area_Construccion,
			   [Fecha_Construccion]=CAST(@Fecha_Construccion AS date),
			   [Estado]=@Estado
		WHERE Id_Hotel=@IdHotel

			-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
			DECLARE @DSC VARCHAR(MAX)
			DECLARE @ACC CHAR(1)
			SET @DSC = 'Actualiza la información del Hotel ' + RTRIM(LTRIM(@Nombre_Hotel)) +  '. Id Registro: ' + CONVERT(VARCHAR,@IdHotel)
			SET @ACC = 'A'

			INSERT INTO Auditoria
			(
			Id_Usuario, Accion, Descripción, Fecha
			)
			SELECT
			@IdUsuario_Global, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
			-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------

		SELECT @IdHotel
	END
	ELSE
	BEGIN
		SELECT -1
	END
END TRY 
BEGIN CATCH
	SELECT 0
END CATCH
END
GO

CREATE PROCEDURE [dbo].[USP_Eliminar_Hoteles]
(
@IdHotel int,
@IdUsuario_Global int
)
AS BEGIN 
BEGIN TRY
	IF (
		NOT EXISTS(SELECT Id_Habitacion FROM Habitaciones WHERE Id_Hotel=@IdHotel)
		)
	BEGIN

				-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------
			DECLARE @DSC VARCHAR(MAX)
			DECLARE @HOTEL VARCHAR(50)
			DECLARE @ACC CHAR(1)

			SELECT @HOTEL=RTRIM(LTRIM(Nombre_Hotel)) FROM Hoteles
			WHERE Id_Hotel=@IdHotel

			SET @DSC = 'Elimina la información del Fabricante ' + RTRIM(LTRIM(@HOTEL)) + '. Id Registro: ' + CONVERT(VARCHAR,@IdHotel)
			SET @ACC = 'E'

			INSERT INTO Auditoria
			(
			Id_Usuario, Accion, Descripción, Fecha
			)
			SELECT
			@IdUsuario_Global, @ACC, RTRIM(LTRIM(@DSC)) , GETDATE()
			-----------------------PARA EL CONTROL DE AUDITORIA DEL SISTEMA-------------------------------------------



		DELETE FROM Hoteles
		WHERE Id_Hotel=@IdHotel

		SELECT @IdHotel
	END
	ELSE
	BEGIN
		SELECT -1
	END
END TRY 
BEGIN CATCH
	SELECT 0
END CATCH
END
GO