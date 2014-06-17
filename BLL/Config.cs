using System.Collections.Generic;

namespace BLL
{
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
             var tb = this.Select(ctx, new Model.Config() {State = 0});
             if (tb != null && tb.Rows.Count > 0)
             {
                 return tb.ToList<Model.Config>();
             }

             return new List<Model.Config>();
         }
    }
}