using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yreal.Web.Config
{
    using Common;

    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var act = Request.Form["act"];
            var ctx = new DataContext();

            if (act == "edit")
            {
                AjaxResult response = null;

                var id = Request.Form["id"];
                var txtCode = Request.Form["txtCode"];
                var txtText = Request.Form["txtText"];
                var txtImage = Request.Form["txtImage"];
                var url = Request.Form["txtUrl"];

                if (txtCode == "Banner" && string.IsNullOrEmpty(txtImage))
                {
                    response = new AjaxResult() { Success = 0, Message = "图片不能为空！" };
                    this.Response.Write(response);
                    return;
                }

                if (txtCode == "About" && string.IsNullOrEmpty(txtText))
                {
                    response = new AjaxResult() { Success = 0, Message = "文字说明不能为空。" };
                    this.Response.Write(response);
                    return;
                }

                var admin = this.Session["LoginAdmin"] as Model.Admin;

                var dt = new Model.Config()
                             {
                                 ID = Convert.ToInt32(id),
                                 Image = txtImage,
                                 Text = txtText,
                                 Url = url,
                                 ModifyBy = admin == null ? 0 : admin.ID,
                                 ModifyDate = DateTime.Now
                             };

                ctx.BeginTransaction();
                try
                {
                    var bll = new BLL.BLLBase();
                    bll.Update(ctx, dt);

                    ctx.CommitTransaction();

                    response = new AjaxResult() { Success = 1, Message = "操作成功", Data = id };
                }
                catch (Exception exception)
                {
                    ctx.RollBackTransaction();
                    response = new AjaxResult() { Success = 0, Message = "操作失败：" + exception.Message, Data = 0 };
                }
                finally
                {
                    ctx.CloseConnection();
                }

                this.Response.Write(response);
            }
            else if(act=="stop")
            {
                AjaxResult response = null;

                var id = Request.Form["id"];
                var state = Request.Form["state"];

                var admin = this.Session["LoginAdmin"] as Model.Admin;
                var dt = new Model.Config()
                             {
                                 ID = Convert.ToInt32(id),
                                 State = state == "0" ? 1 : 0,
                                 ModifyBy = admin == null ? 0 : admin.ID,
                                 ModifyDate = DateTime.Now
                             };

                ctx.BeginTransaction();
                try
                {
                    var bll = new BLL.BLLBase();
                    bll.Update(ctx, dt);

                    ctx.CommitTransaction();

                    response = new AjaxResult() { Success = 1, Message = "操作成功", Data = id };
                }
                catch (Exception exception)
                {
                    ctx.RollBackTransaction();
                    response = new AjaxResult() { Success = 0, Message = "操作失败：" + exception.Message, Data = 0 };
                }
                finally
                {
                    ctx.CloseConnection();
                }

                this.Response.Write(response);
            }
        }
    }
}