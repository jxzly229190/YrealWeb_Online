<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imageUpload.aspx.cs" Inherits="Yreal.Web.Content.imageUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formUp" runat="server" action="imageUpload.aspx" method="POST"><asp:FileUpload ID="txtImage" runat="server"></asp:FileUpload><input type="hidden" name="editorid" value="container"/><input type="submit" value="上传"/></form>
</body>
</html>
