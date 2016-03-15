USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 15/03/16 12:21:30 AM ******/
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
