using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;

namespace Yreal.Web.Content
{
    public partial class Ajax : System.Web.UI.Page
    {

        DataContext ctx = new Common.DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["act"] == "del")
            {
                var re = this.Del(int.Parse(Request.Form["id"]));
                this.Response.Write(re);
            }
            else if (Request.Form["act"] == "add")
            {
                this.Response.Write(this.Add());
            }
            else if(Request.Form["act"]=="edit")
            {
                this.Response.Write(this.Edit());
            }
        }

        private AjaxResult Edit()
        {
            var title = Request.Form["title"];
            var channel = Request.Form["channel"];
            var content = Request.Form["content"];
            var recommend = Request.Form["recommend"];
            var image = Request.Form["image"];
            var remark = Request.Form["remark"];
            var id = Request.Form["id"];

            AjaxResult re = new AjaxResult();
            if (string.IsNullOrEmpty(title))
            {
                re.Success = 0;
                re.Message = "标题不能为空";

                return re;
            }

            if (string.IsNullOrEmpty(channel))
            {
                re.Success = 0;
                re.Message = "栏目不能为空";
                return re;
            }

            if (string.IsNullOrEmpty(content))
            {
                re.Success = 0;
                re.Message = "内容不能为空";

                return re;
            }

            BLL.BLLBase bll = new BLLBase();

            ctx.BeginTransaction();
            try
            {
                var tb = ctx.ExecuteDataTable("Select * from Channel Where ID=" + channel);

                if (tb == null && tb.Rows.Count < 1)
                {
                    throw new Exception("获取频道信息出错");
                }

                var channelObj = tb.ToList<Model.Channel>()[0];

                var contentObj = new Model.Content()
                {
                    ID=Convert.ToInt16(id),
                    Attributes = recommend,
                    ChannelCode = channelObj.Code,
                    ChannelName = channelObj.Name,
                    ChannelID = channelObj.ID,
                    ContentText = content,
                    ImageUrls = image,
                    ModifiedBy = PubFunc.GetAdminID(),
                    ModifyDate = DateTime.Now,
                    Remark = remark,
                    Type = channelObj.ContentType,
                    State = 0,
                    Title = title
                };

                bll.Update(ctx, contentObj);
                ctx.CommitTransaction();

                re.Success = 1;
                re.Message = "添加成功";
            }
            catch (Exception exception)
            {
                ctx.RollBackTransaction();
                re.Success = 0;
                re.Message = exception.Message;
                throw;
            }
            finally
            {
                ctx.CloseConnection();
            }

            return re;
        }

        private AjaxResult Add()
        {
            var title = Request.Form["title"];
            var channel = Request.Form["channel"];
            var content = Request.Form["content"];
            var recommend = Request.Form["recommend"];
            var image = Request.Form["image"];
            var remark = Request.Form["remark"];

            AjaxResult re = new AjaxResult();
            if (string.IsNullOrEmpty(title))
            {
                re.Success = 0;
                re.Message = "标题不能为空";

                return re;
            }

            if (string.IsNullOrEmpty(channel))
            {
                re.Success = 0;
                re.Message = "栏目不能为空";
                return re;
            }

            if (string.IsNullOrEmpty(content))
            {
                re.Success = 0;
                re.Message = "内容不能为空";

                return re;
            }

            BLL.BLLBase bll = new BLLBase();

            ctx.BeginTransaction();
            try
            {
                var tb = ctx.ExecuteDataTable("Select * from Channel Where ID=" + channel);

                if (tb == null && tb.Rows.Count < 1)
                {
                    throw new Exception("获取频道信息出错");
                }

                var channelObj = tb.ToList<Model.Channel>()[0];

                var contentObj = new Model.Content()
                {
                    Attributes = recommend,
                    ChannelCode = channelObj.Code,
                    ChannelName = channelObj.Name,
                    ChannelID = channelObj.ID,
                    ContentText = content,
                    ImageUrls = image,
                    CreatedBy = PubFunc.GetAdminID(),
                    CreateDate = DateTime.Now,
                    ModifiedBy = PubFunc.GetAdminID(),
                    ModifyDate = DateTime.Now,
                    Remark = remark,
                    Type = channelObj.ContentType,
                    State = 0,
                    Title = title
                };

                bll.Add(ctx, contentObj);
                ctx.CommitTransaction();

                re.Success = 1;
                re.Message = "添加成功";
            }
            catch (Exception exception)
            {
                ctx.RollBackTransaction();
                re.Success = 0;
                re.Message = exception.Message;
                throw;
            }
            finally
            {
                ctx.CloseConnection();
            }

            return re;
        }

        private AjaxResult GetContentType(int id)
        {
            return null;
        }

        private AjaxResult GetChannelType(int cId)
        {
            return null;
        }

        private AjaxResult Del(int id)
        {
            BLL.BLLBase bll = new BLLBase();
            AjaxResult re = null;


            ctx.BeginTransaction();
            try
            {
                bll.Update(ctx, new Model.Content() { ID = id, State = 255 });

                ctx.CommitTransaction();

                re = new AjaxResult() { Success = 1 };
            }
            catch (Exception ex)
            {
                ctx.RollBackTransaction();

                re = new AjaxResult() { Success = 0, Message = "操作失败，原因：" + ex.Message };
            }
            finally
            {
                ctx.CloseConnection();
            }

            return re;
        }
    }
}