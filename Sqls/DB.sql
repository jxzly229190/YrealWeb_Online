USE [YrealWeb]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 06/12/2014 13:10:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Content](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChannelID] [int] NOT NULL,
	[ChannelName] [varchar](50) NOT NULL,
	[ChannelCode] [varchar](50) NULL,
	[Type] [int] NOT NULL,
	[ImageUrls] [nvarchar](2000) NULL,
	[Title] [nvarchar](200) NOT NULL,
	[ContentText] [text] NOT NULL,
	[Url] [nvarchar](500) NULL,
	[Attributes] [nvarchar](20) NULL,
	[State] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[Remark] [nvarchar](500) NULL,
	[Ext] [nvarchar](500) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类容类型，1-不带封面，2-带封面' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Content', @level2type=N'COLUMN',@level2name=N'Type'
GO
/****** Object:  Table [dbo].[Channel]    Script Date: 06/12/2014 13:10:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Channel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContentType] [int] NOT NULL,
	[Type] [int] NULL,
	[Code] [varchar](50) NULL,
	[ParentId] [int] NULL,
	[State] [int] NOT NULL,
	[Sort] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[Remark] [nvarchar](500) NULL,
	[Ext] [nvarchar](500) NULL,
 CONSTRAINT [PK_Channel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类容类型，1-不带封面，2-带封面' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Channel', @level2type=N'COLUMN',@level2name=N'ContentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目类型：0-单独页面,1-内容列表页，2-栏目列表页' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Channel', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Channel', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态:0-菜单显示,1-菜单不显示,2-不可用,255-删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Channel', @level2type=N'COLUMN',@level2name=N'State'
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 06/12/2014 13:10:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [varchar](32) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Mob] [varchar](16) NULL,
	[Email] [nvarchar](200) NULL,
	[QQ] [varchar](16) NULL,
	[Remark] [nvarchar](500) NULL,
	[State] [int] NOT NULL,
	[Ext] [nvarchar](500) NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Admin_State]    Script Date: 06/12/2014 13:10:41 ******/
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_State]  DEFAULT ((0)) FOR [State]
GO
/****** Object:  Default [DF_Channel_Type]    Script Date: 06/12/2014 13:10:41 ******/
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_Type]  DEFAULT ((1)) FOR [Type]
GO
/****** Object:  Default [DF_Channel_ParentId]    Script Date: 06/12/2014 13:10:41 ******/
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO
/****** Object:  Default [DF_Channel_Sort]    Script Date: 06/12/2014 13:10:41 ******/
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_Sort]  DEFAULT ((0)) FOR [Sort]
GO
/****** Object:  Default [DF_Content_State]    Script Date: 06/12/2014 13:10:41 ******/
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_State]  DEFAULT ((0)) FOR [State]
GO
