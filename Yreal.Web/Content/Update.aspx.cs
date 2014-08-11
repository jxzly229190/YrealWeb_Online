using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Yreal.Web.Content
{
    public partial class Update : System.Web.UI.Page
    {
        protected Model.Content Content=new Model.Content();
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            if(!IsPostBack)
            {
                var ctx = new DataContext();
                var dt=ctx.ExecuteDataTable("Select * from Content Where State<>255 And ID=" + id);
                if(dt!=null&&dt.Rows.Count>0)
                {
                    Content = dt.ToList<Model.Content>()[0];
                }
                img_1.ImgUrls = Content.ImageUrls;

                //加载栏目
                var bllChannels = new BLL.Channel();
                var channels = bllChannels.GetChannels(ctx);

                ddlChannel.Items.Add(new ListItem("==请选择==", "0"));
                foreach (var channel in channels)
                {
                    var item = new ListItem(channel.Name, channel.ID.ToString());
                    item.Attributes.Add("contentType", channel.ContentType.ToString());
                    item.Attributes.Add("class", "channel");
                    item.Attributes.Add("type", channel.Type.ToString());

                    if (Content.ChannelID == channel.ID)
                    {
                        item.Attributes.Add("Selected", "Selected");
                    }
                    ddlChannel.Items.Add(item);
                }
            }
        }
    }
}