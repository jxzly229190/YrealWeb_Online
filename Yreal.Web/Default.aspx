﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Yreal.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>网站首页</title>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" runat="server">
    <div id="banner" class="wrapper">
        <div id="slides">
    <div class="slides_container" >
<a href="http://www.950d.com/" title="DocCms 关注用户体验，提升服务品质！" target="_blank" ><img src="./res/b1.jpg" width="1000" height="330" alt="DocCms 关注用户体验，提升服务品质！"></a>
<a href="http://www.950d.com/" title="ShlCms华丽转身，来到DocCms时代！" target="_blank" ><img src="./res/b2.jpg" width="1000" height="330" alt="ShlCms华丽转身，来到DocCms时代！"></a>
<a href="http://www.950d.com/" title="新功能，新视觉，新体验就在DocCms x1.0" target="_blank" ><img src="./res/b3.jpg" width="1000" height="330" alt="新功能，新视觉，新体验就在DocCms x1.0"></a>
<a href="http://www.950d.com/" title="DocCms x1.0 企业建站，让您赢在起跑线~" target="_blank" ><img src="./res/b4.jpg" width="1000" height="330" alt="DocCms x1.0 企业建站，让您赢在起跑线~"></a></div>
    <a href="http://v4.950d.com/#" class="prev"></a>
	<a href="http://v4.950d.com/#" class="next"></a>
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
      <div class="tempWrap" style="overflow:hidden; position:relative; width:960px"><ul class="content" style="width: 3840px; position: relative; overflow: hidden; padding: 0px; margin: 0px; left: -1859.03616px;"><li class="clone" style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/Userinterface/"><img src="./res/sign_0007.gif"></a>
    <div class="title"><a href="http://v4.950d.com/Userinterface/">软件开发 Userinterface</a><a href="http://v4.950d.com/Userinterface/">专业-可靠-稳定的互联网服务</a></div>
    <div class="intro">基于Windows、Mac OS、Linux桌面操作系统的软件、界面设计解决方案</div>
  </div>
</li><li class="clone" style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/CloudMail/"><img src="./res/sign_0009.gif"></a>
    <div class="title"><a href="http://v4.950d.com/CloudMail/">企业邮局 CloudMail</a><a href="http://v4.950d.com/CloudMail/">云邮第二代企业邮局</a></div>
    <div class="intro">集成邮件、短信、传真、语音、视 频、即时通信等多种通信方式。</div>
  </div>
</li><li class="clone" style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/Calls/"><img src="./res/sign_0008.gif"></a>
    <div class="title"><a href="http://v4.950d.com/Calls/">400电话 Calls</a><a href="http://v4.950d.com/Calls/">洛阳渠道受理中心</a></div>
    <div class="intro">业务受理中心 专业精神，专业服务</div>
  </div>
</li>
        
<li style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/webdesign/"><img src="./res/sign_0001.jpg"></a>
    <div class="title"><a href="http://v4.950d.com/webdesign/">网站建设 webdesign</a><a href="http://v4.950d.com/webdesign/">精品细腻的互联网品牌建设</a></div>
    <div class="intro">结合您所属行业的类型以及产品的特点设计出商业化、国际化的专业网站</div>
  </div>
</li>

<li style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/DomainHosting/"><img src="./res/sign_0002.jpg"></a>
    <div class="title"><a href="http://v4.950d.com/DomainHosting/">域名主机 DomainHosting</a><a href="http://v4.950d.com/DomainHosting/">专业-可靠-稳定的互联网服务</a></div>
    <div class="intro">金线机房高速稳定，专家级的安防保证；顶级规格网络环境，千兆流畅网速条件</div>
  </div>
</li>

<li style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/SEO/"><img src="./res/sign_0003.jpg"></a>
    <div class="title"><a href="http://v4.950d.com/SEO/">搜索优化 SEO</a><a href="http://v4.950d.com/SEO/">引领时代网络潮流</a></div>
    <div class="intro">提供优秀的SEO服务，让网站在行业内占据领先地位，从而获得品牌收益</div>
  </div>
