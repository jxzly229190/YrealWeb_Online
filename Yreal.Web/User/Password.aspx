<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="Yreal.Web.User.Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    修改密码
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" action="Password.aspx" method="post">
        <div class="linePanel">
		        <div class="viewAction">
                    <input class="btnText" id="btnBack" href="/Users.aspx" value="列表" onclick="window.location='/User/Users.aspx';" type="button">
		        </div>
                <table class="tbExtend tb-line bgcw lineHeigth30 top15 bottom15 p5">
                    <tbody>
                    <tr>
                        <td align="right">原密码：</td>
                    <td><input name="txtPwd" class="input200" id="txtPwd" maxlength="20" type="password" value=""></td>
                    </tr>
                    <tr>
                        <td align="right">新密码：</td>
                    <td><input name="txtNewPwd" class="input200" maxlength="10" type="password"></td>
                    </tr>
                    <tr>
                        <td align="right">重复密码：</td>
                    <td><input name="txtConfirmPwd" class="input200" maxlength="10" type="password"></td>
                    </tr>
                    
                    <tr>
                        <td></td>
                        <td>
                            <input class="btnText btnYellow" value="确定" id="btnSubmit" type="submit">
                            <input class="btnText btnYellow" value="重填" id="btnReset" type="button">
                        </td>
                    </tr>
                </tbody>
                </table>
        </div>
</form>
</asp:Content>
