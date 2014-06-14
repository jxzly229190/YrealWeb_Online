using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Yreal.Web
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                AjaxResult response = null;

                var txtLgName = Request.Form["txtLgName"];
                var txtPwd = Request.Form["txtPwd"];
                var txtName = Request.Form["txtName"];
                var txtEmail = Request.Form["txtMail"];
                var txtQQ = Request.Form["txtQQ"];
                var txtMob = Request.Form["txtMob"];
                var txtRemark = Request.Form["txtRemark"];

                if (string.IsNullOrEmpty(txtLgName))
                {
                    response = new AjaxResult() {Success = 0, Message = "登录名不能为空。"};
                    this.Response.Write(common.Common.GetJSMsgBox(response.Message));
                    return;
                }

                if (string.IsNullOrEmpty(txtPwd))
                {
                    response = new AjaxResult() { Success = 0, Message = "密码不能为空。" };
                    this.Response.Write(common.Common.GetJSMsgBox(response.Message));
                    return;
                }

                if (string.IsNullOrEmpty(txtName))
                {
                    response = new AjaxResult() { Success = 0, Message = "用户名不能为空。" };
                    this.Response.Write(common.Common.GetJSMsgBox(response.Message));
                    return;
                }
                
                var dt = new Model.Admin()
                             {
                                 CreateDate = DateTime.Now,
                                 Email = txtEmail,
                                 LoginName = txtLgName,
                                 ModifyDate = DateTime.Now,
                                 Name = txtName,
                                 Password = PubFunc.Md5(txtPwd),
                                 QQ = txtQQ,
                                 Mob = txtMob,
                                 Remark = txtRemark
                             };

                DataContext dc=new DataContext();

                dc.BeginTransaction();
                try
                {
                    var bll = new BLL.BLLBase();
                    var id = bll.Add(dc, dt);
                    
                    dc.CommitTransaction();

                    response = new AjaxResult() {Success = 1, Message = "操作成功", Data = id};
                }
                catch(Exception exception)
                {
                    dc.RollBackTransaction();
                    response = new AjaxResult() { Success = 0, Message = "操作失败："+exception.Message, Data = 0 };
                }
                finally
                {
                    dc.CloseConnection();
                }

                this.Response.Write(common.Common.GetJSMsgBox(response.Message));
            }
        }
    }
}