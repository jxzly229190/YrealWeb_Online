<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Attribute.aspx.cs" Inherits="Yreal.Web.Attribute.Attribute" %>
<%@ Import Namespace="System.IO" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>

<%@ Register src="../common/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    栏目属性
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <CuteWebUI:Uploader id="Uploader1" runat="server"  InsertText="选择" OnFileUploaded="Uploader_FileUploaded"/>
    <asp:Image runat="server" ID="img1"  Width="20%" Height="20%" Visible="False"/>
    <asp:Button runat="server" ID="cancelBtn" Text="取消" OnClick="OnCancelUpload"/>
    <asp:HiddenField runat="server" ID="imgPath"/>
    </form>
    
<script runat="server">
    void Uploader_FileUploaded(object sender, UploaderEventArgs args)
    {
        if (string.IsNullOrEmpty(this.UploadFolder))
        {
            this.UploadFolder = "Upload";
        }

         this.UploadFolder = "/" + this.UploadFolder + "/" + DateTime.Today.ToString("yyyy-MM-dd") + "/";

         if (!Directory.Exists(this.MapPath(this.UploadFolder)))
        {
            Directory.CreateDirectory(this.MapPath(this.UploadFolder));
        }

        args.CopyTo(UploadFolder + args.FileName);
        img1.ImageUrl = this.UploadFolder + args.FileName;
        img1.Visible = true;
        Uploader1.InsertText = "更改图片";
        imgPath.Value = img1.ImageUrl;
    }
    
    void OnCancelUpload(object sender, EventArgs args)
    {
        img1.ImageUrl = null;
        img1.Visible = false;
    }
</script>

<script type="text/javascript">
    function CuteWebUI_AjaxUploader_OnSelect(files) {
        var name = files[0].FileName;

        var photoExt = name.substr(name.lastIndexOf(".")).toLowerCase(); //获得文件后缀名
        if (photoExt != '.jpg' && photoExt != '.png' && photoExt != '.gif') {
            alert("请上传后缀名为jpg/png/gif的照片!");
            return false;
        }
    }
       
</script>
   

</asp:Content>
