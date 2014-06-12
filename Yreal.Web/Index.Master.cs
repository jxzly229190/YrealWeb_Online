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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var bll = new BLL.Channel();
            Channels = bll.GetChannels(ctx) ?? new List<Model.Channel>();
        }
    }
}