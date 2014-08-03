<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Yreal.Web.Uploade.Test" %>
<%@ Register Src="../Controls/ImageUploader.ascx" TagName="imgUp" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片上传</title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:imgUp ID="imgUp1" GG_X="1000" GG_Y="330" Count="2" runat="server" />
    </div>
    </form>
</body>
</html>
