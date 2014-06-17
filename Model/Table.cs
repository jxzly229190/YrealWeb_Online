using System;
namespace Model
{
	public class Admin : IModel.BaseTable
	{
		[Column("int")]
		public int? ID
		{
			set;
			get;
		}
		[Column("varchar")]
		public string LoginName
		{
			set;
			get;
		}
		[Column("varchar")]
		public string Password
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Name
		{
			set;
			get;
		}
		[Column("varchar")]
		public string Mob
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Email
		{
			set;
			get;
		}
		[Column("varchar")]
		public string QQ
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Remark
		{
			set;
			get;
		}
		[Column("int")]
		public int? State
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Ext
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? CreateDate
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? ModifyDate
		{
			set;
			get;
		}
	}
	public class AttributeValue : IModel.BaseTable
	{
		[Column("int")]
		public int? ID
		{
			set;
			get;
		}
		[Column("int")]
		public int? AttributeID
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string AttributeName
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string AttributeCode
		{
			set;
			get;
		}
		[Column("int")]
		public int? ContentID
		{
			set;
			get;
		}
		[Column("int")]
		public int? ChannelID
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Value
		{
			set;
			get;
		}
		[Column("varchar")]
		public string DataType
		{
			set;
			get;
		}
		[Column("int")]
		public int? State
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? CreateDate
		{
			set;
			get;
		}
		[Column("int")]
		public int? CreateBy
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? ModifyDate
		{
			set;
			get;
		}
		[Column("int")]
		public int? ModifyBy
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Ext
		{
			set;
			get;
		}
	}
	public class Channel : IModel.BaseTable
	{
		[Column("int")]
		public int? ID
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Name
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string ImageUrl
		{
			set;
			get;
		}
		[Column("int")]
		public int? ContentType
		{
			set;
			get;
		}
		[Column("int")]
		public int? Type
		{
			set;
			get;
		}
		[Column("varchar")]
		public string Code
		{
			set;
			get;
		}
		[Column("int")]
		public int? ParentId
		{
			set;
			get;
		}
		[Column("int")]
		public int? State
		{
			set;
			get;
		}
		[Column("int")]
		public int? Sort
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? CreateDate
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? ModifyDate
		{
			set;
			get;
		}
		[Column("int")]
		public int? CreatedBy
		{
			set;
			get;
		}
		[Column("int")]
		public int? ModifiedBy
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Remark
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Ext
		{
			set;
			get;
		}
	}
	public class ChannelAttribute : IModel.BaseTable
	{
		[Column("int")]
		public int? ID
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Name
		{
			set;
			get;
		}
		[Column("varchar")]
		public string Code
		{
			set;
			get;
		}
		[Column("int")]
		public int? ChannelId
		{
			set;
			get;
		}
		[Column("varchar")]
		public string InputType
		{
			set;
			get;
		}
		[Column("varchar")]
		public string DataType
		{
			set;
			get;
		}
		[Column("int")]
		public int? IsLogin
		{
			set;
			get;
		}
		[Column("ntext")]
		public string Value
		{
			set;
			get;
		}
		[Column("int")]
		public int? State
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? CreateDate
		{
			set;
			get;
		}
		[Column("int")]
		public int? CreateBy
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? ModifyDate
		{
			set;
			get;
		}
		[Column("int")]
		public int? ModifyBy
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Ext
		{
			set;
			get;
		}
	}
	public class Config : IModel.BaseTable
	{
		[Column("int")]
		public int? ID
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Name
		{
			set;
			get;
		}
		[Column("varchar")]
		public string Code
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Image
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Text
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Url
		{
			set;
			get;
		}
		[Column("varchar")]
		public string InputType
		{
			set;
			get;
		}
		[Column("int")]
		public int? State
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? CreateDate
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? ModifyDate
		{
			set;
			get;
		}
		[Column("int")]
		public int? ModifyBy
		{
			set;
			get;
		}
	}
	public class Content : IModel.BaseTable
	{
		[Column("int")]
		public int? ID
		{
			set;
			get;
		}
		[Column("int")]
		public int? ChannelID
		{
			set;
			get;
		}
		[Column("varchar")]
		public string ChannelName
		{
			set;
			get;
		}
		[Column("varchar")]
		public string ChannelCode
		{
			set;
			get;
		}
		[Column("int")]
		public int? Type
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string ImageUrls
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Title
		{
			set;
			get;
		}
		[Column("text")]
		public string ContentText
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Url
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Attributes
		{
			set;
			get;
		}
		[Column("int")]
		public int? State
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? CreateDate
		{
			set;
			get;
		}
		[Column("int")]
		public int? CreatedBy
		{
			set;
			get;
		}
		[Column("datetime")]
		public DateTime? ModifyDate
		{
			set;
			get;
		}
		[Column("int")]
		public int? ModifiedBy
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Remark
		{
			set;
			get;
		}
		[Column("nvarchar")]
		public string Ext
		{
			set;
			get;
		}
	}
}
