using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yreal.Web
{
    public partial class RightContent : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LoginAdmin"]==null)
            {
                Response.Write("<script language='javascript'>alert('对不起，登录状态过期，请重新登录。');parent.window.location='/login.aspx';</script>");
            }
        }
    }
}