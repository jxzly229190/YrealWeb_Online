using System;
using System.Data;

namespace Common
{
	/// <summary>
	/// Ajax执行结果
	/// </summary>
	public class AjaxResult
	{
		/// <summary>
		/// 结果
		/// </summary>
		public int Success;
		/// <summary>
		/// 消息
		/// </summary>
		public string Message;
		/// <summary>
		/// 返回内容
		/// </summary>
		public object Data;
		public override string ToString()
		{
			string strData = string.Empty;
			if (Data != null)
			{
				Type type = Data.GetType();
				if (type == typeof(DataTable))
				{
					DataTable dt = (DataTable)Data;
					strData = dt.ToJsonString();
				}
				else if (type == typeof(DataSet))
				{
					DataSet ds = (DataSet)Data;
					strData = ds.ToJsonString();
				}
				else if (type.BaseType.Name == "BaseTable")
				{
					IModel.BaseTable table = (IModel.BaseTable)Data;
					strData = table.ToJsonString();
				}
				else
				{
					strData = "'" + Data.ToString() + "'";
				}
			}
			if (!string.IsNullOrEmpty(Message))
				Message = Message.Replace("'", "\\'");
			strData = string.IsNullOrEmpty(strData) ? "''" : strData;
            return "[{'Success':'" + Success + "',Message:'" + Message + "','Data':" + strData + "}]";
		}

        public string ToJsonString()
        {
            string strData = string.Empty;
            if (Data != null)
            {
                Type type = Data.GetType();
                if (type == typeof(DataTable))
                {
                    DataTable dt = (DataTable)Data;
                    strData = dt.ToJsonString();
                }
                else if (type == typeof(DataSet))
                {
                    DataSet ds = (DataSet)Data;
                    strData = ds.ToJsonString();
                }
                else if (type.BaseType.Name == "BaseTable")
                {
                    IModel.BaseTable table = (IModel.BaseTable)Data;
                    strData = table.ToJsonString();
                }
                else
                {
                    strData = Data.ToString();
                }
            }
            if (!string.IsNullOrEmpty(Message))
                Message = Message.Replace("'", "\\'");
            strData = string.IsNullOrEmpty(strData) ? "\"\"" : strData;
            return "[{\"Success\":" + Success + ",\"Message\":\"" + Message + "\",\"Data\":" + strData + "}]";
        }
	}
}
