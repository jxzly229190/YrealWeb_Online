using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using System.Text.RegularExpressions;

namespace Common
{
	/// <summary>
	/// Script执行模式
	/// </summary>
	public enum ScriptMode
	{
		/// <summary>
		/// 页面载入前
		/// </summary>
 		BeforeLoad,
		/// <summary>
		/// 页面载入后
		/// </summary>
		AfterLoad,
		/// <summary>
		/// 在UpdatePanel中
		/// </summary>
		WithUpdatePanel
	}

	/// <summary>
	/// 公共静态方法
	/// </summary>
	public static class PubFunc
	{
		#region 管理员与用户ID
		/// <summary>
		/// 获取登录管理员ID
		/// </summary>
		/// <returns></returns>
		public static int GetAdminID()
		{
			if (HttpContext.Current.Session["AdminID"] != null)
			{
				return Convert.ToInt32(HttpContext.Current.Session["AdminID"]);
			}
            //todo:为了测试，直接给一个定值
			return 1;
		}
		/// <summary>
		/// 获取操作标识
		/// </summary>
		/// <returns></returns>
		public static string GetAdminGuid()
		{
			if (HttpContext.Current.Session["Admin_Guid"] != null)
			{
				return HttpContext.Current.Session["Admin_Guid"].ToString();
			}
			else
			{
				string guid = Guid.NewGuid().ToString().Replace("-", "");
				HttpContext.Current.Session["Admin_Guid"] = guid;
				return guid;
			}
		}
		/// <summary>
		/// 获取登录用户ID
		/// </summary>
		/// <returns></returns>
		public static int GetUserID()
		{
            if (HttpContext.Current.Session["Kefu_Get_UserID"] != null)
            {
                return Convert.ToInt32(HttpContext.Current.Session["Kefu_Get_UserID"]);
            }
            else
            {
                if (HttpContext.Current.Session["UserID"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                }
            }
			return 0;
		}

		/// <summary>
		/// 会员等级ID
		/// </summary>
		/// <returns></returns>
		public static int GetUserLevelID()
		{
            if (HttpContext.Current.Session["Kefu_Get_UserLevelID"] != null)
            {
                return Convert.ToInt32(HttpContext.Current.Session["Kefu_Get_UserLevelID"]);
            }
            else
            {
                if (HttpContext.Current.Session["UserLevelID"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["UserLevelID"]);
                }
            }
			return 0;
		}

		#endregion

        #region 根据ID读取指定表单个字段
        /// <summary>
		/// 根据ID读取指定表单个字段
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="Field"></param>
		/// <param name="Table"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public static object GetValueByID(DataContext ctx, string Field, string Table, int ID)
		{
			if (ctx == null)
				ctx = new DataContext();
			string sql = string.Format("SELECT {0} FROM {1} WITH(NOLOCK) WHERE ID=@ID_getValueByID", Field, Table, ID);
			ctx.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_getValueByID", ID));
			ctx.CommandType = CommandType.Text;
			object reval = ctx.ExecuteScalar(sql);
			ctx.ClearParameters();
			return reval;
		}
		/// <summary>
		/// 根据ID读取指定表单个字段
		/// </summary>
		/// <param name="Field"></param>
		/// <param name="Table"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public static object GetValueByID(string Field, string Table, int ID)
		{
			return GetValueByID(null, Field, Table, ID);
		}
		#endregion

		#region 获取专区域名
		/// <summary>
		/// 获取专区域名
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public static string GetAreaUrl(DataContext ctx, int ID)
		{
			object obj = GetValueByID(ctx, "PinYin", "pro_Area", ID);
			string s = obj == null ? string.Empty : obj.ToString();
			string feed = string.Format(Constant.SiteUrl.Replace("www", "{0}"));
			return string.Format(feed, s);
		}
		/// <summary>
		/// 获取专区域名
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public static string GetAreaUrl(int ID)
		{
			return GetAreaUrl(null, ID);
		}
		#endregion

		#region 文件导出/下载
		/// <summary>
		/// 字符串输出到文件
		/// </summary>
		/// <param name="FileName">下载文件名</param>
		/// <param name="FileText">输出的字符串</param>
		public static void StringToFile(string FileString, string FileName)
		{
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.Buffer = true;
			HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            HttpContext.Current.Response.Charset = "gb2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
            HttpContext.Current.Response.ContentType = "Application/octet-stream";
			HttpContext.Current.Response.Write(FileString);
			HttpContext.Current.Response.End();
		}
		/// <summary>
		/// DataTable导出到逗号分隔的Excel文件
		/// </summary>
		/// <param name="Table">DataTable</param>
		/// <param name="FileName">文件名</param>
		public static void TableToCsv(DataTable Table, string FileName)
		{
			if (Table.Rows.Count > 0)
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				foreach (DataRow r in Table.Rows)
				{
					string strRow = null;
					for (int i = 0; i < Table.Columns.Count; i++)
					{
						string str = r[i].ToString();
						if (str.IndexOf('"') > -1)
						{
							str = str.Replace("\"", "\"\"");
						}
						if (str.IndexOf(',') > -1)
						{
							str = "\"" + str + "\"";
						}
						strRow += "," + str;
					}
					strRow = strRow.Substring(1);
					sb.AppendLine(strRow);
				}
				StringToFile(sb.ToString(), FileName);
			}
		}

