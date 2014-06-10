using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;
using Model;

namespace Yreal.Web.Channel
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Form["act"]=="del")
            {
                var re=this.Del(int.Parse(Request.Form["id"]));
                this.Response.Write(re);
            }
        }

        private AjaxResult Del(int id)
        {
            BLL.BLLBase bll = new BLLBase();
            AjaxResult re = null;

            var ctx = new Common.DataContext();

            ctx.BeginTransaction();
            try
            {
                bll.Update(ctx, new Model.Channel() {ID = id, State = 255});

                ctx.CommitTransaction();

                re = new AjaxResult() {Success = 1};
            }
            catch (Exception ex)
            {
                ctx.RollBackTransaction();

                re = new AjaxResult() {Success = 0, Message = "操作失败，原因：" + ex.Message};
            }
            finally
            {
                ctx.CloseConnection();
            }

            return re;
        }
    }
}