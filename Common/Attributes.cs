using System;


/// <summary>
/// 是否记录到XML
/// </summary>
public class InputAttribute : Attribute
{
	public InputAttribute(bool b)
	{
		CanSave = b;
	}
	public bool CanSave;
}