		#endregion

		#region 执行javascript
		/// <summary>
		/// 运行客户端JavaScript脚本
		/// </summary>
		/// <param name="ctrl">放置脚本的控件</param>
		/// <param name="code">JavaScript代码</param>
		/// <param name="mode">执行模式</param>
		public static void RunScript(System.Web.UI.Control ctrl, string code,ScriptMode mode)
		{
			if (mode == ScriptMode.BeforeLoad)
			{
				ctrl.Page.ClientScript.RegisterClientScriptBlock(ctrl.GetType(), "jsBlock", code, true);
			}
			else if (mode == ScriptMode.AfterLoad)
			{
				System.Web.UI.HtmlControls.HtmlGenericControl hgc = new System.Web.UI.HtmlControls.HtmlGenericControl();
				hgc.TagName = "div";
				hgc.InnerHtml = "<script type=\"text/javascript\">";
				hgc.InnerHtml += code;
				hgc.InnerHtml += "</script>";
				ctrl.Controls.Add(hgc);
			}
			else
			{
				System.Web.UI.ScriptManager.RegisterClientScriptBlock(ctrl, ctrl.GetType(), "jsBlock", code, true);
			}
		}
		#endregion

		#region 获取并更新页面参数
		/// <summary>
		/// 获取并更新页面参数
		/// </summary>
		/// <param name="Key">键名</param>
		/// <param name="Val">键值</param>
		/// <returns></returns>
		public static string SetQuery(string Key, string Val)
		{
			return SetQuery(Key, Val, true);
		}
		/// <summary>
		/// 获取并更新页面参数
		/// </summary>
		/// <param name="Key">键名</param>
		/// <param name="Val">键值</param>
		/// <param name="EnableRewriting">是否启用重写</param>
		/// <returns></returns>
		public static string SetQuery(string Key, string Val, bool EnableRewriting)
		{
			string reval = null;
			NameValueCollection query = new NameValueCollection(HttpContext.Current.Request.QueryString);
			query.Set(Key, Val);
			for (int i = 0; i < query.Count; i++)
			{
				if (query.Keys[i] != "c2")
				{
					if (EnableRewriting)
						reval += "-" + query.Keys[i] + "-" + HttpContext.Current.Server.UrlEncode(query[i]);
					else
						reval += "&" + query.Keys[i] + "=" + HttpContext.Current.Server.UrlEncode(query[i]);
				}
			}
			if (reval != null)
				reval = reval.Substring(1);
			return reval;
		}
		/// <summary>
		/// 获取并移除页面参数
		/// </summary>
		/// <param name="Key"></param>
		/// <returns></returns>
		public static string RemoveQuery(string Key)
		{
			return RemoveQuery(Key, true);
		}
		/// <summary>
		/// 获取并移除页面参数
		/// </summary>
		/// <param name="Key">键名</param>
		/// <param name="EnableRewriting">启用重写</param>
		/// <returns></returns>
		public static string RemoveQuery(string Key, bool EnableRewriting)
		{
			string reval = null;
			NameValueCollection query = new NameValueCollection(HttpContext.Current.Request.QueryString);
			query.Remove(Key);
			for (int i = 0; i < query.Count; i++)
			{
				if (query.Keys[i] != "c2")
				{
					if (EnableRewriting)
						reval += "-" + query.Keys[i] + "-" + HttpContext.Current.Server.UrlEncode(query[i]);
					else
						reval += "&" + query.Keys[i] + "=" + HttpContext.Current.Server.UrlEncode(query[i]);
				}
			}
			if (reval != null)
				reval = reval.Substring(1);
			return reval;

		}
		/// <summary>
		/// 获取并更新页面参数
		/// </summary>
		/// <param name="KeyVal">键值集合</param>
		/// <returns></returns>
		public static string SetQuery(NameValueCollection KeyVal)
		{
			return SetQuery(KeyVal, true);
		}
		/// <summary>
		/// 获取并更新页面参数
		/// </summary>
		/// <param name="KeyVal">键值集合</param>
		/// <param name="EnableRewriting">启用重写</param>
		/// <returns></returns>
		public static string SetQuery(NameValueCollection KeyVal, bool EnableRewriting)
		{
			string reval = null;
			NameValueCollection query = new NameValueCollection(HttpContext.Current.Request.QueryString);
			for (int i = 0; i < KeyVal.Count; i++)
				query.Set(KeyVal.Keys[i], KeyVal[i]);
			for (int i = 0; i < query.Count; i++)
			{
				if (query.Keys[i] != "c2")
				{
					if(EnableRewriting)
						reval += "-" + query.Keys[i] + "-" + HttpContext.Current.Server.UrlEncode(query[i]);
					else
						reval += "&" + query.Keys[i] + "=" + HttpContext.Current.Server.UrlEncode(query[i]);
				}
			}
			if (reval != null)
				reval = reval.Substring(1);
			return reval;
		}
		/// <summary>
		/// 获取并移除页面参数
		/// </summary>
		/// <param name="Key">键集合</param>
		/// <returns></returns>
		public static string RemoveQuery(string[] Key)
		{
			return RemoveQuery(Key, true);
		}
		/// <summary>
		/// 获取并移除页面参数
		/// </summary>
		/// <param name="Key">键集合</param>
		/// <param name="EnableRewriting">启用重写</param>
		/// <returns></returns>
		public static string RemoveQuery(string[] Key, bool EnableRewriting)
		{
			string reval = null;
			NameValueCollection query = new NameValueCollection(HttpContext.Current.Request.QueryString);
			for (int i = 0; i < Key.Length; i++)
				query.Remove(Key[i]);
			for (int i = 0; i < query.Count; i++)
			{
				if (EnableRewriting)
					reval += "-" + query.Keys[i] + "-" + HttpContext.Current.Server.UrlEncode(query[i]);
				else
					reval += "&" + query.Keys[i] + "=" + HttpContext.Current.Server.UrlEncode(query[i]);
			}
			if (reval != null)
				reval = reval.Substring(1);
			return reval;
		}
		/// <summary>
		/// 设置和移除页面参数
		/// </summary>
		/// <param name="SetKeyVal">设置键值集合</param>
		/// <param name="RemoveKey">移除键集合</param>
		/// <returns></returns>
		public static string SetRemoveQuery(NameValueCollection SetKeyVal, string[] RemoveKey)
		{
			return SetRemoveQuery(SetKeyVal, RemoveKey, true);
		}
		/// <summary>
		/// 设置和移除页面参数
		/// </summary>
		/// <param name="SetKeyVal">设置键值集合</param>
		/// <param name="RemoveKey">移除键集合</param>
		/// <param name="EnableRewriting">启用重写</param>
		/// <returns></returns>
		public static string SetRemoveQuery(NameValueCollection SetKeyVal, string[] RemoveKey, bool EnableRewriting)
		{
			string reval = null;
			NameValueCollection query = new NameValueCollection(HttpContext.Current.Request.QueryString);
			for (int i = 0; i < SetKeyVal.Count; i++)
				query.Set(SetKeyVal.Keys[i], SetKeyVal[i]);
			for (int i = 0; i < RemoveKey.Length; i++)
				query.Remove(RemoveKey[i]);

			for (int i = 0; i < query.Count; i++)
			{
				if (query.Keys[i] != "c2")
				{
					if (EnableRewriting)
						reval += "-" + query.Keys[i] + "-" + HttpContext.Current.Server.UrlEncode(query[i]);
					else
						reval += "&" + query.Keys[i] + "=" + HttpContext.Current.Server.UrlEncode(query[i]);
				}
			}
			if (reval != null)
				reval = reval.Substring(1);
			return reval;
		}
		/// <summary>
		/// 获取并更新页面参数，并排除其中一个或多个以豆号发隔的指定项
		/// </summary>
		/// <param name="Key">键名</param>
		/// <param name="Val">键值</param>
		/// <param name="RemoveKeys">排除项，以逗号分隔</param>
		/// <returns></returns>
		public static string SetQuery(string Key, string Val, string RemoveKeys)
		{
			return SetQuery(Key, Val, RemoveKeys, true);
		}
		/// <summary>
		/// 获取并更新页面参数，并排除其中一个或多个以豆号发隔的指定项
		/// </summary>
		/// <param name="Key">键名</param>
		/// <param name="Val">键值</param>
		/// <param name="RemoveKeys">排除项，以逗号分隔</param>
		/// <param name="EnableRewriting">启用重写</param>
		/// <returns></returns>
		public static string SetQuery(string Key, string Val, string RemoveKeys, bool EnableRewriting)
		{
			string reval = null;
			NameValueCollection query = new NameValueCollection(HttpContext.Current.Request.QueryString);
			query.Set(Key, Val);
			string[] arrKey = RemoveKeys.Split(',');
			for (int i = 0; i < arrKey.Length; i++)
				query.Remove(arrKey[i]);
			for (int i = 0; i < query.Count; i++)
			{
				if (query.Keys[i] != "c2")
				{
					if (EnableRewriting)
						reval += "-" + query.Keys[i] + "-" + HttpContext.Current.Server.UrlEncode(query[i]);
					else
						reval += "&" + query.Keys[i] + "=" + HttpContext.Current.Server.UrlEncode(query[i]);
				}
			}
			if (reval != null)
				reval = reval.Substring(1);
			return reval;
		}

