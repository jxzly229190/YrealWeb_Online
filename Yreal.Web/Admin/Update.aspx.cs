namespace Yreal.Web.Admin
{
    using System;
    using System.Web.UI.WebControls;

    using Common;

    public partial class Update : System.Web.UI.Page
    {
        protected string LoginName, Name, Mob, Email, QQ, Remark, State, id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.id = this.Request.Form["id"];
                var txtLgName = this.Request.Form["txtLgName"];
                var txtName = this.Request.Form["txtName"];
                var txtEmail = this.Request.Form["txtMail"];
                var txtMob = this.Request.Form["txtMob"];
                var txtQQ = this.Request.Form["txtQQ"];
                var txtRemark = this.Request.Form["txtRemark"];
                var txtState = this.ddlState.SelectedValue;

                var dt = new Model.Admin()
                             {
                                 ID = int.Parse(this.id),
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

                    response = new AjaxResult() { Success = 1, Message = "操作成功", Data = this.id };
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
                this.id = this.Request.QueryString["id"];
                if (!string.IsNullOrEmpty(this.id))
                {
                    var ctx = new DataContext();

                    var dt = ctx.ExecuteDataTable(
                        "SELECT [LoginName],[Password],[Name],[Mob],[Email],[QQ],[Remark],[State],[CreateDate],[ModifyDate] From [Admin] Where id=" +
                        this.id + " and [state]<>255");

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.LoginName = dt.Rows[0]["LoginName"].ToString();
                        this.Name = dt.Rows[0]["Name"].ToString();
                        this.Mob = dt.Rows[0]["Mob"].ToString();
                        this.Email = dt.Rows[0]["Email"].ToString();
                        this.QQ = dt.Rows[0]["QQ"].ToString();
                        this.Remark = dt.Rows[0]["Remark"].ToString();
                        this.State = dt.Rows[0]["State"].ToString();

                        this.ddlState.Items.Add(new ListItem("正常","0"));
                        this.ddlState.Items.Add(new ListItem("锁定", "1"));
                        this.ddlState.SelectedValue = this.State;
                    }else
                    {
                        this.Response.Write(common.Common.GetJSMsgBox("没有获取到用户信息"));
                    }
                }
            }
        }
    }
}