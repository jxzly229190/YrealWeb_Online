USE [Web]
GO
/****** Object:  Table [dbo].[GlobeConfig]    Script Date: 11/24/2015 20:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GlobeConfig](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](64) NULL,
	[Description] [nvarchar](4000) NULL,
	[Text] [nvarchar](max) NULL,
	[State] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_GlobeConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[GlobeConfig] ON
INSERT [dbo].[GlobeConfig] ([ID], [Code], [Description], [Text], [State], [CreateDate]) VALUES (1, N'SiteName', N'我的网站', N'我的网站的Text', 0, CAST(0x0000A55A014B711D AS DateTime))
SET IDENTITY_INSERT [dbo].[GlobeConfig] OFF
/****** Object:  Table [dbo].[Content]    Script Date: 11/24/2015 20:48:20 ******/
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
SET IDENTITY_INSERT [dbo].[Content] ON
INSERT [dbo].[Content] ([ID], [ChannelID], [ChannelName], [ChannelCode], [Type], [ImageUrls], [Title], [ContentText], [Url], [Attributes], [State], [CreateDate], [CreatedBy], [ModifyDate], [ModifiedBy], [Remark], [Ext]) VALUES (1, 5, N'公司新闻', N'Company', 1, NULL, N'网站上线了', N'%3Cp%3E%u7F51%u7AD9%u4E0A%u7EBF%u4E86%3C/p%3E%3Cp%3E%u7F51%u7AD9%u4E0A%u7EBF%u4E86%3C/p%3E%3Cp%3E%u7F51%u7AD9%u4E0A%u7EBF%u4E86%3C/p%3E%3Cp%3E%u7F51%u7AD9%u4E0A%u7EBF%u4E86%3C/p%3E%3Cp%3E%u7F51%u7AD9%u4E0A%u7EBF%u4E86%3C/p%3E%3Cp%3E%u7F51%u7AD9%u4E0A%u7EBF%u4E86%3C/p%3E', NULL, N'd', 0, CAST(0x0000A34801758E11 AS DateTime), 1, CAST(0x0000A34801758E11 AS DateTime), 1, N'', NULL)
SET IDENTITY_INSERT [dbo].[Content] OFF
/****** Object:  Table [dbo].[Config]    Script Date: 11/24/2015 20:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Config](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Code] [varchar](64) NOT NULL,
	[Image] [varchar](2000) NULL,
	[Text] [nvarchar](4000) NULL,
	[Url] [nvarchar](2000) NULL,
	[InputType] [varchar](500) NULL,
	[State] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
 CONSTRAINT [PK_Config] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Config] ON
INSERT [dbo].[Config] ([ID], [Name], [Code], [Image], [Text], [Url], [InputType], [State], [CreateDate], [ModifyDate], [ModifyBy]) VALUES (1, N'首页轮播1', N'Banner', N'/upload/image/2015/1124/83364d7b8a6448d1bd9d826a1902e580.jpg', N'第一张轮播图片', N'', NULL, 0, NULL, CAST(0x0000A55A0152405C AS DateTime), 1)
INSERT [dbo].[Config] ([ID], [Name], [Code], [Image], [Text], [Url], [InputType], [State], [CreateDate], [ModifyDate], [ModifyBy]) VALUES (2, N'首页轮播2', N'Banner', N'F:/Web/2015-11-13/img/banner.jpg', N'123', NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[Config] ([ID], [Name], [Code], [Image], [Text], [Url], [InputType], [State], [CreateDate], [ModifyDate], [ModifyBy]) VALUES (3, N'首页轮播3', N'Banner', N'F:/Web/2015-11-13/img/banner.jpg', N'123', NULL, NULL, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Config] OFF
/****** Object:  Table [dbo].[ChannelAttribute]    Script Date: 11/24/2015 20:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChannelAttribute](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[ChannelId] [int] NOT NULL,
	[InputType] [varchar](100) NOT NULL,
	[DataType] [varchar](100) NOT NULL,
	[IsLogin] [int] NOT NULL,
	[Value] [ntext] NOT NULL,
	[State] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[Ext] [nvarchar](500) NULL,
 CONSTRAINT [PK_ChannelAttribute] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目ID，若为-100，则为全部栏目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChannelAttribute', @level2type=N'COLUMN',@level2name=N'ChannelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示类型:CheckBox,Select,Text,Int,Decimal,Image' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChannelAttribute', @level2type=N'COLUMN',@level2name=N'InputType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据值类型:Nvarchar,Int,Float' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChannelAttribute', @level2type=N'COLUMN',@level2name=N'DataType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否登录可见' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChannelAttribute', @level2type=N'COLUMN',@level2name=N'IsLogin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态，0-正常，255-删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChannelAttribute', @level2type=N'COLUMN',@level2name=N'State'
GO
/****** Object:  Table [dbo].[Channel]    Script Date: 11/24/2015 20:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Channel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ImageUrl] [nvarchar](500) NULL,
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目封面' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Channel', @level2type=N'COLUMN',@level2name=N'ImageUrl'
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
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (1, N'企业简介', NULL, 1, 2, N'About', 0, 0, 1, CAST(0x0000A348012251D3 AS DateTime), CAST(0x0000A348012251D3 AS DateTime), NULL, NULL, N'企业简介', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (2, N'关于我们', NULL, 1, 0, N'Aboutus', 1, 0, 1, CAST(0x0000A34801230A69 AS DateTime), CAST(0x0000A34801230A69 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (3, N'媒体报道', NULL, 1, 1, N'media', 1, 1, 2, CAST(0x0000A3480123FE6E AS DateTime), CAST(0x0000A3480123FE6E AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (4, N'新闻资讯', NULL, 1, 2, N'News', 0, 0, 5, CAST(0x0000A3480124AD66 AS DateTime), CAST(0x0000A3480124AD66 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (5, N'公司新闻', NULL, 1, 1, N'Company', 4, 0, 1, CAST(0x0000A34801261D73 AS DateTime), CAST(0x0000A34801261D73 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (6, N'行业动态', NULL, 1, 1, N'dongtai', 4, 0, 2, CAST(0x0000A34801266539 AS DateTime), CAST(0x0000A34801266539 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (7, N'典型案例', NULL, 2, 2, N'Case', 0, 0, 10, CAST(0x0000A3480126ADBC AS DateTime), CAST(0x0000A3480126ADBC AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (8, N'产品服务', NULL, 1, 2, N'Product', 0, 0, 20, CAST(0x0000A3480127252B AS DateTime), CAST(0x0000A3480127252B AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (9, N'ERP系统', NULL, 2, 0, N'ERP', 8, 0, 21, CAST(0x0000A34801277A33 AS DateTime), CAST(0x0000A34801277A33 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (10, N'企业网站', NULL, 2, 0, N'Web', 8, 0, 2, CAST(0x0000A3480127F666 AS DateTime), CAST(0x0000A3480127F666 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (11, N'服务说明', NULL, 1, 1, N'Service', 8, 0, 3, CAST(0x0000A3480128563E AS DateTime), CAST(0x0000A3480128563E AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (12, N'问题反馈', NULL, 1, 2, N'question', 0, 0, 30, CAST(0x0000A3480128A661 AS DateTime), CAST(0x0000A3480128A661 AS DateTime), NULL, NULL, N'', NULL)
INSERT [dbo].[Channel] ([ID], [Name], [ImageUrl], [ContentType], [Type], [Code], [ParentId], [State], [Sort], [CreateDate], [ModifyDate], [CreatedBy], [ModifiedBy], [Remark], [Ext]) VALUES (13, N'联系我们', NULL, 1, 0, N'Contact', 0, 0, 40, CAST(0x0000A3480128D415 AS DateTime), CAST(0x0000A3480128D415 AS DateTime), NULL, NULL, N'', NULL)
SET IDENTITY_INSERT [dbo].[Channel] OFF
/****** Object:  Table [dbo].[AttributeValue]    Script Date: 11/24/2015 20:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AttributeValue](
	[ID] [int] NOT NULL,
	[AttributeID] [int] NOT NULL,
	[AttributeName] [nvarchar](100) NOT NULL,
	[AttributeCode] [nvarchar](50) NULL,
	[ContentID] [int] NOT NULL,
	[ChannelID] [int] NULL,
	[Value] [nvarchar](2048) NOT NULL,
	[DataType] [varchar](100) NULL,
	[State] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[Ext] [nvarchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 11/24/2015 20:48:20 ******/
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
/****** Object:  Default [DF_GlobeConfig_CreateDate]    Script Date: 11/24/2015 20:48:20 ******/
ALTER TABLE [dbo].[GlobeConfig] ADD  CONSTRAINT [DF_GlobeConfig_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_Content_State]    Script Date: 11/24/2015 20:48:20 ******/
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_State]  DEFAULT ((0)) FOR [State]
GO
/****** Object:  Default [DF_ChannelAttribute_IsLogin]    Script Date: 11/24/2015 20:48:20 ******/
ALTER TABLE [dbo].[ChannelAttribute] ADD  CONSTRAINT [DF_ChannelAttribute_IsLogin]  DEFAULT ((0)) FOR [IsLogin]
GO
/****** Object:  Default [DF_ChannelAttribute_State]    Script Date: 11/24/2015 20:48:20 ******/
ALTER TABLE [dbo].[ChannelAttribute] ADD  CONSTRAINT [DF_ChannelAttribute_State]  DEFAULT ((0)) FOR [State]
GO
/****** Object:  Default [DF_ChannelAttribute_ModifyDate]    Script Date: 11/24/2015 20:48:20 ******/
ALTER TABLE [dbo].[ChannelAttribute] ADD  CONSTRAINT [DF_ChannelAttribute_ModifyDate]  DEFAULT (getdate()) FOR [ModifyDate]
GO
/****** Object:  Default [DF_Channel_Type]    Script Date: 11/24/2015 20:48:20 ******/
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_Type]  DEFAULT ((1)) FOR [Type]
GO
/****** Object:  Default [DF_Channel_ParentId]    Script Date: 11/24/2015 20:48:20 ******/
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO
/****** Object:  Default [DF_Channel_Sort]    Script Date: 11/24/2015 20:48:20 ******/
ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_Sort]  DEFAULT ((0)) FOR [Sort]
GO
/****** Object:  Default [DF_Admin_State]    Script Date: 11/24/2015 20:48:20 ******/
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_State]  DEFAULT ((0)) FOR [State]
GO
