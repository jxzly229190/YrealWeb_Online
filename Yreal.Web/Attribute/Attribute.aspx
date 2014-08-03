<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Attribute.aspx.cs" Inherits="Yreal.Web.Attribute.Attribute" %>
<%@ Import Namespace="System.IO" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>

<%@ Register src="../common/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceTitle" runat="server">
    栏目属性
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
         <table class="tbExtend tb-line bgcw lineHeigth30 top15 bottom15 p5">
                    <tbody>
                        <tr>
                        <td align="right" width="8%">名称：</td>
                    <td width="92%">
                        <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">代码：</td>
                    <td width="92%">
                        <asp:TextBox runat="server" ID="txtCode"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                        <td align="right" width="8%">栏目：</td>
                    <td width="92%">
                        <asp:DropDownList ID="ddlChannelId" runat="server" >
                        </asp:DropDownList>
                    </td>
                    </tr>
                    
                    <tr>
                        <td align="right" width="8%">栏目：</td>
                    <td width="92%">
                        <asp:DropDownList ID="DropDownList1" runat="server" >
                        </asp:DropDownList>
                    </td>
                    </tr>
                    </tbody>
                    </table>
        
        
        <CuteWebUI:Uploader id="Uploader1" runat="server"  InsertText="选择" OnFileUploaded="Uploader_FileUploaded"/>
        <asp:Image runat="server" ID="img1"  Width="20%" Height="20%" Visible="False"/>
        <asp:Button runat="server" ID="cancelBtn" Text="取消" OnClick="OnCancelUpload"/>
        <asp:HiddenField runat="server" ID="imgPath"/>


    </form>
    
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
