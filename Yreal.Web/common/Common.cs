namespace Yreal.Web.common
{
    using System;

    public class Common
    {
        public static string GetJSMsgBox(string message)
        {
            return "<script language='javascript'>alert('" + message + "')</script>";
        }

        public const string UploadImagePath = "/upload/image/";
    }
}