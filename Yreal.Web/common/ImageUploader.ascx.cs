using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CuteWebUI;

namespace Yreal.Web.common
{
    public partial class ImageUploader : System.Web.UI.UserControl
    {
        public string UploadFolder = null;
        public bool SaveByDate = false;
        public string FilePath = null;
        //public event UploaderEventHandler OnImageUploaded;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}