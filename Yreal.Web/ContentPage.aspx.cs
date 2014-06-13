using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Yreal.Web
{
    public partial class ContentPage : System.Web.UI.Page
    {
        protected List<Model.Channel> subChannels = null;
        protected List<Model.Content> Contents = null; 
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["CID"];
            var sid = Request.QueryString["SID"];
            var pid = Request.QueryString["Pid"];

            var ctx = new DataContext();
            var bll = new BLL.BLLBase();
            subChannels =
                bll.Select(ctx, new Model.Channel() {ParentId = Convert.ToInt16(id), State = 0}).ToList<Model.Channel>();

            subChannels = subChannels ?? new List<Model.Channel>();

            if (pid != null)
            {
                var tb = bll.Select(ctx, new Model.Content() { ID = Convert.ToInt32(pid), State = 0 });
                if (tb != null && tb.Rows.Count > 0)
                {
                    Contents=tb.ToList<Model.Content>();
                }
            }
            else if(sid!=null)
            {
                var channel = subChannels.Find(ch => ch.ID == Convert.ToInt32(sid));
                if (channel != null)
                {
                    //0--单独内容页，1--内容列表页
                    if (channel.Type == 0)
                    {
                        var tb =
                            ctx.ExecuteDataTable(
                                "Select top 1 * From Content where State!=255 and ChannelID=" + channel.ID
                                + " Order by ID desc");

                        if (tb != null)
                        {
                            Contents = tb.ToList<Model.Content>();
                        }
                    }
                    else
                    {
                        var tb =
                            ctx.ExecuteDataTable(
                                "Select top 20 [ID],[ChannelID],[Type],[ImageUrls],[Title],substring([ContentText],1,200) as ContentText,[Url],[Attributes],[State],[CreateDate] From Content where State!=255 and ChannelID=" + channel.ID
                                + " Order by ID desc");

                        if (tb != null)
                        {
                            Contents = tb.ToList<Model.Content>();
                        }
                    }
                }
            }
        }
    }
}