<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Yreal.Web.Config.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../script/global.js" type="text/javascript"></script>
    <script src="../script/Extend.js" type="text/javascript"></script>
    <form id="form1">
        <input type="hidden" id="id" name="id" value="<%=Request.QueryString["id"] %>" />
        <div class="linePanel">
		        <div class="viewAction">
                    <input class="btnText" id="btnBack" value="列表" onclick="window.location='/Config/Config.aspx';" type="button">
		        </div>
                <table class="tbExtend tb-line bgcw lineHeigth30 top15 bottom15 p5">
                    <tbody>
                        <tr>
                        <td align="right" width="8%">名称：</td>
                        <td width="92%">
                            <%=config.Name %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">代码：</td>
                        <td width="92%">
                            <input type="hidden" name="txtCode" id="txtCode" value="<%=config.Code %>"/>
                            <%=config.Code %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">配图：</td>
                         <td  width="92%">
                        <img src="<%=config.Image %>" id="img1"/>
                        <iframe width="500" id="iframepage" height="50" frameborder="no" border="0" marginwidth="0" marginheight="0" src="../Content/imageUpload.aspx" onload="iFrameHeight()"></iframe>
                        <span class="blue"><% 
                                  if (config.Code == "Banner")
                                 {%>
                                     图片规格：1000px × 330px
                                 <%}
                                   
                                 if(config.Code == "Logo")
                                 {%>
                                     图片规格：210px × 86px
                                 <%}
                                   
                                 if(config.Code == "Product")
                                 {%>
                                     图片规格：110px × 110px
                                 <%}%></span>
                        <input type="button" onclick="$('#iframepage').attr('src','/Content/imageUpload.aspx');$('#img1').attr('src','');$('#txtImage').val('');" value="删除"/>
                    </td>
                    </tr>
                        <tr>
                        <td align="right" width="8%">说明：</td>
                    <td width="92%">
                        <% if (config.Code == "Product")
                           {
                               var txts= new string[3];
                               if (string.IsNullOrEmpty(config.Text))
                               {
                                   txts = config.Text.Split('|');
                               }
                               
                               %>
                                主标题：<input type="text" class="input200" id="txtTitle1" value="<%=txts[0] %>"/><br/>
                                副标题：<input type="text" class="input200" id="txtTitle2" value="<%=txts[1] %>"/><br/>
                                简介：<input type="text" class="input450" id="txtIntro" value="<%=txts[2] %>"/>
                           <%}
                           else
                           {%>
                               <textarea name="txtText" id="txtText" class="textArea" cols="200" rows="5"><%=config.Text %></textarea>
                           <%} %>
                        
                    </td>
                    </tr>
                    <tr  width="8%">
                        <td align="right">链接：</td>
                    <td  width="92%"><input name="txtUrl" class="input450" value="<%=config.Url %>" id="txtUrl"  type="text"></td>
                    </tr>
                   
                    <tr>
                        <td></td>
                        <td>
                            <input class="btnText btnYellow" value="确定" id="btnSubmit" type="button">
                            <input class="btnText btnYellow" value="重填" id="btnReset" type="button">
                        </td>
                    </tr>
                </tbody>
                </table>
        </div>
        <script type="text/javascript">
            function iFrameHeight() {
                var ifm = document.getElementById("iframepage");
                var subWeb = document.frames ? document.frames["iframepage"].document : ifm.contentDocument;
                if (ifm != null && subWeb != null) {
                    ifm.height = subWeb.body.scrollHeight;
                }
            }
            
            $("#btnSubmit").click(function () {
                var txtImage = document.getElementById('iframepage').contentDocument.getElementById("imageUrl");

                if (txtImage) {
                    txtImage = $(txtImage).attr("src");
                } else {
                    txtImage = $("#img1").attr("src");
                }

                var txtCode = $("#txtCode").val();
                var txtUrl = $("#txtUrl").val();
                var txtText = $("#txtText");

                if (!txtText || txtText.length < 1) {
                    txtText = $("#txtTitle1").val() + '|' + $("#txtTitle2").val() + '|' + $("#txtIntro").val();
                } else {
                    txtText = txtText.val();
                }

                if (txtCode=="About"&&$.isEmpty(txtText)) {
                alert("说明不能为空");
                return;
            }
                
            if ((txtCode=="Banner"||txtCode=="Logo")&&$.isEmpty(txtImage)) {
                alert("图片不能为空");
                return;
            }

            $.ajax({ type: "post",
                url: "Ajax.aspx",
                dataType: "text",
                data: {
                    "id":<%= config.ID %>,
                    "act": "edit",
                    "txtCode": txtCode,
                    "txtText": txtText,
                    "txtImage": txtImage,
                    "txtUrl": txtUrl
                },
                success: function (data) {
                    //返回提示信息 
                    var json = eval(data)[0];

                    if (json.Success == 1) {
                        alert("提交成功");
                        window.location = "Config.aspx";
                    } else {
                        alert(json.Message);
                    }
                }
            });
        });
        </script>
        </form>
</asp:Content>
