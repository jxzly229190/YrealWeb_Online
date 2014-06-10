using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;

namespace Yreal.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var txtName = Request.Form["username"];
                var txtPwd = Request.Form["password"];

                Common.DataContext dataContext = new DataContext();

                var result =
                    dataContext.ExecuteDataTable(
                        "Select [LoginName],[Password],[Name],[Mob],[Email],[QQ],[Remark] From [Admin] Where [State] =0 and [LoginName]='" +
                        txtName +
                        "' and Password = '" + Common.PubFunc.Md5(txtPwd) + "'");

                if (result != null && result.Rows.Count > 0)
                {
                    this.Session["LoginAdmin"] = result.ToList<Model.Admin>()[0];
                    this.Response.Redirect("/Main.aspx");
                }
                else
                {
                    this.Response.Write(common.Common.GetJSMsgBox("用户名或者密码错误"));
                }
            }
        }
    }
}