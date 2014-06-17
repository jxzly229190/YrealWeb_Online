using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Yreal.Web
{
    
    public partial class Index : System.Web.UI.MasterPage
    {
        protected List<Model.Channel> Channels;
        protected DataContext ctx=new DataContext();

        protected Model.Config LogoConfig = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var bll = new BLL.Channel();
            Channels = bll.GetChannels(ctx) ?? new List<Model.Channel>();

            var tb=bll.Select(ctx, new Model.Config(){State = 0,Code = "Logo"});
            if (tb != null && tb.Rows.Count > 0)
            {
                LogoConfig = tb.ToList<Model.Config>()[0];
            }
        }
    }
}