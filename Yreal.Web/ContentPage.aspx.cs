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
    using BLL;

    public partial class ContentPage : System.Web.UI.Page
    {
        protected Model.Channel channel = null;

        protected List<Model.Channel> subChannels = null;

        protected List<Model.Content> Contents = null;

        protected Model.GlobeConfig Config = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["CID"];
            var sid = Request.QueryString["SID"];
            var pid = Request.QueryString["Pid"];

            if (id == null)
            {
                Response.Redirect("/Default.aspx");
                return;
            }

            var ctx = new DataContext();
            var bll = new BLL.BLLBase();

            Config = bll.Select(ctx, new GlobeConfig() {Code = "SiteName"}).ToList<Model.GlobeConfig>()[0];

            var channelTB = bll.Select(ctx, new Model.Channel() { ID = Convert.ToInt32(id), State = 0 });
            if (channelTB != null && channelTB.Rows.Count > 0)
            {
                channel = channelTB.ToList<Model.Channel>()[0];
            }
            subChannels =
                bll.Select(ctx, new Model.Channel() { ParentId = Convert.ToInt16(id), State = 0 })
                    .ToList<Model.Channel>()
                    .OrderBy(c => c.Sort)
                    .ToList();

            subChannels = subChannels ?? new List<Model.Channel>();

            if (pid != null) //单独网页
            {
                var tb = bll.Select(ctx, new Model.Content() { ID = Convert.ToInt32(pid), State = 0 });
                if (tb != null && tb.Rows.Count > 0)
                {
                    Contents = tb.ToList<Model.Content>();
                }
            }
            else if (sid != null) //单独栏目
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
                        //内容列表页
                        Contents = new List<Model.Content>();
                        var models = new BLL.Content().GetChannelContentList(ctx, channel.ID);
                        if (models != null && models.Count > 0)
                        {
                            Contents.AddRange(models);
                        }
                    }
                }
            }
            else //顶级栏目
            {
                //若为独立页面栏目
                if (channel.Type == 0)
                {
                    var content = new BLL.Content().GetSinplePageChannelContent(ctx, channel.ID);

                    if (content != null)
                    {
                        Contents = new List<Model.Content> { content };
                    }
                }
                else //内容列表栏目或栏目列表页
                {
                    //默认取第一栏目的内容
                    if (subChannels.Count > 0)
                    {
                        var subChannel = subChannels[0];

                        if (subChannel.Type == 0) //内容页
                        {
                            var content = new BLL.Content().GetSinplePageChannelContent(ctx, subChannel.ID);

                            if (content != null)
                            {
                                Contents = new List<Model.Content> { content };
                            }
                        }
                        else //内容列表页
                        {
                            Contents = new List<Model.Content>();
                            var models = new BLL.Content().GetChannelContentList(ctx, subChannel.ID);
                            if (models != null && models.Count > 0)
                            {
                                Contents.AddRange(models);
                            }
                        }
                    }
                }
            }
        }
    }
}