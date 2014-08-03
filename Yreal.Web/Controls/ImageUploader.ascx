<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUploader.ascx.cs" Inherits="Yreal.Web.Controls.ImageUploader" %>
<script src="../script/jquery.min.js" type="text/javascript"></script>
<script src="../script/jquery.form.js" type="text/javascript"></script>
<script src="../script/jquery.uploadify.min.js" type="text/javascript"></script>
<link href="../css/admin/Cloud.base.css" rel="stylesheet" type="text/css" />
<link href="../css/admin/Cloud.comm.css" rel="stylesheet" type="text/css" />
<link href="../css/admin/Cloud.control.css" rel="stylesheet" type="text/css" />
<link href="../css/admin/comm.struct.css" rel="stylesheet" type="text/css" />
<dl class="pl_pingfen mb10">
    <input id="imgCount" type="hidden" value="<%=Count %>"/>
    <dt class="fs14 fwb mb15"><span class="red_weight">*</span> 图片 </dt>
    <dd>
        <div id="imageList"> <% if (!string.IsNullOrEmpty(ImgUrls))
                                {
                                    var arrImages = ImgUrls.Split(';');
                                    foreach (var arrImage in arrImages)
                                    { %>
                                        <div style=" width:50px; height:70px; padding:1px; text-align:center; border:1px solid #ccc; margin-right:10px; margin-bottom:10px; float:left;">
                                            <a href="javascript:;" onclick="DelSelectedPro(this);" style="display:block; height:20px; line-height:20px;  background-color:#ddd;" image="<%=arrImage %>">删除</a>
                                            <img src="<%=arrImage %>" height="50" width="50"><input name="hifShowImage" value="<%=arrImage %>" type="hidden">
                                            <input name="txtImageID" value="0" type="hidden">
                                        </div>
                                    <%}
                                 } %>  </div>
        <div class="clear"></div>
        <div id="uploader"><input name="ShowImage" type="file" class="input200" id="ShowImage" /></div>
        <div id="pic_queue"></div>
        <div class="clear"></div>
        <span class="blue">规格：<%=GG_X%>px X <%=GG_Y%>px</span><span class="cf04" style="display:block;">最多能上传<%=Count %>张图片，每张图片不超过1M，支持的图片格式为jpg，jpeg，bmp，png，gif</span>
    </dd>
</dl>
    
<script type="text/javascript">
    if ($("#imageList div").length < <%=Count %>) {
        $("#uploader").show();
    } else {
        $("#uploader").hide();
    }

    function DelSelectedPro(obj) {
        var $this = $(obj);
        var imagename = $(obj).attr('image');
        var tr = $this.parent();

        if (imagename) {
            $.post("/Controls/DelImage.ashx", { "image": imagename });
        }

        tr.remove();
        if ($("#imageList div").length < <%=Count %>) {
            $("#uploader").show();
        }
    }

    $('#ShowImage').uploadify({
        'swf': '/Controls/uploadify.swf',
        'uploader': '/Controls/uploadxx.aspx',
        'cancelImage': '/Controls/uploadify-cancel.png',
        'fileTypeExts': '*.jpg;*.gif;*.jpeg;*.bmp;*.png;*.swf',
        'fileTypeDesc': 'Image Files (.JPG, .GIF, .PNG, .SWF)',
        'buttonImage': '/Controls/uploadimg.jpg',
        'simUploadLimit': <%=Count %>,
        'fileSizeLimit': '1MB',
        'width': '91',
        'height': '30',
        'multi': false,
        'auto': true,
        'queueID': 'pic_queue',
        'onUploadSuccess': function (event, response, status) {
            var json = eval(response)[0];
            var str = "<div style=' width:50px; height:70px; padding:1px; text-align:center; border:1px solid #ccc; margin-right:10px; margin-bottom:10px; float:left;'><a href='javascript:;' onclick='DelSelectedPro(this);' style='display:block; height:20px; line-height:20px;  background-color:#ddd;' image='<%=Yreal.Web.common.Common.UploadImagePath %>" + json.sName + "'>删除</a><img   src='/upload/image/" + json.sName + "'  width='50' height='50' /><input type='hidden'  name='hifShowImage' value='" + json.sName + "' /><input  name='txtImageID' type='hidden' value='0' /></div>";
            $("#imageList").append(str);
            if ($("#imageList div").length >= <%=Count %>) {
                $("#uploader").hide();
            }
        },
        'postData': { 'folder': 'image' }
    });
</script>
