using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;
using Model;

namespace Yreal.Web.User
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            if(!string.IsNullOrEmpty(id))
            {
                var ctx = new DataContext();

                var dt = ctx.ExecuteDataTable(
                    "SELECT [LoginName],[Password],[Name],[Mob],[Email],[QQ],[Remark],[State],[CreateDate],[ModifyDate] From [Admin] Where id=" +
                    id + " and [state]<>255");

                if(dt!=null&&dt.Rows.Count>0)
                {
                    txtLgName.Text = dt.Rows[0]["LoginName"].ToString();
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtMob.Text = dt.Rows[0]["Mob"].ToString();
                    txtQQ.Text = dt.Rows[0]["QQ"].ToString();
                    txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                    txtState.Text = dt.Rows[0]["State"].ToString();
                    txtCreateDate.Text = dt.Rows[0]["CreateDate"].ToString();
                    txtModifyDate.Text = dt.Rows[0]["ModifyDate"].ToString();
                }

            }
        }
    }
}