<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Yreal.Web.Content.Add" %>
<%@ Register Src="../Controls/ImageUploader.ascx" TagName="imgUp" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    新增内容
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/UE/themes/default/css/umeditor.css" type="text/css" rel="stylesheet">
   <script type="text/javascript" src="/UE/third-party/jquery.min10.js"></script>
 
    <script src="../script/Extend.js" type="text/javascript"></script>
    <script src="../script/jquery.form.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="/UE/umeditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/UE/umeditor.min.js"></script>
    <script type="text/javascript" src="/UE/lang/zh-cn/zh-cn.js"></script>
    <div class="linePanel">
		    <div class="viewAction">
                <input class="btnText" id="btnBack" href="/Add.aspx" value="列表" onclick="window.location='/Content/ContentMger.aspx';" type="button">
		    </div>
            <table class="tbExtend tb-line bgcw lineHeigth30 top15 bottom15 p5">
                <tbody>
                    <tr>
                    <td align="right" width="8%">标题：</td>
                    <td width="92%"><input name="txtTitle" class="input450" id="txtTitle" maxlength="30" type="text"></td>
                </tr>
                <tr>
                    <td align="right" width="8%">栏目：</td>
                    <td width="92%">
                        <select id="ddlChannel" class="input150 channel">
                            <option value="0">==请选择==</option>
                            <% 
                                foreach (var channel in channels)
                               {
                                    %>
                                    <option value="<%=channel.ID %>" id="<%=channel.ID %>" contenttype="<%=channel.ContentType %>" class="channel" type="<%=channel.Type %>"><%=channel.Name%></option>
                               <%} %>
                        </select>
                    </td>
                </tr>
                <tr  width="8%">
                    <td align="right">封面图片：</td>
                    <td  width="92%">
                        <uc1:imgUp ID="img_1" runat="server" Count="1" GG_X="1000" GG_Y="290" />
                    </td>
                </tr>
                <tr>
                    <td align="right">内容：</td>
                <td>
                        <!-- 加载编辑器的容器 -->
                    <script id="container" name="content" type="text/plain" style="width:900px;height:240px;">
                    </script>
                </td>
                </tr>
                <tr>
                    <td align="right" width="8%">推荐：</td>
                    <td width="92%">
                        <select name="recommend" id="recommend">
                            <option value="0">==请选择==</option>
                            <option value="d">置&nbsp;&nbsp;顶</option>
                            <option value="h">最&nbsp;&nbsp;热</option>
                            <option value="g">滚&nbsp;&nbsp;动</option>
                            <option value="x">最&nbsp;&nbsp;新</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">备注：</td>
                <td><input name="txtRemark" class="input320" id="txtRemark" name="txtRemark" maxlength="15" type="text"></td>
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
   function isEmpty(str1) {
        if (str1 && str1.length > 0) {
            return false;
        } else {
            return true;
        }
    }

    $(function () {
        var ue = UM.getEditor('container').setContent("");

        $("#btnSubmit").click(function () {
            var image = $("input[name=hifShowImage]").val();

            var title = $("#txtTitle").val();
            var channel = $("#ddlChannel").val();
            var content = UM.getEditor('container').getContent();

            if (isEmpty(title)) {
                alert("标题不能为空");
                return;
            }

            if (isEmpty(channel) || channel == "0") {
                alert("请选择栏目");
                return;
            }

            if (isEmpty(content)) {
                alert("内容不能为空");
                return;
            }

            $.ajax({ type: "post",
                url: "Ajax.aspx",
                dataType: "text",
                data: {
                    "act": "add",
                    "title": title,
                    "channel": channel,
                    "content": escape(content),
                    "recommend": $("#recommend").val(),
                    "image": image,
                    "remark": $("#txtRemark").val()
                },
                success: function (data) {
                    //返回提示信息 
                    var json = eval(data)[0];

                    if (json.Success == 1) {
                        alert("提交成功");
                        window.location = "ContentMger.aspx";
                    } else {
                        alert(json.Message);
                    }
                }
            });
        });

        $(".channel").change(function () {
            if ($(this).children('option:selected').attr("type") == "2") {
                alert("不可在此分类下创建内容！");
                $(this).val("0");
            }

            if ($(this).children('option:selected').attr("contentType") == "1") {

                $("#iframepage").removeAttr("src");
            } else {
                $("#iframepage").attr("src", 'imageUpload.aspx');
            }
        });
    });

</script>

</asp:Content>
