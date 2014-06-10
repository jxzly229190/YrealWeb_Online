using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Common
{
	public partial class DataAccess
	{
		private DataContext _ctx;
		/// <summary>
		/// 数据库操作对象
		/// </summary>
		public DataContext ctx
		{
			set
			{
				_ctx = value;
			}
			get
			{
				if (_ctx == null)
					_ctx = new DataContext();
				return _ctx;
			}
		}

		private DataContext _ctx_log;
		/// <summary>
		/// 数据库操作对象
		/// </summary>
		public DataContext ctx_log
		{
			set
			{
				_ctx_log = value;
			}
			get
			{
				if (_ctx_log == null)
				{
					_ctx_log = new DataContext();
				}
				return _ctx_log;
			}
		}

		private List<SqlParameter> _Parameters;
		/// <summary>
		/// 数据库操作参数
		/// </summary>
		public List<SqlParameter> Parameters
		{
			set
			{
				_Parameters=value;
			}
			get
			{
				if (_Parameters == null)
					_Parameters = new List<SqlParameter>();
				return _Parameters;
			}
		}
        
	}

	/// <summary>
	/// 数据表操作
	/// </summary>
	public partial class DataAccess
	{
		/// <summary>
		/// 数据表实体
		/// </summary>
		public IModel.BaseTable TableEntity
		{
			set;
			get;
		}
        /// <summary>
        /// 数据表实体集
        /// </summary>
        public IModel.BaseTable[] TableEntities
        {
            set;
            get;
        }

		#region 私有方法

		/// <summary>
		/// 获取字段类型
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		private SqlDbType GetSqlType(PropertyInfo info)
		{
			Type type = info.PropertyType;
			if (type == typeof(int) || type == typeof(int?))
				return SqlDbType.Int;
			if (type == typeof(string))
			{
				object[] attrs = info.GetCustomAttributes(true);
				foreach (Attribute attr in attrs)
				{
					string attrName = attr.GetType().Name;
					if (attrName == "ColumnAttribute")
					{
						ColumnAttribute cattr = attr as ColumnAttribute;
						if (cattr.DbType == "varchar")
						{
							return SqlDbType.VarChar;
						}
						else if (cattr.DbType == "nvarchar")
						{
							return SqlDbType.NVarChar;
						}
						else if (cattr.DbType == "ntext")
						{
							return SqlDbType.NText;
						}
						else
						{
							return SqlDbType.VarChar;
						}
					}
				}
				return SqlDbType.VarChar;
			}
			if (type == typeof(DateTime) || type == typeof(DateTime?))
				return SqlDbType.DateTime;
			if (type == typeof(double) || type == typeof(double?))
				return SqlDbType.Float;
			if (type == typeof(byte) || type == typeof(byte?))
				return SqlDbType.TinyInt;
			else
				return SqlDbType.VarChar;
		}

		/// <summary>
		/// 返回插入命令
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		private string GetInsertCommand()
		{
			string str0, str1, str2;
			Type type = TableEntity.GetType();
			str0 = type.Name;//表名

			string sql = "INSERT INTO {0} ({1}) VALUES ({2});SELECT @@IDENTITY;";
			//if (!ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
			//{
			//    if (Constant.IsCopyLog)
			//    {
			//        sql += "INSERT INTO " + Constant.CopyLogDb + "{0} SELECT *," + PubFunc.GetAdminID() + ",'" + PubFunc.GetAdminGuid() + "',GETDATE() FROM {0} WHERE ID=@@IDENTITY;";
			//    }
			//}
			
			PropertyInfo[] infos = type.GetProperties();
			List<string> lstField1 = new List<string>();//字段
			List<string> lstField2 = new List<string>();//字段
			for (int i = 0; i < infos.Length; i++)
			{
				PropertyInfo info = infos[i];
				string strName = info.Name;
				if (strName.ToUpper() != "ID" && strName.ToUpper() != "WHERE")
				{
					object objValue = info.GetValue(TableEntity, null);
					if (objValue != null)
					{
						lstField1.Add(string.Format("[{0}]", strName));
						lstField2.Add("@" + strName);
						SqlParameter param = new SqlParameter();
						param.ParameterName = strName;
						param.SqlDbType = GetSqlType(info);
						param.Value = objValue;
						param.Direction = ParameterDirection.Input;
						Parameters.Add(param);
					}
				}
			}
			str1 = string.Join(",", lstField1.ToArray());
			str2 = string.Join(",", lstField2.ToArray());
			ctx.CommandType = CommandType.Text;
			ctx.Parameters.AddRange(Parameters.ToArray());
			sql = string.Format(sql, str0, str1, str2);
			return sql;
		}
        /// <summary>
        /// 返回多条插入命令
        /// </summary>
        /// <returns></returns>
        private string GetInsertCommands()
        {
            StringBuilder sb = new StringBuilder();
            int c = 0;
            foreach (IModel.BaseTable entity in TableEntities)
            {
				string sql = "INSERT INTO {0} ({1}) VALUES ({2});";
				//if (!ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
				//{
				//    if (Constant.IsCopyLog)
				//    {
				//        sql += "INSERT INTO " + Constant.CopyLogDb + "{0} SELECT *," + PubFunc.GetAdminID() + ",'" + PubFunc.GetAdminGuid() + "',GETDATE() FROM {0} WHERE ID=@@IDENTITY;";
				//    }
				//}
                string str0, str1, str2;
                Type type = entity.GetType();
                str0 = type.Name;//表名
                PropertyInfo[] infos = type.GetProperties();
                List<string> lstField1 = new List<string>();//字段
                List<string> lstField2 = new List<string>();//字段
                for (int i = 0; i < infos.Length; i++)
                {
                    PropertyInfo info = infos[i];
                    string strName = info.Name;
                    if (strName.ToUpper() != "ID" && strName.ToUpper() != "WHERE")
                    {
                        object objValue = info.GetValue(entity, null);
                        if (objValue != null)
                        {
                            lstField1.Add(string.Format("[{0}]", strName));
                            lstField2.Add("@" + strName + c);
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = strName + c;
                            param.SqlDbType = GetSqlType(info);
                            param.Value = objValue;
                            param.Direction = ParameterDirection.Input;
                            Parameters.Add(param);
                        }
                    }
                }
                str1 = string.Join(",", lstField1.ToArray());
                str2 = string.Join(",", lstField2.ToArray());
                sql = string.Format(sql, str0, str1, str2);
                sb.AppendLine(sql);
                c++;
            }
            ctx.CommandType = CommandType.Text;
            ctx.Parameters.AddRange(Parameters.ToArray());
            return sb.ToString();
        }

		/// <summary>
		/// 返回更新命令
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		private string[] GetUpdateCommand()
		{
			string[] sql = { "", "" };
			string str0, str1;
			Type type = TableEntity.GetType();
			str0 = type.Name;//表名
			PropertyInfo[] infos = type.GetProperties();
			List<string> lstField = new List<string>();//字段
			int intID = 0;
			for (int i = 0; i < infos.Length; i++)
			{
				PropertyInfo info = infos[i];
				string strName = info.Name;
				if (strName.ToUpper() != "ID" && strName.ToUpper() != "WHERE")
				{
					object objValue = info.GetValue(TableEntity, null);
					if (objValue != null)
					{
						lstField.Add("[" + strName + "]" + "=@" + strName);
						SqlParameter param = new SqlParameter();
						param.ParameterName = strName;
						param.SqlDbType = GetSqlType(info);
						param.Value = objValue;
						param.Direction = ParameterDirection.Input;
						Parameters.Add(param);
					}
				}
				else if (strName.ToUpper() == "ID")
				{
					object objValue = info.GetValue(TableEntity, null);
					intID = Convert.ToInt32(objValue);
				}
			}
			str1 = string.Join(",", lstField.ToArray());
			if (intID > 0)
			{
				if (Constant.IsCopyLog && !ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
				{
					sql[1] = "INSERT INTO " + Constant.CopyLogDb + "{0} SELECT *," + PubFunc.GetAdminID() + ",'" + PubFunc.GetAdminGuid() + "',GETDATE() FROM {0} WITH(NOLOCK) WHERE ID=@ID;";
				}
				sql[0] = "UPDATE {0} SET {1} WHERE ID = @ID;";
				
				SqlParameter paramID = new SqlParameter("ID", intID);
				paramID.SqlDbType = SqlDbType.Int;
				paramID.Direction = ParameterDirection.Input;
				Parameters.Add(paramID);
				sql[1] = string.Format(sql[1], str0, str1);
				sql[0] = string.Format(sql[0], str0, str1);
			}
			else if (!string.IsNullOrEmpty(TableEntity.Where))
			{
				if (Constant.IsCopyLog && !ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
				{
					sql[1] = "INSERT INTO " + Constant.CopyLogDb + "{0} SELECT *," + PubFunc.GetAdminID() + ",'" + PubFunc.GetAdminGuid() + "',GETDATE() FROM {0} WITH(NOLOCK) WHERE {2};";
				}
				sql[0] = "UPDATE {0} SET {1} WHERE {2}";
				
				sql[1] = string.Format(sql[1], str0, str1, TableEntity.Where);
				sql[0] = string.Format(sql[0], str0, str1, TableEntity.Where);
			}
			ctx.CommandType = CommandType.Text;
			ctx.Parameters.AddRange(Parameters.ToArray());

			ctx_log.CommandType = CommandType.Text;
			ctx_log.Parameters.AddRange(Parameters.ToArray());
			return sql;
		}
        /// <summary>
        /// 返回多条更新命令
        /// </summary>
        /// <returns></returns>
        private string[] GetUpdateCommands()
        {
            StringBuilder sb = new StringBuilder();
			StringBuilder sb_log = new StringBuilder();
            int c = 0;
            foreach (IModel.BaseTable entity in TableEntities)
            {
				string[] sql = { "", "" };
                string str0, str1;
                Type type = entity.GetType();
                str0 = type.Name;//表名
                PropertyInfo[] infos = type.GetProperties();
                List<string> lstField = new List<string>();//字段
                int intID = 0;
                for (int i = 0; i < infos.Length; i++)
                {
                    PropertyInfo info = infos[i];
                    string strName = info.Name;
                    if (strName.ToUpper() != "ID" && strName.ToUpper() != "WHERE")
                    {
                        object objValue = info.GetValue(entity, null);
                        if (objValue != null)
                        {
                            lstField.Add("[" + strName + "]" + "=@" + strName + c);
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = strName + c;
                            param.SqlDbType = GetSqlType(info);
                            param.Value = objValue;
                            param.Direction = ParameterDirection.Input;
                            Parameters.Add(param);
                        }
                    }
                    else if (strName.ToUpper() == "ID")
                    {
                        object objValue = info.GetValue(entity, null);
                        intID = Convert.ToInt32(objValue);
                    }
                }
                str1 = string.Join(",", lstField.ToArray());
                if (intID > 0)
                {
					if (Constant.IsCopyLog && !ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
					{
						sql[1] = "INSERT INTO " + Constant.CopyLogDb + "{0} SELECT *," + PubFunc.GetAdminID() + ",'" + PubFunc.GetAdminGuid() + "',GETDATE() FROM {0} WITH(NOLOCK) WHERE ID= @ID" + c + ";";
					}
                    sql[0] = "UPDATE {0} SET {1} WHERE ID = @ID" + c + ";";
                    SqlParameter paramID = new SqlParameter("ID" + c, intID);
                    paramID.SqlDbType = SqlDbType.Int;
                    paramID.Direction = ParameterDirection.Input;
                    Parameters.Add(paramID);
                    sql[1] = string.Format(sql[1], str0, str1);
					sql[0] = string.Format(sql[0], str0, str1);
                }
                else if (!string.IsNullOrEmpty(entity.Where))
                {
					if (Constant.IsCopyLog && !ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
					{
						sql[1] = "INSERT INTO " + Constant.CopyLogDb + "{0} SELECT *," + PubFunc.GetAdminID() + ",'" + PubFunc.GetAdminGuid() + "',GETDATE() FROM {0} WITH(NOLOCK) WHERE {2};";
					}
                    sql[0] = "UPDATE {0} SET {1} WHERE {2};";
                    sql[1] = string.Format(sql[1], str0, str1, entity.Where);
					sql[0] = string.Format(sql[0], str0, str1, entity.Where);
                }
                sb.AppendLine(sql[0]);
				sb_log.AppendLine(sql[1]);
                c++;
            }
            ctx.CommandType = CommandType.Text;
            ctx.Parameters.AddRange(Parameters.ToArray());
			return new string[] { sb.ToString(), sb_log.ToString() };
        }

		/// <summary>
		/// 返回删除命令
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		private string[] GetDeleteCommand()
		{
			string[] sql = { "", "" };
			if (Constant.IsCopyLog && !ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
			{
				sql[1] = "INSERT INTO " + Constant.CopyLogDb + "{0} SELECT *," + PubFunc.GetAdminID() + ",'" + PubFunc.GetAdminGuid() + "',GETDATE() FROM {0} WITH(NOLOCK) WHERE 1=1 {1};";
			}
			sql[0] = "DELETE FROM {0} WHERE 1=1 {1}";
			string str0 = string.Empty, str1 = string.Empty;
			Type type = TableEntity.GetType();
			str0 = type.Name;//表名
			PropertyInfo[] infos = type.GetProperties();
			for (int i = 0; i < infos.Length; i++)
			{
				PropertyInfo info = infos[i];
				string strName = info.Name;
				object objValue = info.GetValue(TableEntity, null);
				if (objValue != null)
				{
					if (strName.ToUpper() != "WHERE")
					{
						str1 += " and [" + strName + "]" + "=@" + strName;
						SqlParameter param = new SqlParameter();
						param.ParameterName = strName;
						param.SqlDbType = GetSqlType(info);
						param.Value = objValue;
						param.Direction = ParameterDirection.Input;
						Parameters.Add(param);
					}
					else
					{
						str1 += " and " + TableEntity.Where;
					}
				}
			}
			
			ctx.CommandType = CommandType.Text;
			ctx.Parameters.AddRange(Parameters.ToArray());
			sql[1] = string.Format(sql[1], str0, str1);
			sql[0] = string.Format(sql[0], str0, str1);
			return sql;
		}
        /// <summary>
        /// 返回多条删除命令
        /// </summary>
        /// <returns></returns>
        private string[] GetDeleteCommands()
        {
            StringBuilder sb = new StringBuilder();
			StringBuilder sb_log = new StringBuilder();
            int c = 0;
            foreach (IModel.BaseTable entity in TableEntities)
            {
				string[] sql = { "", "" };
				if (Constant.IsCopyLog && !ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
				{
					sql[1] = "INSERT INTO " + Constant.CopyLogDb + "{0} SELECT *," + PubFunc.GetAdminID() + ",'" + PubFunc.GetAdminGuid() + "',GETDATE() FROM {0} WITH(NOLOCK) WHERE 1=1 {1};";
				}
                sql[0] = "DELETE FROM {0} WHERE 1=1 {1};";
                string str0 = string.Empty, str1 = string.Empty;
                Type type = entity.GetType();
                str0 = type.Name;//表名
                PropertyInfo[] infos = type.GetProperties();
                for (int i = 0; i < infos.Length; i++)
                {
                    PropertyInfo info = infos[i];
                    string strName = info.Name;
                    object objValue = info.GetValue(entity, null);
                    if (objValue != null)
                    {
                        if (strName.ToUpper() != "WHERE")
                        {
                            str1 += " and [" + strName + "]" + "=@" + strName + c;
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = strName + c;
                            param.SqlDbType = GetSqlType(info);
                            param.Value = objValue;
                            param.Direction = ParameterDirection.Input;
                            Parameters.Add(param);
                        }
                        else
                        {
                            str1 += " and " + entity.Where;
                        }
                    }
                }
                sql[1] = string.Format(sql[1], str0, str1);
				sql[0] = string.Format(sql[0], str0, str1);
                sb.AppendLine(sql[0]);
				sb_log.AppendLine(sql[1]);
                c++;
            }
            ctx.CommandType = CommandType.Text;
            ctx.Parameters.AddRange(Parameters.ToArray());
			return new string[] { sb.ToString(), sb_log.ToString() };
        }

		/// <summary>
		/// 返回读取命令
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		private string GetSelectCommand()
		{
			string sql = "SELECT * FROM {0} WHERE 1=1 {1}";
			string str0 = string.Empty, str1 = string.Empty;
			Type type = TableEntity.GetType();
			str0 = type.Name;//表名
			PropertyInfo[] infos = type.GetProperties();
			for (int i = 0; i < infos.Length; i++)
			{
				PropertyInfo info = infos[i];
				string strName = info.Name;
				object objValue = info.GetValue(TableEntity, null);
				if (objValue != null)
				{
					if (strName.ToUpper() != "WHERE")
					{
						str1 += " and [" + strName + "]" + "=@" + strName;
						SqlParameter param = new SqlParameter();
						param.ParameterName = strName;
						param.SqlDbType = GetSqlType(info);
						param.Value = objValue;
						param.Direction = ParameterDirection.Input;
						Parameters.Add(param);
					}
					else
					{
						str1 += " and " + TableEntity.Where;
					}
				}
			}
			
			ctx.CommandType = CommandType.Text;
			ctx.Parameters.AddRange(Parameters.ToArray());
			sql = string.Format(sql, str0, str1);
			return sql;
		}

		#endregion

		#region 公有方法

		/// <summary>
		/// 新增记录 返回记录ID
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			int re = 0;
			string sql = string.Empty;
			if (TableEntities == null || TableEntities.Length == 0)//单条插入
			{
				sql = GetInsertCommand();
				int intID = 0;
				object objID = ctx.ExecuteScalar(sql);
				if (objID != null)
				{
					intID = Convert.ToInt32(objID);
					Type type = TableEntity.GetType();
					type.GetProperty("ID").SetValue(TableEntity, intID, null);
				}
				re = intID;
			}
			else//多条插入
			{
				sql = GetInsertCommands();
				re = ctx.ExecuteNonQuery(sql);
			}
			ctx.ClearParameters();
			Parameters.Clear();
			return re;
		}

		/// <summary>
		/// 更新记录 返回更新条数
		/// </summary>
		/// <returns></returns>
		public int Update()
		{
			string[] sql = { "", "" };
			if (TableEntities == null || TableEntities.Length == 0)//单条更新
			{
				sql = GetUpdateCommand();
			}
			else//多条更新
			{
				sql = GetUpdateCommands();
			}

			if (Constant.IsCopyLog && !ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
			{
				try
				{
					if (!string.IsNullOrEmpty(sql[1]))
						ctx_log.ExecuteNonQuery(sql[1]);
				}
				catch
				{
					;
				}
				finally
				{
					ctx_log.ClearParameters();
				}
			}

			int re = ctx.ExecuteNonQuery(sql[0]);
			ctx.ClearParameters();
			Parameters.Clear();
			return re;
		}

		/// <summary>
		/// 删除记录 返回删除条数
		/// </summary>
		/// <returns></returns>
		public int Delete()
		{
			string[] sql = { "", "" };
			if (TableEntities == null || TableEntities.Length == 0)//单条删除
			{
				sql = GetDeleteCommand();
			}
			else//多条删除
			{
				sql = GetDeleteCommands();
			}

			if (Constant.IsCopyLog && !ctx.Connection.ConnectionString.Contains("goujiuwang_v4_log"))
			{
				try
				{
					if (!string.IsNullOrEmpty(sql[1]))
						ctx_log.ExecuteNonQuery(sql[1]);
				}
				catch
				{
					;
				}
				finally
				{
					ctx_log.ClearParameters();
				}
			}

			int re = ctx.ExecuteNonQuery(sql[0]);
			ctx.ClearParameters();
			Parameters.Clear();
			return re;
		}

		/// <summary>
		/// 默认查询
		/// </summary>
		/// <returns></returns>
		public DataTable Select()
		{
			string sql = GetSelectCommand();
			DataTable dt = ctx.ExecuteDataTable(sql);
			ctx.ClearParameters();
			Parameters.Clear();
			return dt;
		}

		#endregion
	}

	/// <summary>
	/// 存储过程操作
	/// </summary>
	public partial class DataAccess
	{
		/// <summary>
		/// 存储过程实体
		/// </summary>
		public IModel.BaseProcedure ProcedureEntity
		{
			set;
			get;
		}

		/// <summary>
		/// 获取存储过程命令
		/// </summary>
		/// <returns></returns>
		private string GetProcedureCommand()
		{
			Type type = ProcedureEntity.GetType();
			PropertyInfo[] infos = type.GetProperties();
			foreach (PropertyInfo info in infos)
			{
				string strName = info.Name;
				if (strName != "Return")
				{
					object objValue = info.GetValue(ProcedureEntity, null);
					objValue = objValue == null ? DBNull.Value : objValue;
					SqlParameter param = new SqlParameter();
					param.ParameterName = "@" + strName;
					param.SqlDbType = GetSqlType(info);
					param.Value = objValue;

					object[] attrs = info.GetCustomAttributes(true);
					foreach (Attribute attr in attrs)
					{
						string attrName = attr.GetType().Name;
						if (attrName == "OutputAttribute")
						{
							OutputAttribute stxa = attr as OutputAttribute;
							if (stxa.Output)
							{
								param.Direction = ParameterDirection.Output;
								param.Size = stxa.Size;
								break;
							}
						}
					}

					Parameters.Add(param);
				}
				else
				{
					SqlParameter paramRe = new SqlParameter();
					paramRe.ParameterName = "@Return";
					paramRe.SqlDbType = SqlDbType.Int;
					paramRe.Direction = ParameterDirection.ReturnValue;
					Parameters.Add(paramRe);
				}
			}
			string sql = type.Name;
			ctx.Parameters.AddRange(Parameters.ToArray());
			ctx.CommandType = CommandType.StoredProcedure;
			return sql;
		}
		/// <summary>
		/// 获取Output参数返回值
		/// </summary>
		private void GetProcedureOutputParameter()
		{
			Type type = ProcedureEntity.GetType();
			PropertyInfo[] infos = type.GetProperties();
			string strReturn = null;
			foreach (PropertyInfo info in infos)
			{
				bool flag = false;
				string strName = info.Name;
				object[] attrs = info.GetCustomAttributes(true);
				foreach (Attribute attr in attrs)
				{
					string attrName = attr.GetType().Name;
					if (attrName == "OutputAttribute")
					{
						OutputAttribute stxa = attr as OutputAttribute;
						if (stxa.Output)
						{
							foreach (SqlParameter param in Parameters)
							{
								if (param.ParameterName == strName || param.ParameterName == "@" + strName)
								{
									info.SetValue(ProcedureEntity, param.Value, null);
									flag = true;
									break;
								}
								else if (param.ParameterName == "Return" || param.ParameterName == "@Return")
								{
									strReturn = param.Value.ToString();
								}
							}
						}
					}
					if (flag)
						break;
				}
			}
			if (string.IsNullOrEmpty(strReturn))
			{
				foreach (SqlParameter param in Parameters)
				{
					if (param.ParameterName == "Return" || param.ParameterName == "@Return")
					{
						strReturn = param.Value.ToString();
					}
				}
			}
			ProcedureEntity.Return = strReturn;
		}


		/// <summary>
		/// 执行SQL命令，返回影响条数
		/// </summary>
		/// <returns></returns>
		public int ExecuteNonQuery()
		{
			string sql = GetProcedureCommand();
			int re = ctx.ExecuteNonQuery(sql);
			GetProcedureOutputParameter();
			ctx.ClearParameters();
			Parameters.Clear();
			return re;
		}
		/// <summary>
		/// 执行返回第一行第一列查询
		/// </summary>
		/// <returns></returns>
		public object ExecuteScalar()
		{
			string sql = GetProcedureCommand();
			object re= ctx.ExecuteScalar(sql);
			GetProcedureOutputParameter();
			ctx.ClearParameters();
			Parameters.Clear();
			return re;
		}
		/// <summary>
		/// 执行只读游标查询
		/// </summary>
		/// <returns></returns>
		public SqlDataReader ExecuteReader()
		{
			string sql = GetProcedureCommand();
			SqlDataReader re= ctx.ExecuteReader(sql);
			GetProcedureOutputParameter();
			ctx.ClearParameters();
			Parameters.Clear();
			return re;
		}
		/// <summary>
		/// 执行数据集查询
		/// </summary>
		/// <returns></returns>
		public DataSet ExecuteDataSet()
		{
			string sql = GetProcedureCommand();
			DataSet re= ctx.ExecuteDataSet(sql);
			GetProcedureOutputParameter();
			ctx.ClearParameters();
			Parameters.Clear();
			return re;
		}
		/// <summary>
		/// 执行第一个数据表查询
		/// </summary>
		/// <returns></returns>
		public DataTable ExecuteDataTable()
		{
			string sql = GetProcedureCommand();
			DataTable re= ctx.ExecuteDataTable(sql);
			GetProcedureOutputParameter();
			ctx.ClearParameters();
			Parameters.Clear();
			return re;
		}

	}
}
