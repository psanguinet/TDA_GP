USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[RoleUsers]    Script Date: 15/03/16 12:21:30 AM ******/
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
