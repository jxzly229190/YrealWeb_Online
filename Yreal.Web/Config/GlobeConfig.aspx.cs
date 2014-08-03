using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Yreal.Web.Config
{
    public partial class GlobeConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var bll = new BLL.BLLBase();
            var tb = bll.Select(new DataContext(), new Model.GlobeConfig());
            if (tb.Rows != null && tb.Rows.Count > 0)
            {
                PubFunc.BindControl(rptList, tb);
            }
        }
    }
}