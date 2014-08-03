using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CuteWebUI;

namespace Yreal.Web.Attribute
{
    public partial class Attribute : System.Web.UI.Page
    {
        protected string UploadFolder = "Upload";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
    }
}