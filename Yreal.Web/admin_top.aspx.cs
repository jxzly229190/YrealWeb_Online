using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace Yreal.Web
{
    public partial class admin_top : System.Web.UI.Page
    {
        protected Model.Admin admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = Session["LoginAdmin"] as Model.Admin;
            if(admin==null)
            {
                admin=new Model.Admin();
            }
        }
    }
}