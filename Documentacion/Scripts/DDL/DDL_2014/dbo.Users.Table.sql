USE [OBLIGATORIO]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15/03/16 12:14:53 AM ******/
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
