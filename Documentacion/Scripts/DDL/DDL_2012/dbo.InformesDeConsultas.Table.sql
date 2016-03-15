USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[InformesDeConsultas]    Script Date: 15/03/16 12:21:30 AM ******/
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
