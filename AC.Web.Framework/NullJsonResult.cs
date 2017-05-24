using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using AC.Core;

namespace AC.Web.Framework
{
    public class NullJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if(context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : MimeTypes.ApplicationJson;
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            this.Data = null;

            var serializeObject = JsonConvert.SerializeObject(Data, Formatting.Indented);
            response.Write(serializeObject);
        }
    }
}
