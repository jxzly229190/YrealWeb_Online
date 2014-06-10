using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Data.OleDb;

namespace Common
{
	/// <summary>
	/// 底层数据库操作
	/// </summary>
	public class DataContext
	{
			#region 属性
			/// <summary>
			/// 数据连接字符串
			/// </summary>
			public static string ConnectionString = Constant.ConnectionString;

			private SqlConnection _Connection;
			/// <summary>
			/// 连接对象
			/// </summary>
			public SqlConnection Connection
			{
				set { _Connection = value; }
				get
				{
					if (_Connection == null)
					{
						_Connection = new SqlConnection(ConnectionString);
					}
					return _Connection;
				}
			}

			private SqlTransaction _Transaction;
			/// <summary>
			/// 事务对数
			/// </summary>
			public SqlTransaction Transaction
			{
				set { _Transaction = value; }
				get { return _Transaction; }
			}

			private string _CommandText;

			private List<SqlParameter> _Parameters;
			/// <summary>
			/// 数据库操作参数
			/// </summary>
			public List<SqlParameter> Parameters
			{
				set
				{
					_Parameters = value;
				}
				get
				{
					if (_Parameters == null)
						_Parameters = new List<SqlParameter>();
					return _Parameters;
				}
			}

			private CommandType _CommandType = System.Data.CommandType.Text;
            /// <summary>
            /// SQL查询类型
            /// </summary>
            public CommandType CommandType
            {
                set { _CommandType = value; }
                get 
                {
                    return _CommandType == null ? System.Data.CommandType.Text : _CommandType;
                }
            }

			private SqlCommand _Command;
			/// <summary>
			/// 命令对象
			/// </summary>
			public SqlCommand Command
			{
				set { _Command = value; }
				get
				{
					if (_Command == null)
					{
						_Command = new SqlCommand();
					}
					_Command.CommandText = _CommandText;
                    _Command.CommandType = _CommandType;
                    
					if (Parameters != null)
					{
						_Command.Parameters.Clear();
						_Command.Parameters.AddRange(Parameters.ToArray());
					}
					else
					{
						_Command.Parameters.Clear();
					}
					if (_Transaction != null)
					{
						_Command.Connection = _Transaction.Connection;
						_Command.Transaction = _Transaction;
					}
					else
					{
						_Command.Connection = Connection;
					}
					return _Command;
				}
			}
			#endregion

			/// <summary>
			/// 构造
			/// </summary>
			public DataContext()
			{

			}
			public DataContext(SqlConnection conn)
			{
				_Connection = conn;
			}

			#region 公有方法
			/// <summary>
			/// 执行SQL命令，返回影响条数
			/// </summary>
			///  <param name="sql"></param>
			/// <returns></returns>
			public int ExecuteNonQuery(string sql)
			{
				_CommandText = sql;
				if (Connection.State != System.Data.ConnectionState.Open)
					Connection.Open();
				int reval = Command.ExecuteNonQuery();
				if (Transaction == null)
					Connection.Close();
				return reval;
			}

			/// <summary>
			/// 执行返回第一行第一列查询
			/// </summary>
			///  <param name="sql"></param>
			/// <returns></returns>
			public object ExecuteScalar(string sql)
			{
				_CommandText = sql;
				if (Connection.State != System.Data.ConnectionState.Open)
					Connection.Open();
				object reval = Command.ExecuteScalar();
				if (Transaction == null)
					Connection.Close();
				return reval;
			}

			/// <summary>
			/// 执行只读游标查询
			/// </summary>
			///  <param name="sql"></param>
			/// <returns></returns>
			public SqlDataReader ExecuteReader(string sql)
			{
				_CommandText = sql;
				if (Connection.State != System.Data.ConnectionState.Open)
					Connection.Open();
				SqlDataReader reval = null;
				if (Transaction == null)
					reval = Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				else
					reval = Command.ExecuteReader();
				return reval;
			}

