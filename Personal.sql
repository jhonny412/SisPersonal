USE [master]
GO
/****** Object:  Database [Control_Personal]    Script Date: 05/09/2017 08:36:01  ******/
CREATE DATABASE [Control_Personal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Control_Personal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Control_Personal.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Control_Personal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Control_Personal_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Control_Personal] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Control_Personal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Control_Personal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Control_Personal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Control_Personal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Control_Personal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Control_Personal] SET ARITHABORT OFF 
GO
ALTER DATABASE [Control_Personal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Control_Personal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Control_Personal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Control_Personal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Control_Personal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Control_Personal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Control_Personal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Control_Personal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Control_Personal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Control_Personal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Control_Personal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Control_Personal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Control_Personal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Control_Personal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Control_Personal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Control_Personal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Control_Personal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Control_Personal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Control_Personal] SET  MULTI_USER 
GO
ALTER DATABASE [Control_Personal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Control_Personal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Control_Personal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Control_Personal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Control_Personal] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Control_Personal', N'ON'
GO
ALTER DATABASE [Control_Personal] SET QUERY_STORE = OFF
GO
USE [Control_Personal]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Control_Personal]
GO
/****** Object:  Table [dbo].[Marcaciones]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcaciones](
	[Id_Marcacion] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empleado] [char](10) NOT NULL,
	[Fecha] [date] NOT NULL,
	[H_Ingreso] [time](7) NOT NULL,
	[HS_Refrigerio] [time](7) NOT NULL,
	[HI_Refrigerio] [time](7) NOT NULL,
	[H_Salida] [time](7) NOT NULL,
	[TH_Refrigerio] [char](10) NOT NULL,
	[TH_Trabajadas] [char](10) NOT NULL,
 CONSTRAINT [PK_Marcaciones] PRIMARY KEY CLUSTERED 
(
	[Id_Marcacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[ID_Empleado] [char](10) NOT NULL,
	[Ape_Paterno] [varchar](50) NOT NULL,
	[Ape_Materno] [varchar](50) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[DNI] [char](8) NOT NULL,
	[Direccion] [varchar](150) NULL,
	[Foto] [binary](150) NULL,
	[Estado] [bit] NOT NULL,
	[SBasicoHora] [money] NULL,
	[SHorasExtraHora] [money] NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[ID_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vMarcaciones]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vMarcaciones]
AS
SELECT        dbo.Empleados.Ape_Paterno, dbo.Empleados.Ape_Materno, dbo.Empleados.Nombres, dbo.Marcaciones.Fecha, dbo.Marcaciones.H_Ingreso, dbo.Marcaciones.HS_Refrigerio, dbo.Marcaciones.HI_Refrigerio, 
                         dbo.Marcaciones.H_Salida, dbo.Marcaciones.TH_Refrigerio, dbo.Marcaciones.TH_Trabajadas
FROM            dbo.Empleados INNER JOIN
                         dbo.Marcaciones ON dbo.Empleados.ID_Empleado = dbo.Marcaciones.Id_Empleado
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [char](25) NOT NULL,
	[Clave] [char](25) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Perfil] [char](25) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vUsuarios]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vUsuarios]
AS
SELECT        IdUsuario, Usuario, Clave, Estado, Perfil
FROM            dbo.Usuarios
GO
/****** Object:  Table [dbo].[Faltas]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faltas](
	[Id_Faltas] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empleado] [char](10) NOT NULL,
	[TH_Faltas] [date] NOT NULL,
	[SPF] [money] NOT NULL,
	[TD_Faltas] [money] NOT NULL,
	[Descuento] [money] NULL,
 CONSTRAINT [PK_Faltas] PRIMARY KEY CLUSTERED 
(
	[Id_Faltas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horas_Extras]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horas_Extras](
	[Id_HExtra] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empleado] [char](10) NOT NULL,
	[HE_Ingreso] [date] NOT NULL,
	[HE_Salida] [date] NOT NULL,
	[THE_Trabajadas] [date] NOT NULL,
	[SH_Extras] [money] NOT NULL,
	[Motivo] [varchar](50) NULL,
 CONSTRAINT [PK_Horas_Extras] PRIMARY KEY CLUSTERED 
(
	[Id_HExtra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salario]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salario](
	[Id_Salario] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empleado] [char](10) NOT NULL,
	[STH_Normales] [money] NOT NULL,
	[STH_Extras] [money] NOT NULL,
	[T_Descuento] [money] NOT NULL,
	[S_Total] [money] NOT NULL,
 CONSTRAINT [PK_Salario] PRIMARY KEY CLUSTERED 
(
	[Id_Salario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tardanzas]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tardanzas](
	[Id_Tardanza] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empleado] [char](10) NOT NULL,
	[TH_Tardanza] [date] NULL,
	[SH_Tardanza] [money] NULL,
	[TT_Descuento] [money] NULL,
	[Motivo] [varchar](50) NULL,
 CONSTRAINT [PK_Tardanzas] PRIMARY KEY CLUSTERED 
(
	[Id_Tardanza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Empleados]    Script Date: 05/09/2017 08:36:01  ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Empleados] ON [dbo].[Empleados]
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Faltas]  WITH CHECK ADD  CONSTRAINT [FK_Faltas_Empleados] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleados] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Faltas] CHECK CONSTRAINT [FK_Faltas_Empleados]
GO
ALTER TABLE [dbo].[Horas_Extras]  WITH CHECK ADD  CONSTRAINT [FK_Horas_Extras_Empleados] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleados] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Horas_Extras] CHECK CONSTRAINT [FK_Horas_Extras_Empleados]
GO
ALTER TABLE [dbo].[Marcaciones]  WITH CHECK ADD  CONSTRAINT [FK_Marcaciones_Empleados] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleados] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Marcaciones] CHECK CONSTRAINT [FK_Marcaciones_Empleados]
GO
ALTER TABLE [dbo].[Salario]  WITH CHECK ADD  CONSTRAINT [FK_Salario_Empleados] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleados] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Salario] CHECK CONSTRAINT [FK_Salario_Empleados]
GO
ALTER TABLE [dbo].[Tardanzas]  WITH CHECK ADD  CONSTRAINT [FK_Tardanzas_Empleados] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleados] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Tardanzas] CHECK CONSTRAINT [FK_Tardanzas_Empleados]
GO
/****** Object:  StoredProcedure [dbo].[spAbcUsuario]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAbcUsuario]
@Accion varchar(15),
@IdUsuario int,
@Usuario char(25),
@Clave char(25),
@Estado bit,
@Perfil char(25)
AS
IF @Accion='INSERTAR'
	BEGIN
		INSERT INTO Usuarios(Usuario,Clave,Estado,Perfil)
		VALUES(@Usuario,HASHBYTES('MD5',@Clave),@Estado,@Perfil)
	END
IF @Accion='ELIMINAR'
	BEGIN
		--DELETE FROM Usuarios WHERE IdUsuario=@IdUsuario
		UPDATE Usuarios SET Usuario=@Usuario, Clave=@Clave, Estado=0,Perfil=@Perfil
		WHERE IdUsuario=@IdUsuario
	END
IF @Accion='ACTUALIZAR'
	BEGIN
		UPDATE Usuarios SET Usuario=@Usuario, Clave=HASHBYTES('MD5',@Clave), Estado=@Estado,Perfil=@Perfil
		WHERE IdUsuario=@IdUsuario
	END
RETURN
GO
/****** Object:  StoredProcedure [dbo].[spBuscarEmpleado]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spBuscarEmpleado]
@dni char(8)
as
select e.Nombres + ' ' + e.Ape_Paterno + ' ' + e.Ape_Materno as [Nombres y Apellidos] from Empleados E
where DNI=@dni
GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spLogin]
@usuario char(35),
@clave char(25)
as
select U.usuario,u.Clave,U.Estado,U.Perfil from Usuarios U
	WHERE Usuario=@usuario and Clave=@clave
GO
/****** Object:  StoredProcedure [dbo].[spMarcaciones]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spMarcaciones]
@fecha1 date,
@fecha2 date
as
SELECT      dbo.Empleados.Ape_Paterno,dbo.Empleados.Ape_Materno,dbo.Empleados.Nombres,
			CONVERT(char(10),Marcaciones.Fecha,103)as Fecha,dbo.Marcaciones.H_Ingreso, dbo.Marcaciones.HS_Refrigerio, 
			dbo.Marcaciones.HI_Refrigerio, dbo.Marcaciones.H_Salida, dbo.Marcaciones.TH_Refrigerio, 
			dbo.Marcaciones.TH_Trabajadas
FROM        dbo.Empleados INNER JOIN
						 dbo.Marcaciones ON dbo.Empleados.ID_Empleado = dbo.Marcaciones.Id_Empleado
WHERE Fecha between @fecha1 and @fecha2
ORDER BY Marcaciones.Fecha

--select convert(char(10),Marcaciones.Fecha,103) from Marcaciones
--Permite mostrar la fecha en formato corto
--CONVERT (char(10), getdate(), 102

--execute spMarcaciones '01/01/2017','28/08/2017'
GO
/****** Object:  StoredProcedure [dbo].[spUltimoUsuario]    Script Date: 05/09/2017 08:36:01  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[spUltimoUsuario]
as
SELECT TOP 1 U.IdUsuario
	FROM Usuarios U
	ORDER BY U.IdUsuario DESC
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[36] 4[16] 2[22] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Empleados"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 209
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Marcaciones"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 210
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vMarcaciones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vMarcaciones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[35] 4[26] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 174
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1530
         Width = 1530
         Width = 720
         Width = 1500
         Width = 2655
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUsuarios'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUsuarios'
GO
USE [master]
GO
ALTER DATABASE [Control_Personal] SET  READ_WRITE 
GO
