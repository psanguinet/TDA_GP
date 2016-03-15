USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[EspecialidadDoctors]    Script Date: 15/03/16 12:21:30 AM ******/
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
