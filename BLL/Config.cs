using System.Collections.Generic;

namespace BLL
{
    using System.Linq;

    public class Config:BLLBase
    {
         public List<Model.Config> GetBanners(Common.DataContext ctx)
         {
             var tb = this.Select(ctx, new Model.Config() {Code = "Banner", State = 0});
             if(tb!=null&&tb.Rows.Count>0)
             {
                 return tb.ToList<Model.Config>();
             }

             return new List<Model.Config>();
         }

         public List<Model.Config> GetProducts(Common.DataContext ctx)
         {
             var tb = this.Select(ctx, new Model.Config() { Code = "Product", State = 0 });
             if (tb != null && tb.Rows.Count > 0)
             {
                 return tb.ToList<Model.Config>();
             }

             return new List<Model.Config>();
         }

         public List<Model.Config> GetConfigs(Common.DataContext ctx)
         {
             //var tb = this.Select(ctx, new Model.Config() {State = 0});
             var tb = ctx.ExecuteDataTable("Select * From Config Where State<>255");
             if (tb != null && tb.Rows.Count > 0)
             {
                 return tb.ToList<Model.Config>().OrderBy(c => c.Code).ToList();
             }

             return new List<Model.Config>();
         }
    }
}