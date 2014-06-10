using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Yreal.Web.User
{
    public partial class Update : System.Web.UI.Page
    {
        protected string LoginName, Name, Mob, Email, QQ, Remark, State, id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                id = Request.Form["id"];
                var txtLgName = Request.Form["txtLgName"];
                var txtName = Request.Form["txtName"];
                var txtEmail = Request.Form["txtMail"];
                var txtMob = Request.Form["txtMob"];
                var txtQQ = Request.Form["txtQQ"];
                var txtRemark = Request.Form["txtRemark"];
                var txtState = ddlState.SelectedValue;

                var dt = new Model.Admin()
                             {
                                 ID = int.Parse(id),
                                 Email = txtEmail,
                                 LoginName = txtLgName,
                                 ModifyDate = DateTime.Now,
                                 Name = txtName,
                                 Mob = txtMob,
                                 QQ = txtQQ,
                                 Remark = txtRemark,
                                 State = int.Parse(txtState)
                             };

                DataContext dc = new DataContext();

                AjaxResult response = null;
                dc.BeginTransaction();
                try
                {
                    var bll = new BLL.BLLBase();
                    bll.Update(dc, dt);

                    dc.CommitTransaction();

                    response = new AjaxResult() { Success = 1, Message = "操作成功", Data = id };
                }
                catch (Exception exception)
                {
                    dc.RollBackTransaction();
                    response = new AjaxResult() { Success = 0, Message = "操作失败：" + exception.Message, Data = 0 };
                }
                finally
                {
                    dc.CloseConnection();
                }

                this.Response.Write(common.Common.GetJSMsgBox(response.Message));
            }
            else
            {
                id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    var ctx = new DataContext();

                    var dt = ctx.ExecuteDataTable(
                        "SELECT [LoginName],[Password],[Name],[Mob],[Email],[QQ],[Remark],[State],[CreateDate],[ModifyDate] From [Admin] Where id=" +
                        id + " and [state]<>255");

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        LoginName = dt.Rows[0]["LoginName"].ToString();
                        Name = dt.Rows[0]["Name"].ToString();
                        Mob = dt.Rows[0]["Mob"].ToString();
                        Email = dt.Rows[0]["Email"].ToString();
                        QQ = dt.Rows[0]["QQ"].ToString();
                        Remark = dt.Rows[0]["Remark"].ToString();
                        State = dt.Rows[0]["State"].ToString();

                        ddlState.Items.Add(new ListItem("正常","0"));
                        ddlState.Items.Add(new ListItem("锁定", "1"));
                        ddlState.SelectedValue = State;
                    }else
                    {
                        Response.Write(common.Common.GetJSMsgBox("没有获取到用户信息"));
                    }
                }
            }
        }
    }
}