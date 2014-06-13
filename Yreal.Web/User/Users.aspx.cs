using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;
using Model;

namespace Yreal.Web
{
    public partial class Users : System.Web.UI.Page
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
                         " [ID],[LoginName],[Password] ,[Name],[Mob],[Email],[QQ],[Remark],[State],[Ext],[CreateDate],[ModifyDate] from [Admin] where Id not in (SELECT top " +
                         (pageIndex - 1) * pageSize + " [ID] FROM [Admin]" +
                         "Where State <> 255 And " + GetWhereStr() + ") and State <> 255  And " + GetWhereStr() +
                         " order by ID desc;Select count(ID) totalCount from [Admin] Where State <> 255 And " +
                         GetWhereStr();

            var dataset = ctx.ExecuteDataSet(sql);

            if (dataset.Tables.Count <= 0)
            {
                return;
            }

            var datatable = dataset.Tables[0];

            Common.PubFunc.BindControl(rptUserList, datatable);

            Pager.RecordCount = Convert.ToInt32(dataset.Tables[1].Rows[0]["totalCount"].ToString());
            //Pager.SetRewriteUrl();
        }

        private string GetWhereStr()
        {
            string sqlWhere = " 1=1 ";
            if(!string.IsNullOrEmpty(txtLgName.Value))
            {
                sqlWhere += "And LoginName like '%" + txtLgName.Value + "%' ";
            }

            if (!string.IsNullOrEmpty(txtEmail.Value))
            {
                sqlWhere += "And Email like '%" + txtEmail.Value + "%' ";
            }

            if (!string.IsNullOrEmpty(txtMob.Value))
            {
                sqlWhere += "And Mob like '%" + txtMob.Value + "%' ";
            }

            if (!string.IsNullOrEmpty(txtName.Value))
            {
                sqlWhere += "And Name like '%" + txtName.Value + "%' ";
            }

            return sqlWhere;
        }
    }
}