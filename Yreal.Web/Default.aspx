<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Yreal.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>网站首页</title>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" runat="server">
    <div id="banner" class="wrapper">
        <div id="slides">
    <div class="slides_container" >
        <% if (Configs != null)
           {
               foreach (var config in Configs)
               {
                   if (config.Code == "Banner"&&!string.IsNullOrEmpty(config.Image))
                   {%>
                       <a href="<%=config.Url %>" title="<%=config.Text %>" ><img src="<%=config.Image %>" width="1000" height="330" alt="<%=config.Text %>"></a>
                   <%}
               }
           } %>
    </div>
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
            <%
          if (Configs != null)
          {
              foreach (var config in Configs)
              {
                  if (config.Code == "Product")
                  {%>
                    <li class="clone" style="float: left; width: 320px;">
                
                          <div class="container"><a href="<%=config.Url %>"><img src="<%=config.Image %>"></a>
                          <div class="title">
                          <% var texts = config.Text.Split('|');
                             if (texts.Length > 0)
                             {%>
                                 <a href="<%=config.Url %>"><%=texts[0] %></a>
                             <%}
                               
                               if (texts.Length > 1)
                             {%>
                                 <a href="<%=config.Url %>"><%=texts[1]%></a>
                             <%}%>
                               </div>
                              <% if (texts.Length > 2)
                             {%>
                                  <div class="intro"><%=texts[2] %></div>
                             <%}%>
                          </div>
                    </li>
                  <%}
              }
          }
           %>
            
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
      <%
          if (Configs != null)
          {
              foreach (var config in Configs)
              {
                  if (config.Code == "About")
                  {%>
                      <%=config.Text %>
                        ... <a href="<%=config.Url %>">详细介绍&gt;&gt;</a>
                  <%
                      break;
                  }
              }
          }
           %> </dd>
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
