using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public class JsonNetResult : JsonResult
    {
        public JsonNetResult(object model, JsonRequestBehavior requestBehavior) : this()
        {
            this.Data = model;
            this.JsonRequestBehavior = requestBehavior;
        }

        public JsonNetResult()
        {
            Settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Error };
        }

        public JsonSerializerSettings Settings { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            if (Data == null)
                return;

            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            var serializer = JsonSerializer.Create(Settings);
            using (var writer = new JsonTextWriter(response.Output))
            {
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }
    }
}