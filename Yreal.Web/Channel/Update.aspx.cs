using System;
using System.Web.UI.WebControls;

namespace Yreal.Web.Channel
{
    using Common;
    using Model;
    using Yreal.Web.common;

    public partial class Update : System.Web.UI.Page
    {
        private global::Common.DataContext ctx = new DataContext();

        protected Model.Channel channel = new Channel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var bll = new BLL.BLLBase();
                var chtb = bll.Select(ctx, new Channel() { ID = Convert.ToInt32(Request.QueryString["id"]), State = 0 });

                if (chtb != null && chtb.Rows.Count > 0)
                {
                    channel = chtb.ToList<Model.Channel>()[0];
                    var tb =
                        ctx.ExecuteDataTable(
                            "Select * From Channel where State<>255 and ParentId=0 and [Type] in (1,2)");

                    ddlParentId.Items.Add(new ListItem("顶级栏目", "0"));

                    if (tb != null && tb.Rows.Count > 0)
                    {
                        var channels = tb.ToList<Model.Channel>();
                        foreach (var pchannel in channels)
                        {

                            var item = new ListItem(pchannel.Name, pchannel.ID.ToString());
                            item.Attributes.Add("type", pchannel.Type.ToString());
                            ddlParentId.Items.Add(item);
                            if (pchannel.ID == channel.ParentId)
                            {
                                item.Selected = true;
                            }
                        }
                    }

                    ddlType.Items.Add(new ListItem("栏目列表页", "2"));
                    ddlType.Items.Add(new ListItem("内容列表页", "1"));
                    ddlType.Items.Add(new ListItem("单独内容页", "0"));
                }
            }
            else
            {
                AjaxResult response = null;

                var id = Request.Form["id"];
                var txtParentId = Request.Form["ctl00$ContentPlaceHolder1$ddlParentId"];
                var txtName = Request.Form["txtName"];
                var txtCode = Request.Form["txtCode"];
                var txtType = Request.Form["ctl00$ContentPlaceHolder1$ddlType"];
                var sltContentType = Request.Form["sltContentType"];
                var txtState = Request.Form["sltState"];
                var txtRemark = Request.Form["txtRemark"];
                var txtSort = Request.Form["txtSort"];
                var imageUrl = Request.Form["txtImage"];

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
                                 ID = Convert.ToInt32(id),
                                 Type = Convert.ToInt16(txtType),
                                 Code = txtCode,
                                 ModifyDate = DateTime.Now,
                                 Name = txtName,
                                 ContentType = Convert.ToInt16(sltContentType),
                                 ModifiedBy = (Session["LoginAdmin"] as Model.Admin).ID,
                                 Remark = txtRemark,
                                 ImageUrl = imageUrl,
                                 ParentId = Convert.ToInt16(txtParentId),
                                 State = Convert.ToInt16(txtState),
                                 Sort = Convert.ToInt16(txtSort),
                             };

                ctx.BeginTransaction();
                try
                {
                    var bll = new BLL.BLLBase();
                    bll.Update(ctx, dt);

                    ctx.CommitTransaction();

                    response = new AjaxResult() { Success = 1, Message = "操作成功", Data = id };
                }
                catch (Exception exception)
                {
                    ctx.RollBackTransaction();
                    response = new AjaxResult() { Success = 0, Message = "操作失败：" + exception.Message, Data = 0 };
                }
                finally
                {
                    ctx.CloseConnection();
                }

                this.Response.Write(common.Common.GetJSMsgBox(response.Message));
            }
        }
    }
}
