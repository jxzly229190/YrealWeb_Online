<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUploader.ascx.cs" Inherits="Yreal.Web.common.ImageUploader" %>
<%@ Import Namespace="System.IO" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader, Version=3.0.0.0, Culture=neutral, PublicKeyToken=bc00d4b0e43ec38d" %>

<CuteWebUI:Uploader id="Uploader1" runat="server"  InsertText="选择" OnFileUploaded="Uploader_FileUploaded"/>
    <asp:Image runat="server" ID="img1"  Width="20%" Height="20%" Visible="False"/>
    <asp:Button runat="server" ID="cancelBtn" Text="取消" OnClick="OnCancelUpload"/>
    
<script runat="server">
    void Uploader_FileUploaded(object sender, UploaderEventArgs args)
    {
        if (string.IsNullOrEmpty(this.UploadFolder))
        {
            this.UploadFolder = "Upload";
        }

        if (this.SaveByDate)
        {
            this.UploadFolder = "/" + this.UploadFolder + "/" + DateTime.Today.ToString("yyyy-MM-dd") + "/";
        }
        else
        {
            this.UploadFolder = "/" + this.UploadFolder + "/";
        }
        if (!Directory.Exists(this.UploadFolder))
        {
            Directory.CreateDirectory(this.UploadFolder);
        }

        args.CopyTo(UploadFolder + args.FileName);
        img1.ImageUrl = this.UploadFolder + args.FileName;
        this.FilePath = this.UploadFolder + args.FileName;
    }

    void OnUploadCompelete()
    {
    }

    void OnCancelUpload(object sender, EventArgs args)
    {
        FilePath = "";
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
