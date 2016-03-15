USE [master]
GO
/****** Object:  Database [OBLIGATORIO]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE DATABASE [OBLIGATORIO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OBLIGATORIO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\OBLIGATORIO.mdf' , SIZE = 6336KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OBLIGATORIO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\OBLIGATORIO_log.ldf' , SIZE = 5824KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OBLIGATORIO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OBLIGATORIO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET ARITHABORT OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OBLIGATORIO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OBLIGATORIO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OBLIGATORIO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OBLIGATORIO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OBLIGATORIO] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [OBLIGATORIO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OBLIGATORIO] SET  MULTI_USER 
GO
ALTER DATABASE [OBLIGATORIO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OBLIGATORIO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OBLIGATORIO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OBLIGATORIO] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[AgendaID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Paciente_PacienteID] [int] NOT NULL,
	[Doctor_DoctorID] [int] NOT NULL,
	[Hora] [nvarchar](max) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_dbo.Agenda] PRIMARY KEY CLUSTERED 
(
	[AgendaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AnalisisClinicoes]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnalisisClinicoes](
	[AnalisisClinicoID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Detalle] [nvarchar](max) NULL,
	[Doctor_DoctorID] [int] NULL,
	[Paciente_PacienteID] [int] NULL,
 CONSTRAINT [PK_dbo.AnalisisClinicoes] PRIMARY KEY CLUSTERED 
(
	[AnalisisClinicoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Doctors](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Cedula] [nvarchar](max) NOT NULL,
	[Foto] [varbinary](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
	[ValorConsulta] [decimal](18, 2) NOT NULL,
	[EsDirector] [bit] NOT NULL,
	[SueldoMinimo] [decimal](18, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
	[Usuario_UserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Doctors] PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EspecialidadDoctors]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EspecialidadDoctors](
	[Especialidad_EspecilidadID] [int] NOT NULL,
	[Doctor_DoctorID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.EspecialidadDoctors] PRIMARY KEY CLUSTERED 
(
	[Especialidad_EspecilidadID] ASC,
	[Doctor_DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Especialidads]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidads](
	[EspecilidadID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Especialidads] PRIMARY KEY CLUSTERED 
(
	[EspecilidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InformesDeConsultas]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformesDeConsultas](
	[InformesDeConsultaID] [int] IDENTITY(1,1) NOT NULL,
	[Motivo] [nvarchar](max) NOT NULL,
	[Detalle] [nvarchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Doctor_DoctorID] [int] NULL,
	[Paciente_PacienteID] [int] NULL,
 CONSTRAINT [PK_dbo.InformesDeConsultas] PRIMARY KEY CLUSTERED 
(
	[InformesDeConsultaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LiquidacionDeSueldoes]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiquidacionDeSueldoes](
	[LiquidacionID] [int] IDENTITY(1,1) NOT NULL,
	[FechaRealizacion] [datetime] NOT NULL,
	[Mes] [int] NOT NULL,
	[Anio] [int] NOT NULL,
	[Importe] [int] NOT NULL,
	[Doctor_DoctorID] [int] NULL,
 CONSTRAINT [PK_dbo.LiquidacionDeSueldoes] PRIMARY KEY CLUSTERED 
(
	[LiquidacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pacientes](
	[PacienteID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Cedula] [nvarchar](9) NOT NULL,
	[Foto] [varbinary](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](10) NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Altura] [int] NOT NULL,
	[GrupoSanguineo] [nvarchar](max) NULL,
	[Peso] [int] NOT NULL,
	[Usuario_UserId] [uniqueidentifier] NULL,
	[Activo] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Pacientes] PRIMARY KEY CLUSTERED 
(
	[PacienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ResultadoAnalisis]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultadoAnalisis](
	[ResultadoAnalisisID] [int] IDENTITY(1,1) NOT NULL,
	[Nobmre] [nvarchar](max) NOT NULL,
	[Resultado] [nvarchar](max) NOT NULL,
	[AnalisisClinico_AnalisisClinicoID] [int] NULL,
 CONSTRAINT [PK_dbo.ResultadoAnalisis] PRIMARY KEY CLUSTERED 
(
	[ResultadoAnalisisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleUsers]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUsers](
	[Role_RoleId] [uniqueidentifier] NOT NULL,
	[User_UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.RoleUsers] PRIMARY KEY CLUSTERED 
(
	[Role_RoleId] ASC,
	[User_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 15/03/16 12:33:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](12) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[IsApproved] [bit] NOT NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[LastActivityDate] [datetime] NULL,
	[LastLockoutDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[IsLockedOut] [bit] NOT NULL,
	[LastPasswordChangedDate] [datetime] NULL,
	[PasswordVerificationToken] [nvarchar](max) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Doctor_DoctorID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_DoctorID] ON [dbo].[Agenda]
(
	[Doctor_DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Paciente_PacienteID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Paciente_PacienteID] ON [dbo].[Agenda]
(
	[Paciente_PacienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Doctor_DoctorID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_DoctorID] ON [dbo].[AnalisisClinicoes]
(
	[Doctor_DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Paciente_PacienteID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Paciente_PacienteID] ON [dbo].[AnalisisClinicoes]
(
	[Paciente_PacienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_UserId]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_UserId] ON [dbo].[Doctors]
(
	[Usuario_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Doctor_DoctorID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_DoctorID] ON [dbo].[EspecialidadDoctors]
(
	[Doctor_DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Especialidad_EspecilidadID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Especialidad_EspecilidadID] ON [dbo].[EspecialidadDoctors]
(
	[Especialidad_EspecilidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Doctor_DoctorID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_DoctorID] ON [dbo].[InformesDeConsultas]
(
	[Doctor_DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Paciente_PacienteID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Paciente_PacienteID] ON [dbo].[InformesDeConsultas]
(
	[Paciente_PacienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Doctor_DoctorID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_DoctorID] ON [dbo].[LiquidacionDeSueldoes]
(
	[Doctor_DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_UserId]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_UserId] ON [dbo].[Pacientes]
(
	[Usuario_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AnalisisClinico_AnalisisClinicoID]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AnalisisClinico_AnalisisClinicoID] ON [dbo].[ResultadoAnalisis]
(
	[AnalisisClinico_AnalisisClinicoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Role_RoleId]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Role_RoleId] ON [dbo].[RoleUsers]
(
	[Role_RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_UserId]    Script Date: 15/03/16 12:33:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_User_UserId] ON [dbo].[RoleUsers]
(
	[User_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Agenda_dbo.Doctors_Doctor_DoctorID] FOREIGN KEY([Doctor_DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_dbo.Agenda_dbo.Doctors_Doctor_DoctorID]
GO
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Agenda_dbo.Pacientes_Paciente_PacienteID] FOREIGN KEY([Paciente_PacienteID])
REFERENCES [dbo].[Pacientes] ([PacienteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_dbo.Agenda_dbo.Pacientes_Paciente_PacienteID]
GO
ALTER TABLE [dbo].[AnalisisClinicoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AnalisisClinicoes_dbo.Doctors_Doctor_DoctorID] FOREIGN KEY([Doctor_DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
GO
ALTER TABLE [dbo].[AnalisisClinicoes] CHECK CONSTRAINT [FK_dbo.AnalisisClinicoes_dbo.Doctors_Doctor_DoctorID]
GO
ALTER TABLE [dbo].[AnalisisClinicoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AnalisisClinicoes_dbo.Pacientes_Paciente_PacienteID] FOREIGN KEY([Paciente_PacienteID])
REFERENCES [dbo].[Pacientes] ([PacienteID])
GO
ALTER TABLE [dbo].[AnalisisClinicoes] CHECK CONSTRAINT [FK_dbo.AnalisisClinicoes_dbo.Pacientes_Paciente_PacienteID]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Doctors_dbo.Users_Usuario_UserId] FOREIGN KEY([Usuario_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_dbo.Doctors_dbo.Users_Usuario_UserId]
GO
ALTER TABLE [dbo].[EspecialidadDoctors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EspecialidadDoctors_dbo.Doctors_Doctor_DoctorID] FOREIGN KEY([Doctor_DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EspecialidadDoctors] CHECK CONSTRAINT [FK_dbo.EspecialidadDoctors_dbo.Doctors_Doctor_DoctorID]
GO
ALTER TABLE [dbo].[EspecialidadDoctors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EspecialidadDoctors_dbo.Especialidads_Especialidad_EspecilidadID] FOREIGN KEY([Especialidad_EspecilidadID])
REFERENCES [dbo].[Especialidads] ([EspecilidadID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EspecialidadDoctors] CHECK CONSTRAINT [FK_dbo.EspecialidadDoctors_dbo.Especialidads_Especialidad_EspecilidadID]
GO
ALTER TABLE [dbo].[InformesDeConsultas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.InformesDeConsultas_dbo.Doctors_Doctor_DoctorID] FOREIGN KEY([Doctor_DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
GO
ALTER TABLE [dbo].[InformesDeConsultas] CHECK CONSTRAINT [FK_dbo.InformesDeConsultas_dbo.Doctors_Doctor_DoctorID]
GO
ALTER TABLE [dbo].[InformesDeConsultas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.InformesDeConsultas_dbo.Pacientes_Paciente_PacienteID] FOREIGN KEY([Paciente_PacienteID])
REFERENCES [dbo].[Pacientes] ([PacienteID])
GO
ALTER TABLE [dbo].[InformesDeConsultas] CHECK CONSTRAINT [FK_dbo.InformesDeConsultas_dbo.Pacientes_Paciente_PacienteID]
GO
ALTER TABLE [dbo].[LiquidacionDeSueldoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LiquidacionDeSueldoes_dbo.Doctors_Doctor_DoctorID] FOREIGN KEY([Doctor_DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
GO
ALTER TABLE [dbo].[LiquidacionDeSueldoes] CHECK CONSTRAINT [FK_dbo.LiquidacionDeSueldoes_dbo.Doctors_Doctor_DoctorID]
GO
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pacientes_dbo.Users_Usuario_UserId] FOREIGN KEY([Usuario_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_dbo.Pacientes_dbo.Users_Usuario_UserId]
GO
ALTER TABLE [dbo].[ResultadoAnalisis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResultadoAnalisis_dbo.AnalisisClinicoes_AnalisisClinico_AnalisisClinicoID] FOREIGN KEY([AnalisisClinico_AnalisisClinicoID])
REFERENCES [dbo].[AnalisisClinicoes] ([AnalisisClinicoID])
GO
ALTER TABLE [dbo].[ResultadoAnalisis] CHECK CONSTRAINT [FK_dbo.ResultadoAnalisis_dbo.AnalisisClinicoes_AnalisisClinico_AnalisisClinicoID]
GO
ALTER TABLE [dbo].[RoleUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleUsers_dbo.Roles_Role_RoleId] FOREIGN KEY([Role_RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleUsers] CHECK CONSTRAINT [FK_dbo.RoleUsers_dbo.Roles_Role_RoleId]
GO
ALTER TABLE [dbo].[RoleUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleUsers_dbo.Users_User_UserId] FOREIGN KEY([User_UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleUsers] CHECK CONSTRAINT [FK_dbo.RoleUsers_dbo.Users_User_UserId]
GO
USE [master]
GO
ALTER DATABASE [OBLIGATORIO] SET  READ_WRITE 
GO
