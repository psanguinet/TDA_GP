USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[ResultadoAnalisis]    Script Date: 15/03/16 12:21:30 AM ******/
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
ALTER TABLE [dbo].[ResultadoAnalisis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResultadoAnalisis_dbo.AnalisisClinicoes_AnalisisClinico_AnalisisClinicoID] FOREIGN KEY([AnalisisClinico_AnalisisClinicoID])
REFERENCES [dbo].[AnalisisClinicoes] ([AnalisisClinicoID])
GO
ALTER TABLE [dbo].[ResultadoAnalisis] CHECK CONSTRAINT [FK_dbo.ResultadoAnalisis_dbo.AnalisisClinicoes_AnalisisClinico_AnalisisClinicoID]
GO