</li>

<li style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/Userinterface/"><img src="./res/sign_0007.gif"></a>
    <div class="title"><a href="http://v4.950d.com/Userinterface/">软件开发 Userinterface</a><a href="http://v4.950d.com/Userinterface/">专业-可靠-稳定的互联网服务</a></div>
    <div class="intro">基于Windows、Mac OS、Linux桌面操作系统的软件、界面设计解决方案</div>
  </div>
</li>

<li style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/CloudMail/"><img src="./res/sign_0009.gif"></a>
    <div class="title"><a href="http://v4.950d.com/CloudMail/">企业邮局 CloudMail</a><a href="http://v4.950d.com/CloudMail/">云邮第二代企业邮局</a></div>
    <div class="intro">集成邮件、短信、传真、语音、视 频、即时通信等多种通信方式。</div>
  </div>
</li>

<li style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/Calls/"><img src="./res/sign_0008.gif"></a>
    <div class="title"><a href="http://v4.950d.com/Calls/">400电话 Calls</a><a href="http://v4.950d.com/Calls/">洛阳渠道受理中心</a></div>
    <div class="intro">业务受理中心 专业精神，专业服务</div>
  </div>
</li>
      <li class="clone" style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/webdesign/"><img src="./res/sign_0001.jpg"></a>
    <div class="title"><a href="http://v4.950d.com/webdesign/">网站建设 webdesign</a><a href="http://v4.950d.com/webdesign/">精品细腻的互联网品牌建设</a></div>
    <div class="intro">结合您所属行业的类型以及产品的特点设计出商业化、国际化的专业网站</div>
  </div>
</li><li class="clone" style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/DomainHosting/"><img src="./res/sign_0002.jpg"></a>
    <div class="title"><a href="http://v4.950d.com/DomainHosting/">域名主机 DomainHosting</a><a href="http://v4.950d.com/DomainHosting/">专业-可靠-稳定的互联网服务</a></div>
    <div class="intro">金线机房高速稳定，专家级的安防保证；顶级规格网络环境，千兆流畅网速条件</div>
  </div>
</li><li class="clone" style="float: left; width: 320px;">
  <div class="container"><a href="http://v4.950d.com/SEO/"><img src="./res/sign_0003.jpg"></a>
    <div class="title"><a href="http://v4.950d.com/SEO/">搜索优化 SEO</a><a href="http://v4.950d.com/SEO/">引领时代网络潮流</a></div>
    <div class="intro">提供优秀的SEO服务，让网站在行业内占据领先地位，从而获得品牌收益</div>
  </div>
</li></ul></div>
      <ul class="title"><li class="">1</li><li class="on">2</li></ul>
    </div>
    <script type="text/javascript">
        $(function () {
            debugger;
            jQuery("#project .projectContainer").slide({ titCell: "ul.title", mainCell: "ul.content", autoPage: true, effect: "leftLoop", autoPlay: true, scroll: 5, vis: 3, delayTime: 500, trigger: "click" });
        });
		</script> 
  </div>
  <dl id="case">
    <dt><a href="http://v4.950d.com/products/" class="more">查看全部</a> <strong>成功案例 / CASE</strong></dt>
    <dd>
      <div class="container">
        <ul class="imgList2">
          <li> <a class="thumb" href="http://v4.950d.com/imove/product_5.html" title="苹果概念车iMove two"><img src="./res/s_20121026095155738.jpeg" alt="苹果概念车iMove two" width="223" height="143"></a>
  <div><a href="http://v4.950d.com/imove/product_5.html">苹果概念车iMove two</a><span>点击：189次</span></div>
