<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Yreal.Web.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>测试</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" runat="server">
    <div id="nbanner" class="wrapper">
        <img width="1000" height="290" src="/images/banner_1.jpg"/>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!---------------右内容区域---------------------->
    <div id="mainContent">
    <dl id="cateContent">
      <dt class="cateTitle">
        <div id="position">当前位置：<a href="http://v4.950d.com/">首页</a> &gt; <a href="http://v4.950d.com/yewu/">业务范围</a></div>
        <strong>业务范围</strong></dt>
      <dd class="cateContentHead"></dd>
      <dd class="cateContent clearfix">
        
		<h1 class="arcTitle"></h1>
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
	      </dd>
      <dd class="cateContentFooter"></dd>
    </dl>
  </div>
  
  
  <!---------------子菜单---------------------->
    <div style="position: static; top: auto; left: auto; z-index: auto;" id="sidebar">
    <dl class="mod">
      <dt>业务范围</dt>
      <dd>
        <ul>
          <li><a href="http://v4.950d.com/webdesign/">网站建设</a></li><li><a href="http://v4.950d.com/DomainHosting/">域名主机</a></li><li><a href="http://v4.950d.com/SEO/">搜索优化</a></li><li><a href="http://v4.950d.com/Userinterface/">软件开发</a></li><li><a href="http://v4.950d.com/CloudMail/">企业邮局</a></li><li><a href="http://v4.950d.com/Calls/">400电话</a></li>        </ul>
      </dd>
      <dd class="footer"></dd>
    </dl>
  </div>
  <script type="text/javascript">
      var navElm = '#sidebar';
      var _defautlTop = $(navElm).offset().top;
      var _position = $(navElm).css('position');
      var _top = $(navElm).css('top');
      var _left = $(navElm).css('left');
      var _zIndex = $(navElm).css('z-index');
      $(window).scroll(function () {
          var _defautlLeft = $(navElm).offset().left;
          if ($(this).scrollTop() > _defautlTop) {
              if ($.browser.msie && $.browser.version == "6.0") {
                  $(navElm).css({ 'position': 'absolute', 'top': eval(document.documentElement.scrollTop), 'left': _defautlLeft, 'z-index': 99999 });
                  //$("html,body").css({'background-image':'url(other/.com/about:blank)','background-attachment':'fixed'});
              } else {
                  $(navElm).css({ 'position': 'fixed', 'top': 0, 'left': _defautlLeft, 'z-index': 1 });
              }
          } else {
              $(navElm).css({ 'position': _position, 'top': _top, 'left': _left, 'z-index': _zIndex });
          }
      });
	</script>
  <div class="c"></div>
</asp:Content>
