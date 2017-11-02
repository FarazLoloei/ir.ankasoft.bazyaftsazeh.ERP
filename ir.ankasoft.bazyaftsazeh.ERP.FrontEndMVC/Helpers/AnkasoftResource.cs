using System;
using System.Linq.Expressions;
using System.Resources;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Helpers
{
    public static class AnkasoftResource
    {
        public static MvcHtmlString AnkaResource<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression
            ) where TModel : class
        {
            var value = ModelMetadata.FromLambdaExpression(
                           expression, htmlHelper.ViewData
                       ).Model;

            return new MvcHtmlString(new ResourceManager(typeof(resource.Resource)).GetString(value.ToString()));
        }

        //public static string AnkaResource<T>(this HtmlHelper html, object key)
        //{
        //    //ResourceManager resourceManager = new ResourceManager(typeof(resource.Resource));
        //    //return resourceManager.GetString(key.ToString());
        //}
    }
}