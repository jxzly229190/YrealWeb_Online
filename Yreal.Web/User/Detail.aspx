<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Yreal.Web.User.Detail" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    用户详情
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="linePanel">
		        <div class="viewAction">
                    <input class="btnText" id="btnBack" href="/Users.aspx" value="列表" onclick="window.location='/User/Users.aspx';" type="button">
		        </div>
                <table class="tbExtend tb-line bgcw lineHeigth30 top15 bottom15 p5">
                    <tbody>
                    <tr>
                        <td align="right">姓名：</td>
                        <td><asp:Label name="txtName" CssClass="input200" runat="server" id="txtName"/></td>
                    </tr>
                    <tr  width="8%">
                        <td align="right">登录名：</td>
                        <td  width="92%"><asp:Label name="txtLgName" runat="server" CssClass="input200" id="txtLgName"/></td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">邮箱：</td>
                               <td width="92%"><asp:Label name="txtMail" runat="server" CssClass="input200" id="txtEmail"/></td>
                    </tr>
                    <tr>
                        <td align="right">QQ：</td>
                        <td><asp:Label CssClass="input80" ID="txtQQ" runat="server" /></td>
                    </tr>
                    <tr>
                        <td align="right">手机：</td>
                        <td><asp:Label name="txtRemark" CssClass="input80" runat="server" id="txtMob" /></td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td><asp:Label CssClass="input80" runat="server" id="txtRemark" /></td>
                    </tr>
                    <tr>
                        <td align="right">状态：</td>
                        <td><asp:Label CssClass="input80" runat="server" id="txtState" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">创建时间：</td>
                        
                        <td><asp:Label CssClass="input80" ID="txtCreateDate" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">最后修改时间：</td>
                        <td><asp:Label CssClass="input80" ID="txtModifyDate" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
                </table>
        </div>
</asp:Content>
