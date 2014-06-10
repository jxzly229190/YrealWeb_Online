using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public static class MyExtention
{
	/// <summary>
	/// 从DataTable查询到新DataTable
	/// </summary>
	/// <param name="table"></param>
	/// <param name="expr"></param>
	/// <returns></returns>
	public static DataTable SelectToTable(this DataTable table, string expr)
	{
		DataTable reval = table.Clone();
		DataRow[] rows = table.Select(expr);
		foreach (DataRow dr in rows)
		{
			reval.ImportRow(dr);
		}
		return reval;
	}

    /// <summary>
    /// 从DataTable查询到新DataTable
    /// </summary>
    /// <param name="table"></param>
    /// <param name="expr"></param>
    /// <param name="top">查询前几条</param>
    /// <returns></returns>
    public static DataTable SelectToTable(this DataTable table, string expr, int top)
    {
        DataTable reval = table.Clone();
        DataRow[] rows = table.Select(expr);
        int count = rows.Length < top ? rows.Length : top;
        for (int i = 0; i < count; i++)
        {
            reval.ImportRow(rows[i]);
        }
        return reval;
    }
    
    /// <summary>
	/// DataTable转换为List泛型
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="table"></param>
	/// <returns></returns>
	public static List<T> ToList<T>(this DataTable table) where T : new()
	{
		Type tType = typeof(T);
		List<T> reval = new List<T>();
		PropertyInfo[] infos = tType.GetProperties();
		T t;
		foreach (DataRow dr in table.Rows)
		{
			t = new T();
			foreach (PropertyInfo pi in infos)
			{
                if (table.Columns.Contains(pi.Name))
                {
                    if (dr[pi.Name] != System.DBNull.Value)
                        pi.SetValue(t, dr[pi.Name], null);
                }
			}
			reval.Add(t);
		}
		return reval;
	}
	/// <summary>
	/// DataTable转换为Json字符
	/// </summary>
	/// <param name="table"></param>
	/// <returns></returns>
	public static string ToJsonString(this DataTable table)
	{
		StringBuilder sb = new StringBuilder();
		int i = 0;
		foreach (DataRow dr in table.Rows)
		{
			if (i == 0)
				sb.Append("{");
			else
				sb.Append(",{");
			int j = 0;
			foreach (DataColumn dc in table.Columns)
			{
				string v = dr[dc].ToString();
				if (!string.IsNullOrEmpty(v))
					v = v.Replace("'", "\\'");
				if (j == 0)
					sb.Append(string.Format("'{0}':'{1}'", dc.ColumnName, v));
				else
					sb.Append(string.Format(",'{0}':'{1}'", dc.ColumnName, v));
				j++;
			}
			sb.Append("}");
            i++;
		}
		return "[" + sb + "]";
	}
	/// <summary>
	/// DataSet转换为Json字符
	/// </summary>
	/// <param name="dataset"></param>
	/// <returns></returns>
	public static string ToJsonString(this DataSet dataset)
	{
		StringBuilder sb = new StringBuilder();
		int i = 0;
		foreach (DataTable dt in dataset.Tables)
		{
			if (i == 0)
				sb.Append(dt.ToJsonString());
			else
				sb.Append("," + dt.ToJsonString());
			i++;
		}
		return "[" + sb + "]";
	}
	/// <summary>
	/// 表实体转换为Json字符
	/// </summary>
	/// <param name="table"></param>
	/// <returns></returns>
	public static string ToJsonString(this IModel.BaseTable table)
	{
		StringBuilder sb = new StringBuilder();
		Type type = table.GetType();
		{
			PropertyInfo[] pis = type.GetProperties();
			int i = 0;
			foreach (PropertyInfo pi in pis)
			{
				object obj = pi.GetValue(table, null);
				string v = obj == null ? string.Empty : obj.ToString().Replace("'", "\\'");
				if (i == 0)
					sb.Append(string.Format("'{0}':'{1}'", pi.Name, v));
				else
					sb.Append(string.Format(",'{0}':'{1}'", pi.Name, v));
				i++;
			}
		}
		return "{" + sb + "}";
	}
	/// <summary>
	/// 重写分页
	/// </summary>
	/// <param name="pager"></param>
	public static void SetRewriteUrl(this Wuqi.Webdiyer.AspNetPager pager)
	{
		StringBuilder sb = new StringBuilder();
		//预设子域名 专区二级域名
		string strUrl=HttpContext.Current.Request.Url.AbsolutePath;
		string[] seg = HttpContext.Current.Request.Url.Segments;
		
		if (seg.Length > 1)
		{
			string seg1 = seg[1].ToLower();
			string subdomain = SubDomainRewrite[seg1];
			if (!string.IsNullOrEmpty(subdomain))
			{
				sb.Append(subdomain + ".gjw.com/");
				for (int i = 2; i < seg.Length - 1; i++)
				{
					sb.Append(seg[i]);
				}
			}
			else if (seg1 == "product/")
			{
				subdomain = HttpContext.Current.Request.QueryString["c2"];
				if (!string.IsNullOrEmpty(subdomain))
				{
					sb.Append(subdomain + ".gjw.com/");
					for (int i = 2; i < seg.Length - 1; i++)
					{
						sb.Append(seg[i]);
					}
				}
			}
			else
			{
				subdomain = HttpContext.Current.Request.Url.Host;
				for (int i = 0; i < seg.Length - 1; i++)
				{
					sb.Append(seg[i]);
				}
			}
			sb.Append(seg[seg.Length - 1].Replace(".aspx", ""));
		}
		string strQuery=string.Empty;
		for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
		{
			string key = HttpContext.Current.Request.QueryString.Keys[i];
			if (key.ToLower() != "c2" && key.ToLower() != "page")
			{
				string keyval = HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.QueryString[i]);
				//if (keyval.Contains("%"))
				//    strQuery += "&" + key + "=" + HttpContext.Current.Request.QueryString[i];
				//else
				//    sb.Append("-" + key + "-" + HttpContext.Current.Request.QueryString[i]);
				if (keyval.Contains("%"))
					strQuery += "&" + key + "=%" + key + "%";
				else
					sb.Append("-" + key + "-%" + key + "%");
			}
		}

		sb.Append("-page-{0}.aspx");
		if (!string.IsNullOrEmpty(strQuery))
			sb.Append("?" + strQuery.Substring(1));
		pager.UrlRewritePattern = sb.ToString();
	}

    #region 分页重写
    #region 老版本
    public static void SetRewriteUrl(this SamuelControl.WebPager pager)
    {
        StringBuilder sb = new StringBuilder();
        //预设子域名 专区二级域名
        string strUrl = HttpContext.Current.Request.Url.AbsolutePath;
        string[] seg = HttpContext.Current.Request.Url.Segments;
        sb.Append("http://");
        if (seg.Length > 1)
        {
            string seg1 = seg[1].ToLower();
            string subdomain = SubDomainRewrite[seg1];
            if (!string.IsNullOrEmpty(subdomain))
            {
                sb.Append(subdomain + ".gjw.com/");
                for (int i = 2; i < seg.Length - 1; i++)
                {
                    sb.Append(seg[i]);
                }
            }
            else if (seg1 == "product/")
            {
                subdomain = HttpContext.Current.Request.QueryString["c2"];
                if (!string.IsNullOrEmpty(subdomain))
                {
                    sb.Append(subdomain + ".gjw.com/");
                    for (int i = 2; i < seg.Length - 1; i++)
                    {
                        sb.Append(seg[i]);
                    }
                }
                else
                {
                    subdomain = HttpContext.Current.Request.Url.Host;
                    sb.Append(subdomain + "/product/");
                }
            }
            else if (seg1 == "brand/")
            {
                sb = new StringBuilder();
                subdomain = HttpContext.Current.Request.QueryString["c2"];
                if (!string.IsNullOrEmpty(subdomain))
                {
                    sb.Append(Common.Constant.SiteUrl + "/brand/list-c2-" + subdomain);
                }
                else
                {
                    subdomain = HttpContext.Current.Request.Url.Host;
                    sb.Append(Common.Constant.SiteUrl);
                }
            }
            else
            {
                subdomain = HttpContext.Current.Request.Url.Host;
                sb.Append(subdomain);
                for (int i = 0; i < seg.Length - 1; i++)
                {
                    sb.Append(seg[i]);
                }
            }
            if (seg1 != "brand/")
            {
                sb.Append(seg[seg.Length - 1].Replace(".aspx", ""));
            }
        }
        else
        {
            sb.Append(strUrl);
        }
        string strQuery = string.Empty;
        for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
        {
            string key = HttpContext.Current.Request.QueryString.Keys[i];
            if (key.ToLower() != "c2" && key.ToLower() != "page")
            {
                string keyval = HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.QueryString[i]);
                if (keyval.Contains("%"))
                    strQuery += "&" + key + "=" + keyval;
                else
                    sb.Append("-" + key + "-" + HttpContext.Current.Request.QueryString[i]);
            }
        }

        sb.Append("-page-{0}.aspx");
        if (!string.IsNullOrEmpty(strQuery))
            sb.Append("?" + strQuery.Substring(1));
        pager.UrlRewritePattern = sb.ToString();
    }
    #endregion

    #region 
    public static void SetRewriteUrl(this SamuelControl.WebPager pager,string pSeriesPinYin,string pAreaPinYin,string pBrandChildPinYin)
    {
        StringBuilder sb = new StringBuilder();
        //预设子域名 专区二级域名
        string strUrl = HttpContext.Current.Request.Url.AbsolutePath;
        string[] seg = HttpContext.Current.Request.Url.Segments;
        sb.Append(Common.Constant.SiteUrl + "/");

        bool addPinYin = false;
        if (!string.IsNullOrEmpty(pSeriesPinYin)) {
            addPinYin = true;
            sb.Append(pSeriesPinYin);
            if (!string.IsNullOrEmpty(pAreaPinYin)) {
                sb.Append("-" + pAreaPinYin);
                if (!string.IsNullOrEmpty(pBrandChildPinYin)) {
                    sb.Append("-" + pBrandChildPinYin);
                }
            }
        }
        if (seg.Length > 1)
        {
            string seg1 = seg[1].ToLower();
            string subdomain = SubDomainRewrite[seg1];
            if (!string.IsNullOrEmpty(subdomain))
            {
                for (int i = 2; i < seg.Length - 1; i++)
                {
                    sb.Append(seg[i]);
                }
            }
            else if (seg1 == "product/")
            {
                subdomain = HttpContext.Current.Request.QueryString["c2"];
                if (!string.IsNullOrEmpty(subdomain))
                {
                    sb.Append(addPinYin ? "-" : "");
                    for (int i = 2; i < seg.Length - 1; i++)
                    {
                        sb.Append(seg[i]);
                    }
                }
                else
                {
                    //subdomain = HttpContext.Current.Request.Url.Host;
                    //sb.Append(subdomain + "/product/");
                    sb.Append("product/");
                }
            }
            else if (seg1 == "brand/")
            {
                sb = new StringBuilder();
                subdomain = HttpContext.Current.Request.QueryString["c2"];
                if (!string.IsNullOrEmpty(subdomain))
                {
                    sb.Append(Common.Constant.SiteUrl + "/brand/list-c2-" + subdomain);
                }
                else
                {
                    subdomain = HttpContext.Current.Request.Url.Host;
                    sb.Append(Common.Constant.SiteUrl);
                }
            }
            else
            {
                subdomain = HttpContext.Current.Request.Url.Host;
                sb.Append(subdomain);
                for (int i = 0; i < seg.Length - 1; i++)
                {
                    sb.Append(seg[i]);
                }
            }
            if (seg1 != "brand/")
            {
                sb.Append(seg[seg.Length - 1].Replace(".aspx", ""));
            }
        }
        else
        {
            sb.Append(strUrl);
        }
        string strQuery = string.Empty;
        for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
        {
            string key = HttpContext.Current.Request.QueryString.Keys[i];
            if (key.ToLower() != "c2" && key.ToLower() != "page")
            {
                string keyval = HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.QueryString[i]);
                if (keyval.Contains("%"))
                    strQuery += "&" + key + "=" + keyval;
                else
                    sb.Append("-" + key + "-" + HttpContext.Current.Request.QueryString[i]);
            }
        }

        sb.Append("-page-{0}.aspx");
        if (!string.IsNullOrEmpty(strQuery))
            sb.Append("?" + strQuery.Substring(1));
        pager.UrlRewritePattern = sb.ToString();
    }
    #endregion

    #endregion

    /// <summary>
	/// 根据值选中Select控件项
	/// </summary>
	/// <param name="hsel"></param>
	/// <param name="val"></param>
	public static void SelectedByValue(this HtmlSelect hsel, string val)
	{
		foreach (ListItem li in hsel.Items)
		{
			if (li.Value == val)
			{
				li.Selected = true;
				break;
			}
		}
	}




	private static NameValueCollection _SubDomainRewrite = null;
	/// <summary>
	/// 二级域名对照表
	/// </summary>
	public static NameValueCollection SubDomainRewrite
	{
		get
		{
			if (_SubDomainRewrite == null)
			{
				_SubDomainRewrite = new NameValueCollection();
				_SubDomainRewrite.Add("quan/", "quan");
				_SubDomainRewrite.Add("mycenter/", "i");
				_SubDomainRewrite.Add("tuan/", "tuan");
				_SubDomainRewrite.Add("qiang/", "qiang");
				_SubDomainRewrite.Add("shoucang/", "shoucang");
			}
			return _SubDomainRewrite;
		}
	}
}

/// <summary>
/// json转化
/// </summary>
public static class JSON
{
	/// <summary>
	/// strong to json
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="jsonString"></param>
	/// <returns></returns>
	public static T parse<T>(string jsonString)
	{
		using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
		{
			return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
		}
	}
	/// <summary>
	/// json to string
	/// </summary>
	/// <param name="jsonObject"></param>
	/// <returns></returns>
	public static string stringify(object jsonObject)
	{
		using (var ms = new MemoryStream())
		{
			new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
			return Encoding.UTF8.GetString(ms.ToArray());
		}
	}
}
