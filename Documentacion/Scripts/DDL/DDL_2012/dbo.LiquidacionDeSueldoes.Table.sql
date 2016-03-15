USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[LiquidacionDeSueldoes]    Script Date: 15/03/16 12:21:30 AM ******/
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
ALTER TABLE [dbo].[LiquidacionDeSueldoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LiquidacionDeSueldoes_dbo.Doctors_Doctor_DoctorID] FOREIGN KEY([Doctor_DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
GO
ALTER TABLE [dbo].[LiquidacionDeSueldoes] CHECK CONSTRAINT [FK_dbo.LiquidacionDeSueldoes_dbo.Doctors_Doctor_DoctorID]
GO
