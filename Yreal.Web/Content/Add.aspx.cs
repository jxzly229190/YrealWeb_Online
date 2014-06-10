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
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.DataContext ctx = new DataContext();
            if(!IsPostBack)
            {
                var tb = ctx.ExecuteDataTable("Select [ID],Case ParentId when 0 then [Name] else '|--'+[Name] end [Name],[Type],[ContentType],Case ParentId when 0 then ID else ParentId end sortId from [Channel] where State <> 255 order by sortId");

                ddlChannel.Items.Add(new ListItem("==请选择==","0"));
                if (tb != null && tb.Rows.Count > 0)
                {
                    var channels = tb.ToList<Model.Channel>();
                    foreach (var channel in channels)
                    {
                        var item = new ListItem(channel.Name, channel.ID.ToString());
                        item.Attributes.Add("contentType", channel.ContentType.ToString());
                        item.Attributes.Add("class", "channel");
                        item.Attributes.Add("type", channel.Type.ToString());
                        ddlChannel.Items.Add(item);
                    }
                }
            }
        }
    }
}