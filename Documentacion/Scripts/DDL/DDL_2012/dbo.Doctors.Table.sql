USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 15/03/16 12:21:30 AM ******/
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
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Doctors_dbo.Users_Usuario_UserId] FOREIGN KEY([Usuario_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_dbo.Doctors_dbo.Users_Usuario_UserId]
GO
