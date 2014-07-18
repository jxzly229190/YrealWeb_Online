using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Ajax_uploadxx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		//Common.PubFunc.CheckReferrer();
        
		HttpPostedFile hpf = Request.Files[0];
		string oName = Path.GetFileName(hpf.FileName);
		string strExt = Path.GetExtension(oName).ToLower();
		int intTypeID = 0;
		if (!string.IsNullOrEmpty(Request.Form["TypeID"]))
		{
			string[] arry = Request.Form["TypeID"].Split(';');
			intTypeID = int.Parse(arry[0]);
		}
		#region 文件类型检查
		bool acc = false;
		string[] accept = { ".jpg", ".gif", ".png", ".swf", ".xls" };
		foreach (string s in accept)
		{
			if (strExt == s)
			{
				acc = true;
				break;
			}
		}

		if (!acc)
		{
            Response.Write("[{'oName':'error','sName':'文件类型不合法！'}]");
			return;
		}
		#endregion

        #region 验证图片是否在同类型下面存在

        //BLL.Picture bllPic = new BLL.Picture();
        //验证图片是否在同类型下面存在
        //Model.img_PictureFormType_S pfts = new Model.img_PictureFormType_S();
        //pfts.Action = 3;
        //pfts.ID = intTypeID;
        //pfts.PictureName = oName;
        //DataSet ds = bllPic.GetPictureTypePic(null, pfts);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    Response.Write("[{'oName':'error','sName':'该文件在当前图片类型中已存在！'}]");
        //    return;
        //}

        #endregion

        #region 建文件夹
        string path0 = Yreal.Web.common.Common.UploadImagePath;
		string path1 = DateTime.Today.ToString("yyyy") + "/" + DateTime.Today.ToString("MMdd") + "/";

		string path = Server.MapPath(path0 + path1);
		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);
		#endregion

		#region 保存文件
		string nName = Guid.NewGuid().ToString("N") + strExt;
		path = Server.MapPath(path0 + path1 + nName);
		hpf.SaveAs(path);
		nName=path1 + nName;
		#endregion

        //string strType = Request.Form["type"];
        //if (!string.IsNullOrEmpty(strType))
        //{
        //    #region 保存图片到数据库
        //    if (strType.ToLower() == "image")
        //    {
        //        Model.img_PictureFormType pic = new Model.img_PictureFormType();
        //        pic.img_PictureTypeID = intTypeID;
        //        pic.PictureName = oName;
        //        pic.PicturePath = nName;

        //        //保存图片到数据库
        //        int rel = bllPic.AddPictureFormType(null, pic);

        //        BLL.AdminLog log = new BLL.AdminLog();
        //        log.AddLog(pic, 0, "上传商品图片");
        //    }
        //    #endregion
        //}

        #region 生成产品、图像缩略图和水印图
        //if (folder.ToLower() == "product")
        //{
        //    //生成缩略图 100x100 230x230 380x380 650x650
        //    BLL.Picture bblPic = new BLL.Picture();
        //    bblPic.CreateProductPic(nName);
        //}
        //else if (folder.ToLower() == "face")
        //{
        //    //生成缩略图 70x70
        //    BLL.Picture bblPic = new BLL.Picture();
        //    bblPic.CreateFacePic(nName);
        //}
        #endregion

		string re = string.Format("'oName':'{0}','sName':'{1}'", oName, nName);
		Response.Write("[{" + re + "}]");
	}
}