</li>
<li> <a class="thumb" href="http://v4.950d.com/imove/product_4.html" title="苹果概念车iMove one"><img src="./res/s_20121026095432518.jpeg" alt="苹果概念车iMove one" width="223" height="143"></a>
  <div><a href="http://v4.950d.com/imove/product_4.html">苹果概念车iMove one</a><span>点击：222次</span></div>
</li>
<li> <a class="thumb" href="http://v4.950d.com/doccms/product_3.html" title="DocCms X 1.0(稻壳)企业建站系统"><img src="./res/s_20121031175054739.jpg" alt="DocCms X 1.0(稻壳)企业建站系统" width="223" height="143"></a>
  <div><a href="http://v4.950d.com/doccms/product_3.html">DocCms X 1.0(稻壳)企业建站系统</a><span>点击：90次</span></div>
</li>
<li> <a class="thumb" href="http://v4.950d.com/shlcms/product_2.html" title="Shlcms 4.2 (深喉咙)网站生成系统"><img src="./res/s_201210311753054.jpg" alt="Shlcms 4.2 (深喉咙)网站生成系统" width="223" height="143"></a>
  <div><a href="http://v4.950d.com/shlcms/product_2.html">Shlcms 4.2 (深喉咙)网站生成系统</a><span>点击：64次</span></div>
</li>
        </ul>
      </div>
    </dd>
  </dl>
  <div id="aboutAndNews">
    <dl id="about" class="l">
      <dt class="title"><a href="http://v4.950d.com/aboutus/" class="more">查看更多</a> <strong>关于我们</strong></dt>
      <dd class="content">&nbsp;&nbsp;&nbsp;&nbsp;
	本站[企业网站模板网]，永久域名950d.com，致力于设计开发企业网站模板，注重稻壳cms(深喉咙cms)、PHPcms等网站内容管理系统的企业网站模板设计，为广大企业及网建公司提供各类通用型企业网站模板。


	本站设计开发的企业网站模板大部分基于稻壳cms(doccms)和深喉咙cms(shlcms)以及PHPCMS系统环境下使用，本站的企业网站模板通用性强、各大浏览器兼容性好。


	本站的企业模板有如下特点：


	1、模板全部基于XHMTL+CSS进行布局，... <a href="http://v4.950d.com/aboutus/">详细介绍&gt;&gt;</a> </dd>
    </dl>
    <dl id="news" class="r">
      <dt class="title"> <a href="http://v4.950d.com/news/" class="more">查看更多</a>
        <div> <a href="http://v4.950d.com/companynews/" class="hover">公司新闻</a> <a href="http://v4.950d.com/industrynews/">行业新闻</a> <a href="http://v4.950d.com/design/">设计理念</a> </div>
      </dt>
      <dd class="content">
        <ul class="arcList" style="display:block;">
          <li><span class="date">[2012-10-25]</span><a href="http://v4.950d.com/companynews/n6.html">DocCms 官方微博正式开放，欢迎广大用户关注！</a></li>
<li><span class="date">[2012-10-25]</span><a href="http://v4.950d.com/companynews/n5.html">DocCms官方网站与官方论坛将于2012.11.01日正式推出！</a></li>
<li><span class="date">[2012-10-08]</span><a href="http://v4.950d.com/companynews/n4.html">DocCms X + 稻壳网 官方社区版块确定并推出测试版</a></li>
<li><span class="date">[2012-10-08]</span><a href="http://v4.950d.com/companynews/n3.html">DocCms X1.0 开发功能目标敲定</a></li>
<li><span class="date">[2012-10-08]</span><a href="http://v4.950d.com/companynews/n2.html">原ShlCms团队更名为DocCms开发团队[中文名：稻壳Cms]</a></li>
<li><span class="date">[2012-10-08]</span><a href="http://v4.950d.com/companynews/n1.html">原ShlCms团队[中文名：深喉咙Cms]重建</a></li>
        </ul>
        <ul class="arcList">
          <li><span class="date">[2012-10-25]</span><a href="http://v4.950d.com/industrynews/n16.html">网页瀑布流布局浅析-前端工程师必学</a></li>
