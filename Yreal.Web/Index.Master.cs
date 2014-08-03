using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;

namespace Yreal.Web
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected List<Model.Channel> Channels;
        protected DataContext ctx=new DataContext();

        protected Model.Config LogoConfig = null;
        protected string Copyright = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            var bll = new BLL.Channel();
            Channels = bll.GetChannels(ctx) ?? new List<Model.Channel>();

            var tb=bll.Select(ctx, new Model.Config(){State = 0,Code = "Logo"});
            if (tb != null && tb.Rows.Count > 0)
            {
                LogoConfig = tb.ToList<Model.Config>()[0];
            }

            var gcs = bll.Select(ctx, new GlobeConfig() {Code = "Copyright"}).ToList<Model.GlobeConfig>();
            if (gcs != null && gcs.Count > 0)
            {
                this.Copyright = gcs[0].Text;
            }
        }
    }
}