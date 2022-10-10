USE [BugTracker]
GO

/****** Object:  Table [dbo].[User] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[admin_id] [nvarchar](30) NULL,
	[Ad_Password] [nvarchar](30) NULL,
	[First_Name] [nvarchar](50) NULL,
	[Last_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into [User] (admin_id, Ad_Password, First_name, Last_name)
values ('admin','admin','admin', 'admin')

USE [BugTracker]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Login]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_Login]
@Admin_id NVARCHAR(100),
@Password NVARCHAR(100),
@Isvalid BIT OUT
AS
BEGIN
SET @Isvalid = (SELECT COUNT(1) FROM [user] WHERE Admin_id = @Admin_id AND Ad_Password=@Password)
end
GO


USE [BugTracker]
GO

/****** Object:  Table [dbo].[bugtracker]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[bugtracker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ReportedBy] [nvarchar](30) NOT NULL,
	[AssignedTo] [nvarchar](30) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_bugtracker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[bugtracker] ADD  CONSTRAINT [DF__bugtracke__Creat__4CA06362]  DEFAULT (getdate()) FOR [CreationDate]
GO


