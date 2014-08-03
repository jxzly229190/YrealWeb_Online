<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="GlobeConfig.aspx.cs" Inherits="Yreal.Web.Config.GlobeConfig" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    网站配置管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="Form1" action="" runat="server">
    <div class="linePanel">
    <div class="top10">
        <table class="tbList tb-h bgcw">
			<thead>
				<tr>
					<th width="4%">代码</th>
					<th width="5%">描述</th>
                    <th width="8%">内容</th>
                    <th width="4%">修改时间</th>
					<th width="4%">操作</th>
				</tr>
			</thead>
			<tbody class="p5">
            <asp:Repeater runat="server" ID="rptList" ClientIDMode="Static">
            <ItemTemplate>
                <tr id="tr_<%# Eval("ID")%>">
					<td align="center"><%# Eval("Code")%></td>
                    <td align="center"><%# Eval("Description")%></td>
					<td align="left"><%# Eval("Text")%></td>
                    <td align="left"><%# Eval("CreateDate")%></td>
					<td align="center">
                        <a href='globeUpdate.aspx?id=<%# Eval("ID") %>'>编辑</a>
                       <%-- <a href='javascript:change(<%# Eval("ID") %>,<%# Eval("State") %>);'><%#Eval("State").ToString()=="0"?"停用":"启用"%></a>--%>
                    </td>
				</tr>
            </ItemTemplate>
            </asp:Repeater>
			</tbody>
		</table>
	</div>
</div>
</form>
<script type="text/javascript"></script>
</asp:Content>
