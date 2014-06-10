namespace Yreal.Web.common
{
    public class Common
    {
        public static string GetJSMsgBox(string message)
        {
            return "<script language='javascript'>alert('" + message + "')</script>";
        }
    }
}