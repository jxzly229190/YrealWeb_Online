<%@ Page Title="" Language="C#" MasterPageFile="~/MainContent.master" AutoEventWireup="true" CodeBehind="ContentPage.aspx.cs" Inherits="Yreal.Web.ContentPage" %>
<%@ Import Namespace="BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>内容页面</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceBreakNav">
    <a href="###"><%=channel.Name %></a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerContent" runat="server">
    <img width="1000" height="290" src="<%=!string.IsNullOrEmpty(channel.ImageUrl)?channel.ImageUrl:"/images/banner_1.jpg" %>"/>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="RightContent" ID="fasdf">
    
    <% if (Contents != null && Contents.Count ==1)
       {%>
            <h1 class="arcTitle"><%=Contents[0].Title %></h1>
            <div class="arcContent">
            <%=HttpUtility.UrlDecode(Contents[0].ContentText) %>
                </div>
       <% }
       else if (Contents != null && Contents.Count > 1)
       {
       %><div class="clearfix">
           <h2 class="listtt clearfix"><%= Contents[0].ChannelName %></h2>
           <ul class="arclist2 clearfix"><%
                foreach (var content in Contents)
                { %>
                <li class="">
                  <div class="title"><span class="date"><%= content.ModifyDate %></span> <a href="<%= Request.Url %>&Pid=<%= content.ID %>"><%= content.Title %></a></div>
                  <p><%= Common.PubFunc.RemoveHtml(HttpUtility.UrlDecode(content.ContentText)).Replace("%", "") %>...<a href="<%= Request.Url %>&Pid=<%= content.ID %>">详细&gt;</a>
                    </p>
               </li>
            <% }
            %>
           </ul>
           <div id="articeBottom"></div>
        <div/>
  <script type="text/javascript">
      $(function () {
          $('.arclist2 li').hover(function () { $(this).addClass('hover') }, function () { $(this).removeClass('hover') });
      });
</script>
  <div class="clear"></div>
  <div id="articeBottom">
      </div>
</div>
          
        <% }
       else
       {
           %>
            <div class="arcContent">
            <P>这里什么也咩有</P>
                </div>
       <%
       } %>
		<div class="articeBottom"></div>
	
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentTitle" ID="Content5">
    <%=channel!=null?channel.Name:""%>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MenuItem" ID="Content3">
    <%=channel!=null?channel.Name:""%>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="SubMenu" ID="Content4">
    <% foreach (var subChannel in subChannels)
       {%>
            <li><a href="/ContentPage.aspx?Cid=<%=subChannel.ParentId %>&Code=<%=this.Request.QueryString["Code"] %>&SID=<%=subChannel.ID %>&SCode=<%=subChannel.Code %>"><%=subChannel.Name %></a></li>    
      <% } %> 
</asp:Content>