		#endregion

		#region 数据绑定
		/// <summary>
		/// 无分页数据绑定(列表控件和数据控件)
		/// </summary>
		/// <param name="ctrl">绑定控件</param>
		/// <param name="source">数据源</param>
		public static void BindControl(DataBoundControl ctrl, object source)
		{
			ctrl.DataSource = source;
			ctrl.DataBind();
		}
		/// <summary>
		/// 无分页数据绑定(列表控件)
		/// </summary>
		/// <param name="ctrl"></param>
		/// <param name="source"></param>
		public static void BindControl(HtmlSelect ctrl, object source)
		{
			ctrl.DataSource = source;
			ctrl.DataBind();
		}
		/// <summary>
		/// 无分页数据绑定(列表控件和数据控件)
		/// </summary>
		/// <param name="ctrl">绑定控件</param>
		/// <param name="source">数据源</param>
		public static void BindControl(Repeater ctrl, object source)
		{
			ctrl.DataSource = source;
			ctrl.DataBind();
		}



		/// <summary>
		/// 分页数据绑定(列表控件和数据控件)
		/// </summary>
		/// <param name="ctrl">绑定控件</param>
		/// <param name="source">数据源</param>
		/// <param name="pager">分页控件</param>
		public static void BindControl(DataBoundControl ctrl, DataSet source, AspNetPager pager)
		{
			if (source.Tables.Count < 1)
				return;
			ctrl.DataSource = source.Tables[0];
			ctrl.DataBind();
			pager.RecordCount = Convert.ToInt32(source.Tables[1].Rows[0][0]);
			pager.SetRewriteUrl();
		}
		/// <summary>
		/// 分页数据绑定(列表控件和数据控件)
		/// </summary>
		/// <param name="ctrl">绑定控件</param>
		/// <param name="source">数据源</param>
		/// <param name="pager">分页控件</param>
		public static void BindControl(Repeater ctrl, DataSet source, AspNetPager pager)
		{
			if (source.Tables.Count < 1)
				return;
			ctrl.DataSource = source.Tables[0];
			ctrl.DataBind();
			pager.RecordCount = Convert.ToInt32(source.Tables[1].Rows[0][0]);
			pager.SetRewriteUrl();
		}
		/// <summary>
		/// 分页数据绑定(列表控件和数据控件)
		/// </summary>
		/// <param name="ctrl"></param>
		/// <param name="source"></param>
		/// <param name="RecordCount"></param>
		/// <param name="pager"></param>
		public static void BindControl(DataBoundControl ctrl, object source, int RecordCount, AspNetPager pager)
		{
			ctrl.DataSource = source;
			ctrl.DataBind();
			pager.RecordCount = RecordCount;
			pager.SetRewriteUrl();
		}
		/// <summary>
		/// 分页数据绑定(列表控件和数据控件)
		/// </summary>
		/// <param name="ctrl"></param>
		/// <param name="source"></param>
		/// <param name="RecordCount"></param>
		/// <param name="pager"></param>
		public static void BindControl(Repeater ctrl, object source, int RecordCount, AspNetPager pager)
		{
			ctrl.DataSource = source;
			ctrl.DataBind();
			pager.RecordCount = RecordCount;
			pager.SetRewriteUrl();
		}
		#endregion

