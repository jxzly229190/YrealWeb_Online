<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Yreal.Web.Users" %>
<%@ Register TagPrefix="asp" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.0.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    用户管理
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="Form1" action="" runat="server">
    <div class="linePanel">
	<div class="viewAction">
	    
	        <label for="">邮箱：</label>
		    <input name="txtEmail" type="text" class="input200 right10" id="txtEmail" runat="server" />
            <label for=""> 姓名：</label>
		    <input name="txtName" type="text" class="input80 right10" id="txtName"  runat="server"/>
            <label for=""> 登录账户：</label>
		    <input name="txtNickName" type="text" class="input150 right10" id="txtLgName" runat="server" />
            <label for=""> 手机：</label>
		    <input name="txtMob" type="text" class="input100 right10" id="txtMob" runat="server" />
		    <input class="btnText" type="submit" id="search" value="搜索" />
	    
        <div class="qufenLine"></div>
	</div>
    <div class="top10">
        <table class="tbList tb-h bgcw">
			<thead>
				<tr>
					<th width="3%">姓名</th>
					<th width="4%">登陆账号</th>
					<th width="15%">邮箱</th>
					<th width="4%">手机</th>
                    <th width="4%">QQ</th>
                    <th width="4%">状态</th>
                    <th width="4%">创建时间</th>
					<th width="8%">操作</th>
				</tr>
			</thead>
			<tbody class="p5">
            <asp:Repeater runat="server" ID="rptUserList" ClientIDMode="Static">
            <ItemTemplate>
                <tr id="tr_<%# Eval("ID")%>">
                    <td align="center"><%# Eval("Name")%></td>
					<td align="center"><%# Eval("LoginName")%></td>
					<td align="left"><%# Eval("Email")%></td>
                    <td align="left"><%# Eval("Mob")%></td>
					<td align="center"><%# Eval("QQ")%></td>
					<td align="center"><%# Convert.ToInt32(Eval("State"))==0?"正常":"锁定"%></td>
                    <td align="center"><%# Eval("CreateDate")%></td>
					<td align="center">
                        <a href='javascript:Reset(<%# Eval("ID") %>)'>重置密码</a>|
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
        if(confirm("您确定要删除吗？")) {
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
