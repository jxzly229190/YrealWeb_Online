namespace BLL
{
    using System.Collections.Generic;

    using Common;

    public class Content : BLLBase
    {
        public Model.Content GetSinplePageChannelContent(DataContext ctx,int? channelId)
        {
            var tb =
                            ctx.ExecuteDataTable(
                                "Select top 1 * From Content where State!=255 and ChannelID=" + channelId
                                + " Order by ID desc");

            if (tb != null && tb.Rows.Count > 0)
            {
                return tb.ToList<Model.Content>()[0];
            }

            return null;
        }

        public List<Model.Content> GetChannelContentList(DataContext ctx, int? channelId)
        {
            var tb =
                            ctx.ExecuteDataTable(
                                "Select top 20 [ID],[ChannelID],[Type],[ImageUrls],[Title],substring([ContentText],1,200) as ContentText,[Url],[Attributes],[State],[CreateDate],ChannelName From Content where State!=255 and ChannelID="
                                + channelId + " Order by ID desc");

            if (tb != null)
            {
                return tb.ToList<Model.Content>();
            }

            return new List<Model.Content>();
        } 
    }
}