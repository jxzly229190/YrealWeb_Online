<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="ChannelMger.aspx.cs" Inherits="Yreal.Web.Channel.ChannelMger" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Register TagPrefix="asp" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.0.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    栏目管理
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" action="" runat="server">
    <div class="linePanel">
    <div class="top10">
        <table class="tbList tb-h bgcw">
			<thead>
				<tr>
				    <th width="3%">编码</th>
					<th width="8%">名称</th>
					<th width="4%">类型</th>
                    <th width="4%">内容类型</th>
					<th width="5%">代号</th>
                    <th width="3%">排序</th>
                    <th width="4%">栏目封面</th>
					<th width="4%">状态</th>
                    <th width="8%">备注</th>
                    <th width="6%">创建时间</th>
					<th width="8%">操作</th>
				</tr>
			</thead>
			<tbody class="p5">
            <asp:Repeater runat="server" ID="rptList" ClientIDMode="Static">
            <ItemTemplate>
                <tr id="tr_<%# Eval("ID")%>">
                    <td align="center"><%# Eval("ID")%></td>
                    <td align="left"><%# Eval("Name")%></td>
					<td align="center"><%# Convert.ToInt16(Eval("Type")) == 0 ? "单独内容页" : Convert.ToInt16(Eval("Type")) == 1?"内容列表页":"栏目列表页"%></td>
                    <td align="center"><%# Convert.ToInt16(Eval("ContentType")) == 1 ? "不带封面" : "带封面"%></td>
					<td align="center"><%# Eval("Code")%></td>
                    <td align="center"><%# Eval("Sort")%></td>
                    <td align="center"><img src='<%# Eval("ImageUrl") %>' <%# string.IsNullOrEmpty(Convert.ToString(Eval("ImageUrl")))?"":"width='100' hight='60'" %>/></td>
                    
					<td align="center"><%# Convert.ToInt16(Eval("State")) == 0 ? "菜单显示" : Convert.ToInt16(Eval("Type")) == 1 ? "菜单不显示" : Convert.ToInt16(Eval("Type")) == 2 ? "不可用" : "异常状态"%></td>
					<td align="center"><%# Eval("Remark")%></td>
                    <td align="center"><%# Eval("CreateDate")%></td>
					<td align="center">
                        <a href='Update.aspx?id=<%# Eval("ID") %>'>编辑</a>|
                        <a href='javascript:Del(<%# Eval("ID") %>)'>删除</a>
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

    function Reset(id) {
        if (confirm("您确定要重置密码吗？")) {
            $.ajax({
                type: 'POST',
                url: 'Ajax.aspx',
                data: { id: id, act: "reset" },
                success: function (data) {
                    var json = eval(data)[0];
                    if (json.Success == 1) {
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
