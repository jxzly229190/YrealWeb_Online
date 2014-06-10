<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imageUpSuccess.aspx.cs" Inherits="Yreal.Web.Content.imageUpSuccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="/Content/<%=Request.QueryString["url"] %>" id="imageUrl" width="100" height="85"/>
    </div>
    </form>
</body>
</html>
