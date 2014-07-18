using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yreal.Web.Uploade
{
    using System.IO;

    /// <summary>
    /// DelImage 的摘要说明
    /// </summary>
    public class DelImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var imagePath = context.Request.Form["image"];

            if (File.Exists(context.Server.MapPath(imagePath)))
            {
                File.Delete(context.Server.MapPath(imagePath));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}