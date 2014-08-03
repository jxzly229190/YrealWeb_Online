using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Yreal.Web.Channel
{
    public partial class Add : System.Web.UI.Page
    {
        Common.DataContext ctx=new DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var tb = ctx.ExecuteDataTable("Select * From Channel where State<>255 and ParentId=0 and [Type] in (1,2)");

                ddlParentId.Items.Add(new ListItem("顶级栏目", "0"));
                if(tb!=null&&tb.Rows.Count>0)
                {
                    var channels = tb.ToList<Model.Channel>();
                    foreach (var channel in channels)
                    {
                        var item = new ListItem(channel.Name, channel.ID.ToString());
                        item.Attributes.Add("type", channel.Type.ToString());
                        ddlParentId.Items.Add(item);
                    }
                }

                ddlType.Items.Add(new ListItem("栏目列表页", "2"));
                ddlType.Items.Add(new ListItem("内容列表页", "1"));
                ddlType.Items.Add(new ListItem("单独内容页", "0"));
            }
            else
            {
                AjaxResult response = null;

                var txtParentId = Request.Form["ctl00$ContentPlaceHolder1$ddlParentId"];
                var txtName = Request.Form["txtName"];
                var txtCode = Request.Form["txtCode"];
                var txtType = Request.Form["ctl00$ContentPlaceHolder1$ddlType"];
                var sltContentType = Request.Form["sltContentType"];
                var txtState = Request.Form["sltState"];
                var txtRemark = Request.Form["txtRemark"];
                var txtSort = Request.Form["txtSort"];
                var imageUrl = !string.IsNullOrEmpty(Request.Form["hifShowImage"])
                                   ? common.Common.UploadImagePath + Request.Form["hifShowImage"]
                                   : "";

                if (string.IsNullOrEmpty(txtCode))
                {
                    response = new AjaxResult() { Success = 0, Message = "代号不能为空！" };
                    this.Response.Write(common.Common.GetJSMsgBox(response.Message));
                    return;
                }

                if (string.IsNullOrEmpty(txtType))
                {
                    response = new AjaxResult() { Success = 0, Message = "类别不能为空。" };
                    this.Response.Write(common.Common.GetJSMsgBox(response.Message));
                    return;
                }

                if (string.IsNullOrEmpty(sltContentType))
                {
                    response = new AjaxResult() { Success = 0, Message = "内容类型不能为空。" };
                    this.Response.Write(common.Common.GetJSMsgBox(response.Message));
                    return;
                }

                if (string.IsNullOrEmpty(txtName))
                {
                    response = new AjaxResult() { Success = 0, Message = "用户名不能为空。" };
                    this.Response.Write(common.Common.GetJSMsgBox(response.Message));
                    return;
                }

                var dt = new Model.Channel()
                {
                    CreateDate = DateTime.Now,
                    Type = Convert.ToInt16(txtType),
                    Code = txtCode,
                    ModifyDate = DateTime.Now,
                    Name = txtName,
                    ContentType = Convert.ToInt16(sltContentType),
                    CreatedBy = (Session["LoginAdmin"] as Model.Admin).ID,
                    ModifiedBy = (Session["LoginAdmin"] as Model.Admin).ID,
                    Remark = txtRemark,
                    ImageUrl = imageUrl,
                    ParentId = Convert.ToInt16(txtParentId),
                    State = Convert.ToInt16(txtState),
                    Sort = Convert.ToInt16(txtSort),
                };

                DataContext dc = new DataContext();

                dc.BeginTransaction();
                try
                {
                    var bll = new BLL.BLLBase();
                    var id = bll.Add(dc, dt);

                    dc.CommitTransaction();

                    response = new AjaxResult() { Success = 1, Message = "操作成功", Data = id };
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
        }

        protected void ddlParentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlParentId.SelectedValue == "0")
            {
                ddlType.Items.Add(new ListItem("栏目列表页", "2"));
                ddlType.Items.Add(new ListItem("内容列表页", "1"));
                ddlType.Items.Add(new ListItem("单独内容页", "0"));
            }
            else if (ddlParentId.SelectedItem.Attributes["type"] == "2")
            {
                ddlType.Items.Add(new ListItem("内容列表页", "1"));
                ddlType.Items.Add(new ListItem("单独内容页", "0"));
            }
            else
            {
                ddlType.Enabled = false;
            }
        }
    }
}