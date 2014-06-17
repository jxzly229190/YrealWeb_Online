<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="Yreal.Web.Config.Config" %>
<%@ Import Namespace="Common" %>
<%@ Register TagPrefix="asp" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.0.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    首焦广告
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="Form1" action="" runat="server">
    <div class="linePanel">
    <div class="top10">
        <table class="tbList tb-h bgcw">
			<thead>
				<tr>
					<th width="5%">名称</th>
					<th width="4%">代码</th>
                    <th width="10%">封面/文字</th>
                    <th width="8%">URL</th>
                    <th width="8%">状态</th>
                    <th width="4%">创建时间</th>
					<th width="4%">操作</th>
				</tr>
			</thead>
			<tbody class="p5">
            <asp:Repeater runat="server" ID="rptList" ClientIDMode="Static">
            <ItemTemplate>
                <tr id="tr_<%# Eval("ID")%>">
                    <td align="left"><%# Eval("Name")%></td>
					<td align="left"><%# Eval("Code")%></td>
					<td align="left"><%# !string.IsNullOrEmpty(Convert.ToString(Eval("image")))
                                 ? "<img width='10%' height='10%' src='" + Eval("image") + "' /><span>"+PubFunc.RemoveHtml(HttpUtility.UrlDecode(Eval("Text").ToString())).Replace("%","")+"</span>"
                                                                          : "<span>" + PubFunc.RemoveHtml(HttpUtility.UrlDecode(Eval("Text").ToString())).Replace("%", "") + "</span>"%></td>
                    <td align="center"><%# Eval("Url")%></td>
                    <td align="center"><%# Eval("State").ToString()=="0"?"正常":"停用"%></td>
                    <td align="center"><%# Eval("CreateDate")%></td>
					<td align="center">
                        <a href='Update.aspx?id=<%# Eval("ID") %>'>编辑</a>
                        <a href='javascript:change(<%# Eval("ID") %>,<%# Eval("State") %>);'><%#Eval("State").ToString()=="0"?"停用":"启用"%></a>
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
    function change(id,state) {
        if (confirm("您确定要切换状态吗？")) {
            $.ajax({
                type: 'POST',
                url: 'Ajax.aspx',
                data: { id: id, act: "stop",state:state },
                success: function (data) {
                    var json = eval(data)[0];
                    if (json.Success == 1) {
                        alert("操作完成！");
                        location.reload();
                    } else {
                        alert(json.Message);
                    }
                },
                error: function () {
                    alert("操作失败");
                }
            });
        }
    }
</script>
</asp:Content>
