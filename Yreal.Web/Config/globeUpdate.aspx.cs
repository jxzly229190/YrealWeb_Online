using System;
using BLL;
using Common;

namespace Yreal.Web.Config
{
    public partial class globeUpdate : System.Web.UI.Page
    {
        protected Model.GlobeConfig config = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            var bll = new BLLBase();
            var ctx = new DataContext();
            if (!this.IsPostBack)
            {
                var gcs =
                    bll.Select(ctx, new Model.GlobeConfig() { ID =Convert.ToInt32(Request.QueryString["id"]) })
                        .ToList<Model.GlobeConfig>();
                if (gcs != null && gcs.Count > 0)
                {
                    this.config = gcs[0];
                }
                else
                {
                    this.config = new Model.GlobeConfig();
                }
            }
            else
            {
                var response = new AjaxResult();
                var id = Request.Form["ID"];
                if (id == null)
                {
                    this.Response.Write(common.Common.GetJSMsgBox("ID值错误"));
                    return;
                }

                try
                {
                    bll.Update(ctx, new Model.GlobeConfig() { ID = Convert.ToInt32(id), Text = Request.Form["text"] });
                    var gcs =
                        bll.Select(ctx, new Model.GlobeConfig() {ID = Convert.ToInt32(id)})
                            .ToList<Model.GlobeConfig>();
                    if (gcs != null && gcs.Count > 0)
                    {
                        this.config = gcs[0];
                    }
                    this.Response.Write(common.Common.GetJSMsgBox("更新成功"));
                }
                catch (Exception exception)
                {
                    this.Response.Write(common.Common.GetJSMsgBox("更新失败"));
                }
            }
        }
    }
}