        #region 获取配置信息
		/// <summary>
		/// 获取配置信息
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public static string GetConfig(DataContext ctx, int ID)
		{
			string sql = "SELECT Value FROM sys_Config WHERE ID=" + ID;
			return ctx.ExecuteScalar(sql).ToString();
		}
		/// <summary>
		/// 获取配置信息
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public static string GetConfig(int ID)
		{
			DataContext ctx = new DataContext();
			return GetConfig(ctx, ID);
		}
		#endregion

        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strFeed">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Md5(string strFeed)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(strFeed));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
                sBuilder.AppendFormat("{0:x2}", encryptedBytes[i]);
            return sBuilder.ToString();
        }
        #endregion

        #region 移除所有标签
        public static string RemoveHtml(string content)
        {
            string revel = content;
            string regexstr = @"<[^>]*>";
            revel = Regex.Replace(revel, regexstr, string.Empty, RegexOptions.IgnoreCase);
            return revel;
        }
        #endregion

		#region 产生随机码
		/// <summary>
		/// 产生随机码
		/// </summary>
		/// <param name="codeCount"></param>
		/// <returns></returns>
		public static string CreateRandomCode(int codeCount)
		{
			string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
			string[] allCharArray = allChar.Split(',');
			string randomCode = "";
			byte[] bytes = new byte[4];
			System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
			rng.GetBytes(bytes);
			Random rand = new Random(BitConverter.ToInt32(bytes, 0));
			for (int i = 0; i < codeCount; i++)
			{
				int t = rand.Next(36);
				randomCode += allCharArray[t];
			}
			//System.Threading.Thread.Sleep(50);
			return randomCode;
		}
		#endregion
        
