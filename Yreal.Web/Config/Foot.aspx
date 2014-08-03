<%@ Page validateRequest="false" Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Foot.aspx.cs" Inherits="Yreal.Web.Config.Foot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    页脚设置
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" action="/Config/Foot.aspx">
        <input type="hidden" id="id" name="id" value="<%=Request.QueryString["id"] %>" />
        <div class="linePanel">
                <table class="tbExtend tb-line bgcw lineHeigth30 top15 bottom15 p5">
                    <tbody>
                        <tr>
                        <td align="right" width="8%">描述：</td>
                        <td width="92%">
                            <%=config.Description %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">代码：</td>
                        <td width="92%">
                            <input type="hidden" name="txtCode" id="txtCode" value="<%=config.Code %>"/>
                            <%=config.Code %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">内容：</td>
                    <td width="92%">
                         <textarea name="text" id="txtText" class="textArea" cols="200" rows="5"><%=config.Text %></textarea>
                    </td>
                    <tr>
                        <td></td>
                        <td>
                            <input class="btnText btnYellow" value="确定" id="btnSubmit" type="submit"/>
                            <input class="btnText btnYellow" value="重填" id="btnReset" type="button"/>
                        </td>
                    </tr>
                </tbody>
                </table>
        </div>
        </form>
</asp:Content>
