<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Yreal.Web.Channel.Add" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    新增栏目
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" action="Add.aspx" method="post">
        <div class="linePanel">
		        <div class="viewAction">
                    <input class="btnText" id="btnBack" href="/Add.aspx" value="列表" onclick="window.location='/Channel/ChannelMger.aspx';" type="button">
		        </div>
                <table class="tbExtend tb-line bgcw lineHeigth30 top15 bottom15 p5">
                    <tbody>
                        <tr>
                        <td align="right" width="8%">父菜单：</td>
                    <td width="92%">
                        <asp:DropDownList ID="ddlParentId" runat="server" 
                            onselectedindexchanged="ddlParentId_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    </tr>
                        <tr>
                        <td align="right" width="8%">名称：</td>
                    <td width="92%"><input name="txtName" class="input200" clientidmode="Static" id="txtName" maxlength="30" type="text"></td>
                    </tr>
                    <tr  width="8%">
                        <td align="right">代码：</td>
                    <td  width="92%"><input name="txtCode" class="input200" id="txtCode" maxlength="20" type="text"></td>
                    </tr>
                    <tr>
                        <td align="right">类型：</td>
                    <td><asp:DropDownList ID="ddlType" runat="server">
                        </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">内容类型：</td>
                    <td><select id="sltContentType" name="sltContentType" class="input200"><option  value="1">不带封面</option><option value="2">带封面</option></select></td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">状态：</td>
                    <td width="92%"><select id="sltState" name="sltState" class="input200"><option  value="0">菜单显示</option><option value="1">菜单不显示</option><option value="2">不可用</option></select></td>
                    </tr>
                    <tr>
                        <td align="right">排序：</td>
                    <td><input class="input80" id="txtSort" name="txtSort" maxlength="15" type="text"></td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                    <td><input name="txtRemark" class="input80" id="txtRemark" name="txtRemark" maxlength="15" type="text"></td>
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