			/// <summary>
			/// 执行数据集查询
			/// </summary>
			///  <param name="sql"></param>
			/// <returns></returns>
			public DataSet ExecuteDataSet(string sql)
			{
				_CommandText = sql;
				SqlDataAdapter da = new SqlDataAdapter(Command);
				DataSet reval = new DataSet();
				da.Fill(reval);
				if (Transaction == null)
					Connection.Close();
				return reval;
			}

			/// <summary>
			/// 执行第一个数据表查询
			/// </summary>
			/// <param name="sql"></param>
			/// <returns></returns>
			public DataTable ExecuteDataTable(string sql)
			{
				return ExecuteDataSet(sql).Tables[0];
			}

			/// <summary>
			/// 开始事务
			/// </summary>
			public void BeginTransaction()
			{
				_Connection = new SqlConnection(ConnectionString);
				_Connection.Open();
				_Transaction = _Connection.BeginTransaction();
				string guid = Guid.NewGuid().ToString().Replace("-", "");
				//HttpContext.Current.Session["Admin_Guid"] = guid;
			}

			/// <summary>
			/// 回滚事务
			/// </summary>
			public void RollBackTransaction()
			{
				if (_Transaction != null)
				{
					_Transaction.Rollback();
				}
			}

			/// <summary>
			/// 提交事务
			/// </summary>
			public void CommitTransaction()
			{
				if (_Transaction != null)
				{
					_Transaction.Commit();
				}
			}
			
			/// <summary>
			/// 关闭链接
			/// </summary>
			public void CloseConnection()
			{
				if (_Connection.State == ConnectionState.Open)
					_Connection.Close();
				_Connection.Dispose();
				HttpContext.Current.Session.Remove("Admin_Guid");
			}
			
			/// <summary>
			/// 清除参数
			/// </summary>
			public void ClearParameters()
			{
                if (_Parameters != null)
                {
                    _Parameters.Clear();
                }
                if (_Command != null)
                {
                    _Command.Parameters.Clear();
                }
			}
			#endregion
	}

	public enum OleDbConnType
	{
 		Access,
		Excel
	}

	public class OleDbDataContext
	{
		public OleDbConnType type;
		public string OleDbFile;
		/// <summary>
		/// 数据连接字符串
		/// </summary>
		public string ConnectionString
		{
			get
			{
				if (type == OleDbConnType.Excel)
					return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(OleDbFile) + ";Extended Properties=Excel 8.0";
				return "";
			}
		}

		private OleDbConnection _Connection;
		/// <summary>
		/// 连接对象
		/// </summary>
		public OleDbConnection Connection
		{
			set { _Connection = value; }
			get
			{
				if (_Connection == null)
				{
					_Connection = new OleDbConnection(ConnectionString);
				}
				return _Connection;
			}
		}

		private string _CommandText;

		private OleDbCommand _Command;
		/// <summary>
		/// 命令对象
		/// </summary>
		public OleDbCommand Command
		{
			set { _Command = value; }
			get
			{
				if (_Command == null)
				{
					_Command = new OleDbCommand();
				}
				_Command.Connection = Connection;
				_Command.CommandText = _CommandText;
				return _Command;
			}
		}

		public OleDbDataContext() { }

		public OleDbDataContext(OleDbConnection conn)
		{
			_Connection = conn;
		}

		/// <summary>
		/// 执行数据集查询
		/// </summary>
		///  <param name="sql"></param>
		/// <returns></returns>
		public DataSet ExecuteDataSet(string sql)
		{
			_CommandText = sql;
			OleDbDataAdapter da = new OleDbDataAdapter(Command);
			DataSet reval = new DataSet();
			da.Fill(reval);
			return reval;
		}

		/// <summary>
		/// 执行第一个数据表查询
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public DataTable ExecuteDataTable(string sql)
		{
			return ExecuteDataSet(sql).Tables[0];
		}
	}
}
