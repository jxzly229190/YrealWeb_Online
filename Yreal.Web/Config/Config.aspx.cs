using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Yreal.Web.Config
{
    public partial class Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var configs = new BLL.Config().GetConfigs(new Common.DataContext());

            if(configs!=null)
            {
                Common.PubFunc.BindControl(rptList, configs);
            }
        }
    }
}