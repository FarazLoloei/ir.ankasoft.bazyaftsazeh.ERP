using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Filters
{
 

    public class ModelValidationFilter : System.Web.Mvc.ActionFilterAttribute, IFilter//, IDependency
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            var viewData = filterContext.Controller.ViewData;

            if (filterContext.HttpContext.Request.HttpMethod == "POST")
            {

                foreach (var prop in ((ReflectedActionDescriptor)filterContext.ActionDescriptor).MethodInfo.GetParameters()
                    .Select(p => p.ParameterType)
                    .SelectMany(t => t.GetProperties())
                    .Select(p => new { p.Name, Modes = p.GetCustomAttributes(typeof(ValidationModeAttribute), false).OfType<ValidationModeAttribute>() })
                    .Where(x => x.Modes.Any()))
                {
                    var mode = prop.Modes.First();
                    if (!mode.Mode.HasFlag(ValidationModes.ServerSide))
                        try
                        {
                            viewData.ModelState.Remove(prop.Name);
                        }
                        catch (Exception)
                        {

                        }
                }

                //if (!viewData.ModelState.IsValid
                //&& filterContext.RequestContext.HttpContext.Request.Headers["ButterflyType"] != "butterflyed"
                //&& !viewData.ModelState.IsValid && filterContext.RouteData.Values["controller"].ToString().ToLower() != "register"
                //&& filterContext.RouteData.Values["controller"].ToString().ToLower() != "servicequestionmanagement"
                //&& filterContext.RouteData.Values["controller"].ToString().ToLower() != "ftthsupportdomainmanagement")
                //{
                //    throw new Exception(viewData.ModelState.ToString());
                //}
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class ValidationModeAttribute : Attribute
    {
        public ValidationModeAttribute(ValidationModes mode)
        {
            Mode = mode;
        }

        public ValidationModes Mode { get; }
    }
    public enum ValidationModes : byte
    {
        ClientSide = 1,
        ServerSide = 2
    }
}