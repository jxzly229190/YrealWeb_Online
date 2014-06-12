<%@ Page Title="" Language="C#" MasterPageFile="~/MainContent.master" AutoEventWireup="true" CodeBehind="ContentPage.aspx.cs" Inherits="Yreal.Web.ContentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>内容页面</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerContent" runat="server">
    <img width="1000" height="290" src="/images/banner_1.jpg"/>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="RightContent" ID="fasdf">
    
    <% if (Contents != null && Contents.Count ==1)
       {%>
            <div class="arcContent"><p>
                购买本站的企业网站模板或者在本站定制企业网站模板后，享受如下免费售后服务：
                </p>
                <p>
	                1、模板的上传安装，CMS系统的安装调试。
                </p>
                <p>
	                2、域名解析、空间域名绑定。
                </p>
                <p>
	                3、模板使用，后台操作问题咨询服务。
                </p>
                <p>
	                4、网站栏目建立、网站系统架构。
                </p>
                <p>
	                5、定制模板提供配套的数据库。
                </p>
                <p>
	                6、1次免费网站搬家服务。
                </p>
                <p>
	                购买本站的企业网站模板或者在本站定制企业网站模板后，享受如下收费售后服务：
                </p>
                <p>
	                1、域名空间套餐（com国际域名1个+200M香港免备案空间或1G美国免备案空间+50M MYSQL数据库），200元。
                </p>
                <p>
	                2、banner焦点图广告图设计，50元/张。
                </p>
                <p>
	                3、二次购买其他模板享受八折优惠。
                </p></div>
       <% }
       else if (Contents != null && Contents.Count >1)
       {
           %><div class="clearfix">
           <ul class="arclist2 clearfix"><%
           foreach (var content in Contents)
           { %>
                <li class="">
                  <div class="title"><span class="date"><%=content.ModifyDate %></span> <a href="###"><%=content.Title %></a></div>
                  <p>如果你经常网上冲浪，这样参差不齐的多栏布局，是不是很眼熟啊？<a href="/industrynews/n16.html">详细&gt;</a>
                    </p>
               </li>
            <%}
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
          
        <%} %>
		<div class="arcContent"><p>
	
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentTitle" ID="Content5">
    业务范围
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MenuItem" ID="Content3">
    业务范围
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="SubMenu" ID="Content4">
    <% foreach (var subChannel in subChannels)
       {%>
            <li><a href="/ContentPage.aspx?Cid=<%=subChannel.ParentId %>&Code=<%=this.Request.QueryString["Code"] %>&SID=<%=subChannel.ID %>&SCode=<%=subChannel.Code %>"><%=subChannel.Name %></a></li>    
      <% } %> 
</asp:Content>
