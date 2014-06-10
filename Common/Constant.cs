using System;
using System.Web;

namespace Common
{
    /// <summary>
    /// WebConfig 取值
    /// </summary>
    public static class WebConfig
    {
        /// <summary>
        /// 读取AppSettings节点的值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetSetting(string name)
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings[name];
        }
        /// <summary>
        /// 读取AppSettings节点的值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetSetting(int index)
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings[index];
        }
        /// <summary>
        /// 读取connectionStrings节点的值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnection(string name)
        {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        /// <summary>
        /// 读取connectionStrings节点的值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetConnection(int index)
        {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings[index].ConnectionString;
        }
    }

    /// <summary>
    /// 公共静态属性/字段
    /// </summary>
	public static class Constant
	{
		private static string _factoryName = null;
        /// <summary>
        /// 抽象工厂名
        /// </summary>
		public static string factoryName
		{
			get
			{
				if (_factoryName == null)
					_factoryName = WebConfig.GetSetting("factoryName");
				return _factoryName;
			}
		}
		private static string _Database = null;
        /// <summary>
        /// 采用数据库
        /// </summary>
		public static string Database
		{
			get
			{
				if (_Database == null)
					_Database = WebConfig.GetSetting("DataBase");
				return _Database;
			}
		}

        private static string _Web = null;

        public static string Web
        {
            get
            {
                return _Web ?? (_Web = "http://" + WebConfig.GetSetting("Web"));
            }
        }

        private static string _SiteUrl = null;
        /// <summary>
        /// Web服务器地址
        /// </summary>
		public static string SiteUrl
		{
			get
			{
				if (_SiteUrl == null)
					_SiteUrl = "http://" + WebConfig.GetSetting("WebServer");
				return _SiteUrl;
			}
			
		}
		private static string _QuanUrl = null;
		/// <summary>
		/// 酒友圈地址
		/// </summary>
		public static string QuanUrl
		{
			get
			{
				if (_QuanUrl == null)
					_QuanUrl = "http://" + WebConfig.GetSetting("Quan");
				return _QuanUrl;
			}
		}
		private static string _TuanUrl = null;
		/// <summary>
		/// 购酒团地址
		/// </summary>
		public static string TuanUrl
		{
			get
			{
				if (_TuanUrl == null)
					_TuanUrl = "http://" + WebConfig.GetSetting("Tuan");
				return _TuanUrl;
			}
		}
		private static string _QiangUrl = null;
		/// <summary>
		/// 抢购地址
		/// </summary>
		public static string QiangUrl
		{
			get
			{
				if (_QiangUrl == null)
					_QiangUrl = "http://" + WebConfig.GetSetting("Qiang");
				return _QiangUrl;
			}
		}
		private static string _ShouCangUrl = null;
		/// <summary>
		/// 收藏酒地址
		/// </summary>
		public static string ShouCangUrl
		{
			get
			{
				if (_ShouCangUrl == null)
					_ShouCangUrl = "http://" + WebConfig.GetSetting("ShouCang");
				return _ShouCangUrl;
			}
		}
		private static string _ImageSiteUrl = null;
        /// <summary>
        /// 图片服务器域名
        /// </summary>
		public static string ImageSiteUrl
		{
			get
			{
				if (_ImageSiteUrl == null)
					_ImageSiteUrl = "http://" + WebConfig.GetSetting("ImageServer");
				return _ImageSiteUrl;
			}
		}
		private static string _ConnectionString = null;
        /// <summary>
        /// 数据库连接
        /// </summary>
		public static string ConnectionString
		{
			get
			{
				if (_ConnectionString == null)
					_ConnectionString = WebConfig.GetConnection("Connection");
				return _ConnectionString;
			}
		}
		private static string _LogConnectionString = null;
		/// <summary>
		/// LOG数据库连接
		/// </summary>
		public static string LogConnectionString
		{
			get
			{
				if (_LogConnectionString == null)
					_LogConnectionString = WebConfig.GetConnection("LogConnection");
				return _LogConnectionString;
			}
		}
		private static bool? _IsMemcached = null;
        /// <summary>
        /// 是否启用Memcached缓存
        /// </summary>
		public static bool IsMemcached
		{
			get
			{
				if (!_IsMemcached.HasValue)
					_IsMemcached=Convert.ToBoolean(WebConfig.GetSetting("IsMemcached"));
				return _IsMemcached.Value;
			}
		}
		private static string[] _MemcachedServer = null;
		/// <summary>
		/// Memcached服务器列表
		/// </summary>
		public static string[] MemcachedServer
		{
			get
			{
				if (_MemcachedServer == null)
					_MemcachedServer = WebConfig.GetSetting("MemcachedServer").Split(',');
				return _MemcachedServer;
			}
		}
		private static bool? _IsCopyLog = null;
		/// <summary>
		/// 是否启用数据复制
		/// </summary>
		public static bool IsCopyLog
		{
			get
			{
				if (!_IsCopyLog.HasValue)
					_IsCopyLog = Convert.ToBoolean(WebConfig.GetSetting("IsCopyLog"));//指定开关
				if (PubFunc.GetAdminID() > 0)
				{
					if (!string.IsNullOrEmpty(CopyLogDb))
					{
						return _IsCopyLog.Value;
					}
				}
				return false;
			}
		}
		private static string _CopyLogDb = null;
		/// <summary>
		/// 日志库
		/// </summary>
		public static string CopyLogDb
		{
			get
			{
				if (_CopyLogDb == null)
					_CopyLogDb = WebConfig.GetSetting("CopyLogDb");
				return _CopyLogDb;
			}
		}
		/// <summary>
		/// 商品品牌URL
		/// </summary>
		/// <param name="PinYin"></param>
		/// <returns></returns>
		public static string BrandUrl(string PinYin)
		{
            if (string.IsNullOrEmpty(PinYin))
                return SiteUrl + "/product";
            else
                return "http://" + PinYin.Replace(" ", "vv") + ".gjw.com";
                //return Common.Constant.SiteUrl + "/" + PinYin.Replace(" ", "vv");
		}
        /// <summary>
        /// 商品品牌URL(减少二级域名)
        /// </summary>
        /// <param name="PinYin"></param>
        /// <returns></returns>
        public static string zBrandUrl(string PinYin)
        {
            if (string.IsNullOrEmpty(PinYin))
                return SiteUrl + "/product";
            else
                return Common.Constant.SiteUrl + "/" + PinYin.Replace(" ", "vv");
        }
        /// <summary>
        /// 商品品牌URL(减少二级域名)
        /// </summary>
        /// <param name="PinYin"></param>
        /// <returns></returns>
        public static string zBrandUrl(string[] PinYin)
        {
            if (PinYin.Length == 0)
                return SiteUrl + "/product";
            else
            {
                string strUrl = Common.Constant.SiteUrl;
                for (int i = 0; i < PinYin.Length; i++)
                {
                    if (i == 0)
                    {
                        strUrl += "/" + PinYin[i].Replace(" ", "vv");
                    }
                    else {
                        strUrl += "-" + PinYin[i].Replace(" ", "vv");
                    }
                }
                return strUrl;
            }
        }
        /// <summary>
        /// 商品品牌URL
        /// </summary>
        /// <param name="PinYin"></param>
        /// <returns></returns>
        public static string BrandSearchUrl(string PinYin)
        {
            if (string.IsNullOrEmpty(PinYin))
                return SiteUrl + "/brand";
            else
                return Common.Constant.SiteUrl + "/brand/" + PinYin + ".htm";
        }

        /// <summary>
        /// 物理路径
        /// </summary>
        //public static string FeedPath = @"E:\v4.goujiuwang.com\www\feed";
        public static string FeedPath = @"E:\WebSites\goujiuwang_v4\www\feed";
	}
}
