using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;

namespace Yreal.Web.Content
{
    public partial class ContentMger : System.Web.UI.Page
    {
        Common.DataContext ctx = new Common.DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = PubFunc.getPageIndex();
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            int pageSize = Pager.PageSize;

            ctx.CommandType = CommandType.Text;
            //    (SELECT ROW_NUMBER() OVER (ORDER BY usr_User.ID DESC) AS ROWNO,    
            string sql = @"Select top " + pageSize +
                         " [ID],[ChannelID],[ChannelName],[ChannelCode],[Type],[ImageUrls],[Title],substring([ContentText],1,200)+'...' as ContentText,[Url],[Attributes],[CreateDate],[CreatedBy],[ModifyDate],[ModifiedBy],[Remark],[Ext],[State] from [Content] where Id not in (SELECT top " +
                         (pageIndex - 1) * pageSize + " [ID] FROM [Content] Where State <> 255 And " + GetWhereStr() + " Order by ID desc) and State <> 255  And " + GetWhereStr() +
                         " order by ID desc;Select count(ID) totalCount from [Content] Where State <> 255 And " + GetWhereStr()+";Select Name,ID From Channel Where State<>255";

            var dataset = ctx.ExecuteDataSet(sql);

            if (dataset.Tables.Count <= 0)
            {
                return;
            }

            var datatable = dataset.Tables[0];

            Common.PubFunc.BindControl(rptUserList, datatable);

            Pager.RecordCount = Convert.ToInt32(dataset.Tables[1].Rows[0]["totalCount"].ToString());

            if(!IsPostBack)
            {
                ddlChannel.Items.Clear();
                ddlChannel.Items.Add(new ListItem("全部", "0"));
                if (dataset.Tables[2] != null && dataset.Tables[2].Rows.Count > 0)
                {
                    var channels = dataset.Tables[2].ToList<Model.Channel>();
                    foreach (var channel in channels)
                    {
                        ddlChannel.Items.Add(new ListItem(channel.Name, channel.ID.ToString()));
                    }
                }
            }
            
            //Pager.SetRewriteUrl();
        }

        private string GetWhereStr()
        {
            string sqlWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(txtTitle.Value))
            {
                sqlWhere += "And Title like '%" + txtTitle.Value + "%' ";
            }

            if (!string.IsNullOrEmpty(txtContentText.Value))
            {
                sqlWhere += "And ContentText like '%" + txtContentText.Value + "%' ";
            }

            if (ddlChannel.SelectedValue != "0" && !string.IsNullOrEmpty(ddlChannel.SelectedValue))
            {
                sqlWhere += "And ChannelID = " + ddlChannel.SelectedValue;
            }
            
            return sqlWhere;
        }
    }
}