<li><span class="date">[2012-10-25]</span><a href="http://v4.950d.com/industrynews/n15.html">浅谈网页设计中的色彩理论</a></li>
<li><span class="date">[2012-10-25]</span><a href="http://v4.950d.com/industrynews/n14.html">体验用户UI、UE，谈如何提高交互设计专业能力 </a></li>
<li><span class="date">[2012-10-25]</span><a href="http://v4.950d.com/industrynews/n13.html">企业对外服务窗口，稻壳网看新浪企业微博为人民和企业服务</a></li>
<li><span class="date">[2012-10-25]</span><a href="http://v4.950d.com/industrynews/n11.html">如何提高网页速度优化 提高用户体验</a></li>
<li><span class="date">[2012-10-25]</span><a href="http://v4.950d.com/industrynews/n10.html">稻壳网谈网站策划重点和行业知识梳理</a></li>
        </ul>
        <ul class="arcList">
          <li><span class="date">[2013-12-11]</span><a href="http://v4.950d.com/design/n22.html">职工退休年龄已不适应社会发展的需求</a></li>
<li><span class="date">[2013-12-11]</span><a href="http://v4.950d.com/design/n21.html">普通住房标准另类，北京蜗居变身豪宅</a></li>
<li><span class="date">[2013-12-11]</span><a href="http://v4.950d.com/design/n20.html">地方债纳入干部政绩考核 范剑平微博直言问题严重需规范</a></li>
<li><span class="date">[2013-12-11]</span><a href="http://v4.950d.com/design/n19.html">《梦想＋》启动，填写梦想赢iphone5S！</a></li>
<li><span class="date">[2013-12-11]</span><a href="http://v4.950d.com/design/n18.html">“贩卖”空气：雾霾侵袭背后的生意</a></li>
<li><span class="date">[2013-12-11]</span><a href="http://v4.950d.com/design/n17.html">人社部：延迟退休将一年推迟几个月</a></li>
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
  <div id="caseSpecial">    
  	<div id="caseSpecialTail"></div>
    <div class="btn"> <a href="http://v4.950d.com/products/">我们的成功案例</a> <a href="http://v4.950d.com/aboutus/">为什么选择我们</a> <a href="http://v4.950d.com/yewu/">网站免费诊断</a> </div>
    <div class="qq"> <a href="http://v4.950d.com/_blank" title="点击QQ咨询">在线QQ</a> <a href="http://v4.950d.com/_blank" title="免费QQ咨询">在线QQ</a> <a href="http://v4.950d.com/_blank" title="在线QQ客服">在线QQ</a> </div>
    <ul class="specialList">
      <li><a href="http://www.950d.com/" rel="nofllow" target="_blank" title="测试占位"><img src="./res/20121027093534554.jpg" alt="" width="90" height="60"></a></li><li><a href="http://www.950d.com/" rel="nofllow" target="_blank" title="ShlCms官方论坛"><img src="./res/20121027093534554.jpg" alt="" width="90" height="60"></a></li><li><a href="http://www.950d.com/" rel="nofllow" target="_blank" title="ShlCms网站系统"><img src="./res/2012102709345595.jpg" alt="" width="90" height="60"></a></li><li><a href="http://www.950d.com/" rel="nofllow" target="_blank" title="稻壳网官方论坛"><img src="./res/20121027093303513.jpg" alt="" width="90" height="60"></a></li><li><a href="http://www.950d.com/" rel="nofllow" target="_blank" title="路之易"><img src="./res/20121027093126573.jpg" alt="" width="90" height="60"></a></li><li><a href="http://www.950d.com/" rel="nofllow" target="_blank" title="DocCms X 1.0"><img src="./res/20121027093046643.jpg" alt="" width="90" height="60"></a></li>    </ul>
  </div>
</div>
</asp:Content>
