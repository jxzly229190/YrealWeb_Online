using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 是否是输出参数
/// </summary>
public class OutputAttribute : Attribute
{
	public OutputAttribute(bool b, int s)
	{
		Output = b;
		Size = s;
	}
	public bool Output;
	public int Size;
}


public class ColumnAttribute : Attribute
{
	public ColumnAttribute(string dbType)
	{
		DbType = dbType;
	}

	public string DbType;
}