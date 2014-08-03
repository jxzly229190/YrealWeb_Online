using System.Collections.Generic;

namespace BLL
{
    public class Channel:BLLBase
    {
         public List<Model.Channel> GetChannels(Common.DataContext ctx)
         {
             var tb = ctx.ExecuteDataTable("Select [ID],Code,Name as CName,ParentId,Case ParentId when 0 then [Name] else '|--'+[Name] end [Name],[Type],[ContentType],Case ParentId when 0 then ID else ParentId end sortId from [Channel] where State <> 255 order by sortId");

             if (tb != null && tb.Rows.Count > 0)
             {
                 var channels = tb.ToList<Model.Channel>();
                 return channels;
             }

             return new List<Model.Channel>();
         }
    }
}