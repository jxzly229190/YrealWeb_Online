USE [YrealWeb]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 06/12/2014 20:24:35 ******/
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
/****** Object:  Table [dbo].[Channel]    Script Date: 06/12/2014 20:24:35 ******/
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
SET IDENTITY_INSERT [dbo].[Channel] ON
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (1, N'企业简介', 1, 2, N'About', 0, 0, 1, CAST(0x0000A348012251D3 AS DateTime), CAST(0x0000A348012251D3 AS DateTime), NULL, NULL, N'企业简介', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (2, N'关于我们', 1, 0, N'Aboutus', 1, 0, 1, CAST(0x0000A34801230A69 AS DateTime), CAST(0x0000A34801230A69 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (3, N'媒体报道', 1, 1, N'media', 1, 1, 2, CAST(0x0000A3480123FE6E AS DateTime), CAST(0x0000A3480123FE6E AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (4, N'新闻资讯', 1, 2, N'News', 0, 0, 5, CAST(0x0000A3480124AD66 AS DateTime), CAST(0x0000A3480124AD66 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (5, N'公司新闻', 1, 1, N'Company', 4, 0, 1, CAST(0x0000A34801261D73 AS DateTime), CAST(0x0000A34801261D73 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (6, N'行业动态', 1, 1, N'dongtai', 4, 0, 2, CAST(0x0000A34801266539 AS DateTime), CAST(0x0000A34801266539 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (7, N'典型案例', 2, 2, N'Case', 0, 0, 10, CAST(0x0000A3480126ADBC AS DateTime), CAST(0x0000A3480126ADBC AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (8, N'产品服务', 1, 2, N'Product', 0, 0, 20, CAST(0x0000A3480127252B AS DateTime), CAST(0x0000A3480127252B AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (9, N'ERP系统', 2, 0, N'ERP', 8, 0, 21, CAST(0x0000A34801277A33 AS DateTime), CAST(0x0000A34801277A33 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (10, N'企业网站', 2, 0, N'Web', 8, 0, 2, CAST(0x0000A3480127F666 AS DateTime), CAST(0x0000A3480127F666 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (11, N'服务说明', 1, 1, N'Service', 8, 0, 3, CAST(0x0000A3480128563E AS DateTime), CAST(0x0000A3480128563E AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (12, N'问题反馈', 1, 2, N'question', 0, 0, 30, CAST(0x0000A3480128A661 AS DateTime), CAST(0x0000A3480128A661 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (13, N'联系我们', 1, 0, N'Contact', 0, 0, 40, CAST(0x0000A3480128D415 AS DateTime), CAST(0x0000A3480128D415 AS DateTime), NULL, NULL, N'', NULL)
SET IDENTITY_INSERT [dbo].[Channel] OFF
/****** Object:  Table [dbo].[Admin]    Script Date: 06/12/2014 20:24:35 ******/
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
SET IDENTITY_INSERT [dbo].[Admin] ON
INSERT [dbo].[Admin] ([ID], [LoginName], [Password], [Name], [Mob], [Email], [QQ], [Remark], [State], [Ext], [CreateDate], [ModifyDate]) VALUES (1, N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'张连印', N'13581968235', N'jx-zly@live.cn', N'562758404', N'', 0, NULL, CAST(0x0000A348011F3877 AS DateTime), CAST(0x0000A348011F3878 AS DateTime))
SET IDENTITY_INSERT [dbo].[Admin] OFF
/****** Object:  Default [DF_Admin_State]    Script Date: 06/12/2014 20:24:35 ******/
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_State]  DEFAULT ((0)) FOR [State]
GO
/****** Object:  Default [DF_Channel_Type]    Script Date: 06/12/2014 20:24:35 ******/
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_Type]  DEFAULT ((1)) FOR [Type]
GO
/****** Object:  Default [DF_Channel_ParentId]    Script Date: 06/12/2014 20:24:35 ******/
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO
/****** Object:  Default [DF_Channel_Sort]    Script Date: 06/12/2014 20:24:35 ******/
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_Sort]  DEFAULT ((0)) FOR [Sort]
GO
/****** Object:  Default [DF_Content_State]    Script Date: 06/12/2014 20:24:35 ******/
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_State]  DEFAULT ((0)) FOR [State]
GO
