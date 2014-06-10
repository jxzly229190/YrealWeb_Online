using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yreal.Web.Content
{
    public partial class imageUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                UploadImage();
            }
        }

        private void UploadImage()
        {
            //上传配置
            string pathbase = "upload/"; //保存路径
            int size = 10;
            //文件大小限制,单位mb                                                                                   //文件大小限制，单位KB
            string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" }; //文件允许格式

            //上传图片
            Hashtable info;
            var up = new Yreal.Web.UM.Uploader();
            info = up.upFile(this.Context, pathbase, filetype, size); //获取上传状态
            
            Response.ContentType = "text/html";

            Response.Redirect("imageUpSuccess.aspx?url=" + info["url"]);
        }
    }
}