<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Yreal.Web.AddUser" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    �����û�
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" action="AddUser.aspx" method="post">
        <div class="linePanel">
		        <div class="viewAction">
                    <input class="btnText" id="btnBack" href="/Users.aspx" value="�б�" onclick="window.location='/Admin/Users.aspx';" type="button">
		        </div>
                <table class="tbExtend tb-line bgcw lineHeigth30 top15 bottom15 p5">
                    <tbody><tr>
                        <td align="right" width="8%">���䣺</td>
                    <td width="92%"><input name="txtMail" class="input200" clientidmode="Static" id="txtEmail" maxlength="30" type="text"></td>
                    </tr>
                    <tr  width="8%">
                        <td align="right">��¼����</td>
                    <td  width="92%"><input name="txtLgName" class="input200" id="txtLgName" maxlength="20" type="text"></td>
                    </tr>
                    <tr>
                        <td align="right">���룺</td>
                    <td><input name="txtPwd" class="input200" id="txtPwd" maxlength="20" type="text"></td>
                    </tr>
                    <tr>
                        <td align="right">������</td>
                    <td><input name="txtName" class="input200" id="txtName" maxlength="10" type="text"></td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">�ֻ���</td>
                    <td width="92%"><input name="txtMob" class="input200" id="txtMob" maxlength="30" type="text"></td>
                    </tr>
                    <tr>
                        <td align="right">QQ��</td>
                    <td><input class="input80" id="txtQQ" name="txtQQ" maxlength="15" type="text"></td>
                    </tr>
                    <tr>
                        <td align="right">��ע��</td>
                    <td><input name="txtRemark" class="input80" id="txtRemark" name="txtRemark" maxlength="15" type="text"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input class="btnText btnYellow" value="ȷ��" id="btnSubmit" type="submit">
                            <input class="btnText btnYellow" value="����" id="btnReset" type="button">
                        </td>
                    </tr>
                </tbody>
                </table>
        </div>
</form>
</asp:Content>