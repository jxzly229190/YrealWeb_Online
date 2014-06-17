<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="ContentMger.aspx.cs" Inherits="Yreal.Web.Content.ContentMger" %>
<%@ Import Namespace="Common" %>
<%@ Register TagPrefix="asp" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.0.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    内容管理
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" action="" runat="server">
    <div class="linePanel">
	<div class="viewAction">
	    
	        <label for="">标题：</label>
		    <input name="txtTitle" type="text" class="input150 right10" id="txtTitle" runat="server" />
            <label for=""> 内容：</label>
		    <input name="txtContentText" type="text" class="input200 right10" id="txtContentText"  runat="server"/>
            <label for=""> 栏目：</label>
		    <asp:DropDownList runat="server" ID="ddlChannel" CssClass="input100" ClientIDMode="Static"></asp:DropDownList>
		    <input class="btnText" type="submit" id="search" value="搜索" />
	    
        <div class="qufenLine"></div>
	</div>
    <div class="top10">
        <table class="tbList tb-h bgcw">
			<thead>
				<tr>
					<th width="10%">标题</th>
					<th width="4%">栏目</th>
					<th width="15%">内容</th>
					<th width="4%">类型</th>
                    <th width="4%">URL</th>
                    <th width="4%">封面图片</th>
                    <th width="4%">状态</th>
                    <th width="4%">创建时间</th>
					<th width="8%">操作</th>
				</tr>
			</thead>
			<tbody class="p5">
            <asp:Repeater runat="server" ID="rptUserList" ClientIDMode="Static">
            <ItemTemplate>
                <tr id="tr_<%# Eval("ID")%>">
                    <td align="left"><%# Eval("Title")%></td>
					<td align="left"><%# Eval("ChannelName")%></td>
					<td align="left"><%# PubFunc.RemoveHtml(HttpUtility.UrlDecode(Eval("ContentText").ToString())).Replace("%","")%></td>
                    <td align="center"><%# Convert.ToInt16(Eval("Type")) == 1 ? "不带封面" : "带封面"%></td>
					<td align="center"><%# Eval("Url")%></td>
					<td align="center"><img src='<%# Eval("ImageUrls") %>' <%# string.IsNullOrEmpty(Eval("ImageUrls").ToString())?"":"width='100' hight='60'" %>/></td>
                    <td align="center"><%# Convert.ToInt16(Eval("State")) == 0 ? "正常" : "异常状态"%></td>
                    <td align="center"><%# Eval("CreateDate")%></td>
					<td align="center">
                        <a href='Update.aspx?id=<%# Eval("ID") %>'>编辑</a>|
                        <a href='javascript:Del(<%# Eval("ID") %>)'>删除</a>|
                        <a href='Detail.aspx?id=<%# Eval("ID") %>'>详情</a>
                    </td>
				</tr>
            </ItemTemplate>
            </asp:Repeater>
			</tbody>
		</table>
	</div>
    <div class="viewPage clearfix">
        <div class="ui-paging">
            <asp:AspNetPager ID="Pager" runat="server" PageSize="20"></asp:AspNetPager>
        </div>
   </div>
</div>
</form>

<script type="text/javascript">
    function Del(id) {
        if (confirm("您确定要删除吗？")) {
            $.ajax({
                type: 'POST',
                url: 'Ajax.aspx',
                data: { id: id, act: "del" },
                success: function (data) {
                    var json = eval(data)[0];
                    if (json.Success == 1) {
                        $("#tr_" + id).remove();
                        alert("操作完成！");
                    } else {
                        alert(json.Message);
                    }
                },
                error: function () {
                    alert("操作失敗");
                }
            });
        }
    }

</script>
</asp:Content>
