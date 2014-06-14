namespace Yreal.Web.Admin
{
    using System;

    using BLL;

    using Common;

    using Model;

    public partial class Ajax : System.Web.UI.Page
    {
        DataContext ctx=new DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Request.Form["act"]=="del")
            {
                var re=this.Del(int.Parse(this.Request.Form["id"]));
                this.Response.Write(re);
            }
            else if(this.Request.Form["act"]=="reset")
            {
                var re = this.ResetPwd(int.Parse(this.Request.Form["id"]));
                this.Response.Write(re);
            }
            else if (this.Request.Form["act"] == "out")
            {
                this.Session.Remove("LoginAdmin");
                this.Response.Write("0");
                return;
            }
        }

        private AjaxResult ResetPwd(int id)
        {
            BLL.BLLBase bll = new BLLBase();
            AjaxResult re = null;

            this.ctx.BeginTransaction();
            try
            {
                bll.Update(this.ctx, new Admin() {ID = id, Password = PubFunc.Md5("123456")});

                this.ctx.CommitTransaction();

                re = new AjaxResult() { Success = 1 };
            }
            catch (Exception ex)
            {
                this.ctx.RollBackTransaction();

                re = new AjaxResult() { Success = 0, Message = "操作失败，原因：" + ex.Message };
            }
            finally
            {
                this.ctx.CloseConnection();
            }

            return re;
        }

        private AjaxResult Del(int id)
        {
            BLL.BLLBase bll = new BLLBase();
            AjaxResult re = null;

            this.ctx.BeginTransaction();
            try
            {
                bll.Update(this.ctx, new Admin() { ID = id, State = 255 });

                this.ctx.CommitTransaction();

                re = new AjaxResult() { Success = 1 };
            }
            catch (Exception ex)
            {
                this.ctx.RollBackTransaction();

                re = new AjaxResult() { Success = 0, Message = "操作失败，原因：" + ex.Message };
            }
            finally
            {
                this.ctx.CloseConnection();
            }

            return re;
        }
    }
}