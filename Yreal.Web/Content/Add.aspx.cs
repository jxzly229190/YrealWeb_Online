using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;

namespace Yreal.Web.Content
{
    public partial class Add : System.Web.UI.Page
    {
        protected List<Model.Channel> channels=new List<Model.Channel>(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.DataContext ctx = new DataContext();
            if(!IsPostBack)
            {
                var tb = ctx.ExecuteDataTable("Select [ID],Case ParentId when 0 then [Name] else '|--'+[Name] end [Name],[Type],[ContentType],Case ParentId when 0 then ID else ParentId end sortId from [Channel] where State <> 255 order by sortId");

                if (tb != null && tb.Rows.Count > 0)
                {
                    channels = tb.ToList<Model.Channel>();
                }
            }
        }
    }
}