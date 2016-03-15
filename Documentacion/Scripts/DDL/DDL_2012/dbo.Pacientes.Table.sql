USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 15/03/16 12:21:30 AM ******/
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
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pacientes_dbo.Users_Usuario_UserId] FOREIGN KEY([Usuario_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_dbo.Pacientes_dbo.Users_Usuario_UserId]
GO