        /// <summary>
        /// 根据地址栏返回当前页码(索引从0开始)
        /// </summary>
        /// <returns></returns>
        public static int getPageIndex()
        {
            int reval = 1;
            string strCurPage = HttpContext.Current.Request.Form["__EVENTARGUMENT"];
            if (string.IsNullOrEmpty(strCurPage))
                strCurPage = "1";
            reval = int.Parse(strCurPage);
            return reval;
        }

        /// <summary>
        /// 根据pager返回当前页码(索引从0开始)
        /// 分页控件采用post方式的时候一定要加onpagechanged事件
        /// </summary>
        /// <param name="pager">分页控件</param>
        /// <returns></returns>
        public static int getPageIndex(AspNetPager pager)
        {
            int reval = 1;
            if (pager.UrlPaging)
                reval = getPageIndex();
            else
                reval = pager.CurrentPageIndex - 1;
            return reval;
        }

		/// <summary>
		/// 检查是否站内请求
		/// </summary>
		public static void CheckReferrer()
		{
			if (HttpContext.Current.Request.UrlReferrer == null)
			{
				HttpContext.Current.Response.Write("请求失败");
				HttpContext.Current.Response.End();
				return;
			}
			string rfr = HttpContext.Current.Request.UrlReferrer.Host.ToLower();
			if (!rfr.Contains(".gjw.com"))
			{
				HttpContext.Current.Response.Write("请求失败");
				HttpContext.Current.Response.End();
				return;
			}
		}

        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string strIP = HttpContext.Current.Request.UserHostAddress;
            return strIP;
        }
    }
}

