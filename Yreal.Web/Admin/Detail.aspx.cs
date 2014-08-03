namespace Yreal.Web.Admin
{
    using System;

    using Common;

    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Request.QueryString["id"];
            if(!string.IsNullOrEmpty(id))
            {
                var ctx = new DataContext();

                var dt = ctx.ExecuteDataTable(
                    "SELECT [LoginName],[Password],[Name],[Mob],[Email],[QQ],[Remark],[State],[CreateDate],[ModifyDate] From [Admin] Where id=" +
                    id + " and [state]<>255");

                if(dt!=null&&dt.Rows.Count>0)
                {
                    this.txtLgName.Text = dt.Rows[0]["LoginName"].ToString();
                    this.txtName.Text = dt.Rows[0]["Name"].ToString();
                    this.txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    this.txtMob.Text = dt.Rows[0]["Mob"].ToString();
                    this.txtQQ.Text = dt.Rows[0]["QQ"].ToString();
                    this.txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                    this.txtState.Text = dt.Rows[0]["State"].ToString();
                    this.txtCreateDate.Text = dt.Rows[0]["CreateDate"].ToString();
                    this.txtModifyDate.Text = dt.Rows[0]["ModifyDate"].ToString();
                }

            }
        }
    }
}