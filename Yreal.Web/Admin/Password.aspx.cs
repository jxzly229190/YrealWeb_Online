namespace Yreal.Web.Admin
{
    using System;

    using BLL;

    using Common;

    using Model;

    public partial class Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                var admin = this.Session["LoginAdmin"] as Model.Admin;

                if (admin == null)
                {
                    this.Response.Write(common.Common.GetJSMsgBox("对不起，获取当前用户错误。"));
                    return;
                }

                if (admin.ID == -100)
                {
                    this.Response.Write(common.Common.GetJSMsgBox("对不起，超级用户账号不允许修改密码。"));
                    return;
                }

                var pwd = this.Request.Form["txtPwd"];
                var newPwd = this.Request.Form["txtNewPwd"];
                var cpwd = this.Request.Form["txtConfirmPwd"];

                if (PubFunc.Md5(pwd.ToString()) != admin.Password)
                {
                    this.Response.Write(common.Common.GetJSMsgBox("对不起，原密码不正确。"));
                    return;
                }

                if (newPwd.ToString() != cpwd.ToString())
                {
                    this.Response.Write(common.Common.GetJSMsgBox("对不起，新密码不一致。"));
                    return;
                }

                var ctx = new DataContext();
                var bll=new BLLBase();
                ctx.BeginTransaction();
                try
                {
                    bll.Update(ctx, new Admin() { ID = admin.ID, Password = PubFunc.Md5(newPwd) });
                    ctx.CommitTransaction();

                    this.Response.Write(common.Common.GetJSMsgBox("修改成功"));
                }
                catch(Exception exception)
                {
                    ctx.RollBackTransaction();

                    this.Response.Write(common.Common.GetJSMsgBox("对不起，修改密码发生错误，错误：" + exception.Message));
                }
                finally
                {
                    ctx.CloseConnection();
                }
            }
        }
    }
}