using System;
using System.Web;
using Memcached.ClientLibrary;
using System.Collections.Generic;

namespace Common
{
	
    /// <summary>
    /// 本地缓存，单建模式，永远确保只有一个LocalCache对象
    /// </summary>
    public sealed class Memcached
    {
		private static Memcached _instance = new Memcached();
        /// <summary>
        /// 创建单件实例
        /// </summary>
        /// <returns></returns>
        public static Memcached GetInstance()
        {
			return _instance == null ? new Memcached() : _instance;
        }

        /// <summary>
        /// 私有构造
        /// </summary>
		private Memcached()
        {
			_Keys = new List<string[]>();
        }

		public List<string[]> _Keys;
		public List<string[]> Keys
		{
			set
			{ _Keys = value; }
			get
			{
				List<string[]> items = new List<string[]>();
				foreach (string[] keys in _Keys)
				{
 					if(HttpContext.Current.Cache[keys[0]]==null)
					{
						items.Add(keys);
					}
				}
				foreach (string[] s in items)
				{
					_Keys.Remove(s);
				}
				return _Keys; 
			}
		}
		

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
			if (Constant.IsMemcached)
			{
				if (HttpContext.Current.Cache[key] != null)
				{
					return HttpContext.Current.Cache[key];
				}
			}
            return null;
        }

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
		public bool Set(string key, object obj, DateTime expires)
		{
			if (Constant.IsMemcached)
			{
				try
				{
					foreach (string[] keys in _Keys)
					{
						if (keys[0] == key)
						{
							keys[1] = DateTime.Now.ToString();
							keys[2] = expires.ToString();
							goto lbl;
						}
					}
					_Keys.Add(new string[] { key, DateTime.Now.ToString(), expires.ToString() });
				lbl:
					HttpContext.Current.Cache.Add(key, obj, null, expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
					return true;
				}
				catch
				{
					return false;
				}
			}
			return false;
		}

        /// <summary>
        /// 判断指定键缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
			if (Constant.IsMemcached)
			{
				return HttpContext.Current.Cache[key] != null;
			}
			return false;
        }

        /// <summary>
        /// 替换缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public bool Replace(string key, object obj, DateTime expires)
        {
			if (Constant.IsMemcached)
			{
				return Set(key, obj, expires);
			}
			return false;
        }

        /// <summary>
        /// 删除缓存项
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(string key)
        {
			if (Constant.IsMemcached)
			{
				try
				{
					foreach (string[] keys in _Keys)
					{
						if (keys[0] == key)
						{
							_Keys.Remove(keys);
							break;
						}
					}
					HttpContext.Current.Cache.Remove(key);
					return true;
				}
				catch
				{
					return false;
				}
			}
			return false;
        }
    }
	

	/*
    /// <summary>
    /// Memcached缓存，单建模式，永远确保只有一个Memcached对象
    /// </summary>
    public sealed class Memcached
    {
		private static Memcached _instance;
        /// <summary>
        /// 创建单件实例
        /// </summary>
        /// <returns></returns>
        public static Memcached GetInstance()
        {
            return _instance == null ? new Memcached() : _instance;
        }

        /// <summary>
        /// 缓存池名称
        /// </summary>
        private string poolName = "GjwMemcacheIOPool";

        /// <summary>
        /// 私有构造
        /// </summary>
        private Memcached()
        {
			string[] serverlist = Constant.MemcachedServer;
            SockIOPool pool = SockIOPool.GetInstance(poolName);
            //设置连接池的初始容量，最小容量，最大容量，Socket 读取超时时间，Socket连接超时时间
            pool.SetServers(serverlist);
            pool.InitConnections = 1;
            pool.MinConnections = 1;
            pool.MaxConnections = 500;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();//容器初始化
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            if (Constant.IsMemcached)
            {
                MemcachedClient mc = new MemcachedClient();
                mc.PoolName = poolName;
                mc.EnableCompression = false;
                if (mc.KeyExists(key)) //测试缓存中是否存在key的值
                    return mc.Get(key);
            }
            return null;
        }

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public bool Set(string key, object obj, DateTime expires)
        {
            if (Constant.IsMemcached)
            {
                MemcachedClient mc = new MemcachedClient();
                mc.PoolName = poolName;
                mc.EnableCompression = false;

				bool reval = mc.Set(key, obj, expires);

				if (key != "AllMemcachedKeys")
				{
					if (reval)
					{
						List<string> keys = Keys;
						if (!keys.Contains(key))
						{
							keys.Add(key);
							Set("AllMemcachedKeys", keys, DateTime.Now.AddYears(10));
						}
					}
				}
				return reval;
            }
            return false;
        }

        /// <summary>
        /// 替换缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public bool Replace(string key,object obj, DateTime expires)
        {
            if (Constant.IsMemcached)
            {
                MemcachedClient mc = new MemcachedClient();
                mc.PoolName = poolName;
                mc.EnableCompression = false;
                return mc.Replace(key, obj, expires);
            }
            return false;
        }

        /// <summary>
        /// 删除缓存项
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
		public bool Delete(string key)
		{
			if (Constant.IsMemcached)
			{
				MemcachedClient mc = new MemcachedClient();
				mc.PoolName = poolName;
				mc.EnableCompression = false;

				bool reval = mc.Delete(key);
				if (key != "AllMemcachedKeys")
				{
					if (reval)
					{
						List<string> keys = Keys;
						if (!keys.Contains(key))
						{
							keys.Remove(key);
							Set("AllMemcachedKeys", keys, DateTime.Now.AddYears(10));
						}
					}
				}

				return reval;
			}
			return false;
		}

        /// <summary>
        /// 判断指定键缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            if (Constant.IsMemcached)
            {
                MemcachedClient mc = new MemcachedClient();
                mc.PoolName = poolName;
                mc.EnableCompression = false;
                return mc.KeyExists(key);
            }
            return false;
        }

		/// <summary>
		/// 所有Key集合
		/// </summary>
		public List<string> Keys
		{
			get
			{
				List<string> _Keys;

				if (Exists("AllMemcachedKeys"))
					_Keys = (List<string>)Get("AllMemcachedKeys");
				else
					_Keys = new List<string>();

				List<string> removeKeys = new List<string>();

				foreach (string s in _Keys)
				{
					if (!Exists(s))
					{
						removeKeys.Add(s);
					}
				}

				foreach (string s in removeKeys)
				{
					_Keys.Remove(s);
				}

				removeKeys.Clear();
				removeKeys = null;

				return _Keys;
			}
		}
    }
	 */
}
