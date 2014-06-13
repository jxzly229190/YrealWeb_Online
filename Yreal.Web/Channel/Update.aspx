<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Yreal.Web.Channel.Update" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    修改栏目
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" action="Update.aspx" method="post">
        <input type="hidden" id="id" name="id" value="<%=Request.QueryString["id"] %>" />
        <div class="linePanel">
		        <div class="viewAction">
                    <input class="btnText" id="btnBack" href="/Update.aspx" value="列表" onclick="window.location='/Channel/ChannelMger.aspx';" type="button">
		        </div>
                <table class="tbExtend tb-line bgcw lineHeigth30 top15 bottom15 p5">
                    <tbody>
                        <tr>
                        <td align="right" width="8%">父菜单：</td>
                    <td width="92%">
                        <asp:DropDownList ID="ddlParentId" runat="server" >
                        </asp:DropDownList>
                    </td>
                    </tr>
                        <tr>
                        <td align="right" width="8%">名称：</td>
                    <td width="92%"><input name="txtName" class="input200" value="<%=channel.Name %>" clientidmode="Static" id="txtName" maxlength="30" type="text"></td>
                    </tr>
                    <tr  width="8%">
                        <td align="right">代码：</td>
                    <td  width="92%"><input name="txtCode" class="input200" value="<%=channel.Code %>" id="txtCode" maxlength="20" type="text"></td>
                    </tr>
                    <tr  width="8%">
                        <td align="right">栏目封面：</td>
                    <td  width="92%">
                        <img src="<%=channel.ImageUrl %>" id="imgShow" width="200" height="120"/>
                        <input type="hidden" id="txtImage" name="txtImage" value="<%=channel.ImageUrl %>"/>
                        <iframe width="500" id="iframepage" height="50" frameborder="no" border="0" marginwidth="0" marginheight="0" src="../Content/imageUpload.aspx" onload="iFrameHeight()"></iframe>
                        <input type="button" onclick="$('#iframepage').attr('src','/Content/imageUpload.aspx');$('#imgShow').remove();$('#txtImage').val('');" value="删除"/>
                    </td>
                    </tr>
                    <tr>
                        <td align="right">类型：</td>
                    <td><asp:DropDownList ID="ddlType" runat="server">
                        </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">内容类型：</td>
                    <td><select id="sltContentType" name="sltContentType" class="input200"><option value="1" <%=channel.ContentType==1?"selected='selected'":"" %>>不带封面</option><option value="2" <%=channel.ContentType==2?"selected='selected'":"" %>>带封面</option></select></td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">状态：</td>
                    <td width="92%"><select id="sltState" name="sltState" class="input200">
                                        <option  value="0" <%=channel.State==0?"selected='selected'":"" %>>菜单显示</option>
                                        <option value="1" <%=channel.State==1?"selected='selected'":"" %>>菜单不显示</option>
                                        <option value="2" <%=channel.State==2?"selected='selected'":"" %>>不可用</option>
                                    </select></td>
                    </tr>
                    <tr>
                        <td align="right">排序：</td>
                    <td><input class="input80" id="txtSort" name="txtSort" value="<%=channel.Sort %>" maxlength="15" type="text"></td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                    <td><input name="txtRemark" class="input80" id="txtRemark" value="<%=channel.Remark %>" name="txtRemark" maxlength="15" type="text"></td>
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
<script type="text/javascript">
    function iFrameHeight() {
        var ifm = document.getElementById("iframepage");
        var subWeb = document.frames ? document.frames["iframepage"].document : ifm.contentDocument;
        if (ifm != null && subWeb != null) {
            ifm.height = subWeb.body.scrollHeight;
        }

        var image = document.getElementById('iframepage').contentDocument.getElementById("imageUrl");
        $("#txtImage").val($(image).attr("src"));
    }
</script>
</asp:Content>
