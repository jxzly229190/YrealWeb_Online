using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yreal.Web.Config
{
    using Common;

    public partial class Update : System.Web.UI.Page
    {
        protected Model.Config config = null;

        private DataContext ctx = new DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Request.QueryString["id"];

                var bll = new BLL.BLLBase();
                var tb = bll.Select(ctx, new Model.Config() { ID = Convert.ToInt32(id), State = 0 });

                if (tb != null && tb.Rows.Count > 0)
                {
                    config = tb.ToList<Model.Config>()[0];
                }

                if (config == null)
                {
                    config = new Model.Config();
                }

                img_1.ImgUrls = config.Url;
            }
        }
    }
}