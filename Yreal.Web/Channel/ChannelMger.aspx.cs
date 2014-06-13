using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Yreal.Web.Channel
{
    public partial class ChannelMger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.DataContext ctx = new Common.DataContext();
            int pageIndex = PubFunc.getPageIndex();
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            int pageSize = Pager.PageSize;

            ctx.CommandType = CommandType.Text;
            //    (SELECT ROW_NUMBER() OVER (ORDER BY usr_User.ID DESC) AS ROWNO,    
            string sql = @"Select [ID],Case ParentId when 0 then [Name] else '|----'+[Name] end [Name],[Type],[ContentType],[ImageUrl],[Code],[ParentId],[Sort],Case ParentId when 0 then ID else ParentId end sortId,[State],[CreateDate],[ModifyDate],[CreatedBy],[ModifiedBy],[Remark],[Ext] from [Channel] where State <> 255 order by sortId";

            var dataset = ctx.ExecuteDataSet(sql);

            if (dataset.Tables.Count <= 0)
            {
                return;
            }

            var list = dataset.Tables[0].ToList<Model.Channel>();

            Common.PubFunc.BindControl(rptList, list);

        }
    }
}