using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yreal.Web
{
    using System.Runtime.InteropServices;

    using BLL;

    using Common;

    public partial class Default : System.Web.UI.Page
    {
        protected List<Model.Content> CompanyContents = null;
        protected List<Model.Content> dtContents = null;

        protected List<Model.Config> Configs = null; 
        protected void Page_Load(object sender, EventArgs e)
        {
            var ctx = new DataContext();
            var ds =
                ctx.ExecuteDataSet(
                    @"Select top 10 ID,Title,ChannelID,CreateDate from Content Where ChannelCode='Company' And State=0 Order by CreateDate Desc;
                    Select top 10 ID,Title,ChannelID,CreateDate from Content Where ChannelCode='dongtai' And State=0 Order by CreateDate Desc;
                    Select * from Config where state=0;");
            
            if (ds != null)
            {
                if (ds.Tables.Count>0)
                {
                    CompanyContents = ds.Tables[0].ToList<Model.Content>();
                }

                if (ds.Tables.Count > 1)
                {
                    dtContents = ds.Tables[1].ToList<Model.Content>();
                }

                if (ds.Tables.Count > 2)
                {
                    Configs = ds.Tables[2].ToList<Model.Config>();
                }
            }
        }
    }
}