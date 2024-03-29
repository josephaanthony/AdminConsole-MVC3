--USE [D:\JOE\PROJECTS\ADMINCONSOLE\ADMINCONSOLE\APP_DATA\ADMINCONSOLE.MDF]
GO
/****** Object:  Table [dbo].[EdmMetadata_OLD]    Script Date: 06/19/2012 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EdmMetadata_OLD](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelHash] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Desktop]    Script Date: 06/19/2012 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desktop](
	[DesktopCode] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ExtendedProperty] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[DesktopCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetType]    Script Date: 06/19/2012 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetType](
	[TargetTypeCode] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetTypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetContainer]    Script Date: 06/19/2012 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetContainer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Sequence] [smallint] NOT NULL,
	[InheritsParent] [bit] NOT NULL,
	[ExtendedProperty] [nvarchar](max) NULL,
	[ParentTargetContainer_Id] [int] NULL,
	[DesktopType_DesktopCode] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Target]    Script Date: 06/19/2012 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Target](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[TargetType_TargetTypeCode] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetTargetContainer]    Script Date: 06/19/2012 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetTargetContainer](
	[Target_Id] [int] NOT NULL,
	[TargetContainer_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Target_Id] ASC,
	[TargetContainer_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [TargetType_Targets]    Script Date: 06/19/2012 23:57:46 ******/
ALTER TABLE [dbo].[Target]  WITH CHECK ADD  CONSTRAINT [TargetType_Targets] FOREIGN KEY([TargetType_TargetTypeCode])
REFERENCES [dbo].[TargetType] ([TargetTypeCode])
GO
ALTER TABLE [dbo].[Target] CHECK CONSTRAINT [TargetType_Targets]
GO
/****** Object:  ForeignKey [TargetContainer_ChildTargetContainers]    Script Date: 06/19/2012 23:57:46 ******/
ALTER TABLE [dbo].[TargetContainer]  WITH CHECK ADD  CONSTRAINT [TargetContainer_ChildTargetContainers] FOREIGN KEY([ParentTargetContainer_Id])
REFERENCES [dbo].[TargetContainer] ([Id])
GO
ALTER TABLE [dbo].[TargetContainer] CHECK CONSTRAINT [TargetContainer_ChildTargetContainers]
GO
/****** Object:  ForeignKey [TargetContainer_Desktop]    Script Date: 06/19/2012 23:57:46 ******/
ALTER TABLE [dbo].[TargetContainer]  WITH CHECK ADD  CONSTRAINT [TargetContainer_Desktop] FOREIGN KEY([DesktopType_DesktopCode])
REFERENCES [dbo].[Desktop] ([DesktopCode])
GO
ALTER TABLE [dbo].[TargetContainer] CHECK CONSTRAINT [TargetContainer_Desktop]
GO
/****** Object:  ForeignKey [Target_TargetContainers_Source]    Script Date: 06/19/2012 23:57:46 ******/
ALTER TABLE [dbo].[TargetTargetContainer]  WITH CHECK ADD  CONSTRAINT [Target_TargetContainers_Source] FOREIGN KEY([Target_Id])
REFERENCES [dbo].[Target] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TargetTargetContainer] CHECK CONSTRAINT [Target_TargetContainers_Source]
GO
/****** Object:  ForeignKey [Target_TargetContainers_Target]    Script Date: 06/19/2012 23:57:46 ******/
ALTER TABLE [dbo].[TargetTargetContainer]  WITH CHECK ADD  CONSTRAINT [Target_TargetContainers_Target] FOREIGN KEY([TargetContainer_Id])
REFERENCES [dbo].[TargetContainer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TargetTargetContainer] CHECK CONSTRAINT [Target_TargetContainers_Target]
GO
