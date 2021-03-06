


USE [miempresa]
GO
/****** Object:  StoredProcedure [dbo].[actualizarDia]    Script Date: 15/12/2016 10:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 15/12/2016 10:49:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DiaLaboral](
	[IdDiaLaboral] [int] NOT NULL,
	[Empleado] [int] NULL,
	[HoraEntrada] [int] NULL,
	[HoraSalida] [int] NULL,
	[FechaDia] [date] NULL,
	[Asistencia] [varchar](10) NULL,
 CONSTRAINT [PK_DiaLaboral] PRIMARY KEY CLUSTERED 
(
	[IdDiaLaboral] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 15/12/2016 10:49:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] NOT NULL,
	[CURP] [varchar](20) NULL,
	[Nombres] [varchar](20) NULL,
	[ApellidoPaterno] [varchar](20) NULL,
	[ApellidoMaterno] [varchar](20) NULL,
	[FechaNacimiento] [date] NULL,
	[Email] [varchar](20) NULL,
	[Celular] [varchar](20) NULL,
	[Fotografia] [image] NULL,
	[IdTarjeta] [varchar](20) NULL,
	[Puesto] [varchar](20) NULL,
	[Departamento] [varchar](20) NULL,
	[HoraEntrada] [time](0) NULL,
	[HoraSalida] [time](0) NULL,
	[DiaLibre] [varchar](20) NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntradaLaboral]    Script Date: 15/12/2016 10:49:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntradaLaboral](
	[IdHoraEntrada] [int] NOT NULL,
	[Empleado] [int] NULL,
	[HoraEntrada] [time](0) NULL,
	[FechaEntrada] [date] NULL,
 CONSTRAINT [PK_EntradaLaboral] PRIMARY KEY CLUSTERED 
(
	[IdHoraEntrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalidaLaboral]    Script Date: 15/12/2016 10:49:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalidaLaboral](
	[IdHoraSalida] [int] NOT NULL,
	[Empleado] [int] NULL,
	[HoraSalida] [time](0) NULL,
	[FechaSalida] [date] NULL,
 CONSTRAINT [PK_SalidaLaboral] PRIMARY KEY CLUSTERED 
(
	[IdHoraSalida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DiaLaboral]  WITH CHECK ADD  CONSTRAINT [FK_DiaLaboral_Empleado] FOREIGN KEY([Empleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[DiaLaboral] CHECK CONSTRAINT [FK_DiaLaboral_Empleado]
GO
ALTER TABLE [dbo].[DiaLaboral]  WITH CHECK ADD  CONSTRAINT [FK_DiaLaboral_EntradaLaboral] FOREIGN KEY([HoraEntrada])
REFERENCES [dbo].[EntradaLaboral] ([IdHoraEntrada])
GO
ALTER TABLE [dbo].[DiaLaboral] CHECK CONSTRAINT [FK_DiaLaboral_EntradaLaboral]
GO
ALTER TABLE [dbo].[DiaLaboral]  WITH CHECK ADD  CONSTRAINT [FK_DiaLaboral_SalidaLaboral] FOREIGN KEY([HoraSalida])
REFERENCES [dbo].[SalidaLaboral] ([IdHoraSalida])
GO
ALTER TABLE [dbo].[DiaLaboral] CHECK CONSTRAINT [FK_DiaLaboral_SalidaLaboral]
GO
ALTER TABLE [dbo].[EntradaLaboral]  WITH CHECK ADD  CONSTRAINT [FK_EntradaLaboral_Empleado] FOREIGN KEY([Empleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[EntradaLaboral] CHECK CONSTRAINT [FK_EntradaLaboral_Empleado]
GO
ALTER TABLE [dbo].[SalidaLaboral]  WITH CHECK ADD  CONSTRAINT [FK_SalidaLaboral_Empleado] FOREIGN KEY([Empleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[SalidaLaboral] CHECK CONSTRAINT [FK_SalidaLaboral_Empleado]
GO


GO
-- =============================================
-- Author:		Jorge Guzman Juarez
-- Create date: 15/12/2016 10:49:17
-- Description:	Procedimiento para realizar un update a un registro de la tabla DiaLaboral
-- =============================================
CREATE PROCEDURE [dbo].[actualizarDia]( 
	-- Add the parameters for the stored procedure here
	@IdDia int,
	@Asistencia varchar(10)
	)
AS
BEGIN
	UPDATE DiaLaboral SET 
		Asistencia=@Asistencia
	WHERE IdDiaLaboral = @IdDia;
END;

