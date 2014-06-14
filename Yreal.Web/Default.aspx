<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Yreal.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>网站首页</title>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" runat="server">
    <div id="banner" class="wrapper">
        <div id="slides">
    <div class="slides_container" >
    <a href="###" title="DocCms 关注用户体验，提升服务品质！" ><img src="./res/b1.jpg" width="1000" height="330" alt="DocCms 关注用户体验，提升服务品质！"></a>
    <a href="###" title="ShlCms华丽转身，来到DocCms时代！"><img src="./res/b2.jpg" width="1000" height="330" alt="ShlCms华丽转身，来到DocCms时代！"></a>
    <a href="###" title="新功能，新视觉，新体验就在DocCms x1.0" ><img src="./res/b3.jpg" width="1000" height="330" alt="新功能，新视觉，新体验就在DocCms x1.0"></a>
    <a href="###" title="DocCms x1.0 企业建站，让您赢在起跑线~"><img src="./res/b4.jpg" width="1000" height="330" alt="DocCms x1.0 企业建站，让您赢在起跑线~"></a></div>
    <a href="###" class="prev"></a>
	<a href="###" class="next"></a>
	</div>
  <script type="text/javascript" src="./res/slides.min.jquery.js"></script> 
  <script>
      $(function () {
          $('#slides').slides({
              preload: true,
              preloadImage: 'img/loading.gif',
              play: 5000,
              pause: 25000,
              hoverPause: true
          });
      });
	</script> 
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main" class="wrapper">
  <div id="project">
    <div class="projectContainer">
      <div class="tempWrap" style="overflow:hidden; position:relative; width:960px">
          <ul class="content" style="width: 3840px; position: relative; overflow: hidden; padding: 0px; margin: 0px; left: -1859.03616px;">
            <li class="clone" style="float: left; width: 320px;">
                  <div class="container"><a href="/ContentPage.aspx?Cid=8&Code=Product&SID=9&SCode=ERP"><img src="./res/sign_0007.gif"></a>
                    <div class="title"><a href="/ContentPage.aspx?Cid=8&Code=Product&SID=9&SCode=ERP">鞋厂ERP系统</a><a href="/ContentPage.aspx?Cid=8&Code=Product&SID=9&SCode=ERP">专业-可靠-稳定-高效的企业ERP</a></div>
                    <div class="intro">结合了先进管理模式，使用最新的科技技术，为制鞋企业提供全面，先进，务实，高效的资讯服务。</div>
                  </div>
            </li>
            <li class="clone" style="float: left; width: 320px;">
              <div class="container"><a href="/ContentPage.aspx?Cid=8&Code=Product&SID=10&SCode=Web"><img src="./res/sign_0001.jpg"></a>
                <div class="title"><a href="/ContentPage.aspx?Cid=8&Code=Product&SID=10&SCode=Web">企业网站系统</a><a href="/ContentPage.aspx?Cid=8&Code=Product&SID=10&SCode=Web">轻巧高效，简单易用的企业网站系统</a></div>
                <div class="intro">操作极其便捷，一切都是基于用户体验和极其简易的操作而设计。</div>
              </div>    
            </li>
            <li class="clone" style="float: left; width: 320px;">
                <div class="container"><a href="/ContentPage.aspx?Cid=8&Code=Product&SID=11&SCode=Service"><img src="./res/sign_0008.gif"></a>
                <div class="title"><a href="/ContentPage.aspx?Cid=8&Code=Product&SID=11&SCode=Service">服务与支持</a><a href="/ContentPage.aspx?Cid=8&Code=Product&SID=11&SCode=Service">7X24小时不间断</a></div>
                <div class="intro">问题受理中心 专业精神，专业服务。</div>
                </div>
            </li>
        
          </ul>
      </div>
      <ul class="title"><li class="">1</li><li class="on">2</li></ul>
    </div>
    <script type="text/javascript">
        $(function () {
            debugger;
            jQuery("#project .projectContainer").slide({ titCell: "ul.title", mainCell: "ul.content", autoPage: true, effect: "leftLoop", autoPlay: true, scroll: 3, vis: 3, delayTime: 1000, trigger: "click" });
        });
		</script> 
  </div>
 
  <div id="aboutAndNews">
    <dl id="about" class="l">
      <dt class="title"><a href="/ContentPage.aspx?Cid=1&Code=About&SID=2&SCode=Aboutus" class="more">查看更多</a> <strong>关于我们</strong></dt>
      <dd class="content">&nbsp;&nbsp;&nbsp;&nbsp;
	Yreal.Com致力于设计开发企业网站模板，注重稻壳cms(深喉咙cms)、PHPcms等网站内容管理系统的企业网站模板设计，为广大企业及网建公司提供各类通用型企业网站模板。


	本站设计开发的企业网站模板大部分基于稻壳cms(doccms)和深喉咙cms(shlcms)以及PHPCMS系统环境下使用，本站的企业网站模板通用性强、各大浏览器兼容性好。


	本站的企业模板有如下特点：


	1、模板全部基于XHMTL+CSS进行布局，... <a href="/ContentPage.aspx?Cid=1&Code=About&SID=2&SCode=Aboutus">详细介绍&gt;&gt;</a> </dd>
    </dl>
    <dl id="news" class="r">
      <dt class="title"> <a href="/ContentPage.aspx?Code=News&CID=4" class="more">查看更多</a>
        <div> <a href="/ContentPage.aspx?Cid=4&Code=News&SID=5&SCode=Company" class="hover">公司新闻</a> <a href="/ContentPage.aspx?Cid=4&Code=News&SID=6&SCode=dongtai">行业动态</a>  </div>
      </dt>
      <dd class="content">
        <ul class="arcList" style="display:block;">
            <% if (CompanyContents != null)
               {
                   foreach (var content in CompanyContents)
                   {%>
                        <li><span class="date">[<%=(Convert.ToDateTime(content.CreateDate)).ToString("yyyy-MM-dd") %>]</span><a href="/ContentPage.aspx?Code=News&CID=4&pid=<%=content.ID %>"><%=content.Title %></a></li>  
                   <%}
               } %>
          
        </ul>
        <ul class="arcList">
          <% if (dtContents != null)
               {
                   foreach (var content in dtContents)
                   {%>
                        <li><span class="date">[<%=(Convert.ToDateTime(content.CreateDate)).ToString("yyyy-MM-dd") %>]</span><a href="/ContentPage.aspx?Code=News&CID=4&pid=<%=content.ID %>"><%=content.Title %></a></li>  
                   <%}
               } %>
        </ul>
      </dd>
      <script type="text/javascript">
          $(function () {
              $('#news dt div a').hover(function () {
                  var i = $('#news dt div a').index(this);
                  $('#news dt div a').removeClass('hover');
                  $('#news dd ul').css('display', 'none');
                  $('#news dt div a').eq(i).addClass('hover');
                  $('#news dd ul').eq(i).css('display', 'block');
              }, function () { });
          });
			</script>
    </dl>
  </div>
</div>
</asp:Content>
