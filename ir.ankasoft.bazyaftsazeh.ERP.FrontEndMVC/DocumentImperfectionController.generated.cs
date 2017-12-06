// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentImperfectionController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected DocumentImperfectionController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ImperfectionDetail()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ImperfectionDetail);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CreateDocumentImperfection()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateDocumentImperfection);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ModifyDocumentImperfection()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ModifyDocumentImperfection);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public DocumentImperfectionController Actions { get { return MVC.DocumentImperfection; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "DocumentImperfection";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "DocumentImperfection";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string ImperfectionDetail = "ImperfectionDetail";
            public readonly string CreateDocumentImperfection = "CreateDocumentImperfection";
            public readonly string ModifyDocumentImperfection = "ModifyDocumentImperfection";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string ImperfectionDetail = "ImperfectionDetail";
            public const string CreateDocumentImperfection = "CreateDocumentImperfection";
            public const string ModifyDocumentImperfection = "ModifyDocumentImperfection";
        }


        static readonly ActionParamsClass_ImperfectionDetail s_params_ImperfectionDetail = new ActionParamsClass_ImperfectionDetail();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ImperfectionDetail ImperfectionDetailParams { get { return s_params_ImperfectionDetail; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ImperfectionDetail
        {
            public readonly string request = "request";
        }
        static readonly ActionParamsClass_CreateDocumentImperfection s_params_CreateDocumentImperfection = new ActionParamsClass_CreateDocumentImperfection();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateDocumentImperfection CreateDocumentImperfectionParams { get { return s_params_CreateDocumentImperfection; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateDocumentImperfection
        {
            public readonly string parentId = "parentId";
            public readonly string request = "request";
        }
        static readonly ActionParamsClass_ModifyDocumentImperfection s_params_ModifyDocumentImperfection = new ActionParamsClass_ModifyDocumentImperfection();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ModifyDocumentImperfection ModifyDocumentImperfectionParams { get { return s_params_ModifyDocumentImperfection; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ModifyDocumentImperfection
        {
            public readonly string parentId = "parentId";
            public readonly string documentCostId = "documentCostId";
            public readonly string request = "request";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _Detail = "_Detail";
                public readonly string _Repeater = "_Repeater";
                public readonly string CreateDocumentImperfection = "CreateDocumentImperfection";
                public readonly string ModifyDocumentImperfection = "ModifyDocumentImperfection";
            }
            public readonly string _Detail = "~/Views/DocumentImperfection/_Detail.cshtml";
            public readonly string _Repeater = "~/Views/DocumentImperfection/_Repeater.cshtml";
            public readonly string CreateDocumentImperfection = "~/Views/DocumentImperfection/CreateDocumentImperfection.cshtml";
            public readonly string ModifyDocumentImperfection = "~/Views/DocumentImperfection/ModifyDocumentImperfection.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_DocumentImperfectionController : ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers.DocumentImperfectionController
    {
        public T4MVC_DocumentImperfectionController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ImperfectionDetailOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection.ViewModelCreateAndModifyDocumentImperfection> request);

        [NonAction]
        public override System.Web.Mvc.ActionResult ImperfectionDetail(System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection.ViewModelCreateAndModifyDocumentImperfection> request)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ImperfectionDetail);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            ImperfectionDetailOverride(callInfo, request);
            return callInfo;
        }

        [NonAction]
        partial void CreateDocumentImperfectionOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, long parentId);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateDocumentImperfection(long parentId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateDocumentImperfection);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "parentId", parentId);
            CreateDocumentImperfectionOverride(callInfo, parentId);
            return callInfo;
        }

        [NonAction]
        partial void CreateDocumentImperfectionOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection.ViewModelCreateAndModifyDocumentImperfection request);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateDocumentImperfection(ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection.ViewModelCreateAndModifyDocumentImperfection request)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateDocumentImperfection);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            CreateDocumentImperfectionOverride(callInfo, request);
            return callInfo;
        }

        [NonAction]
        partial void ModifyDocumentImperfectionOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, long parentId, long documentCostId);

        [NonAction]
        public override System.Web.Mvc.ActionResult ModifyDocumentImperfection(long parentId, long documentCostId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ModifyDocumentImperfection);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "parentId", parentId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "documentCostId", documentCostId);
            ModifyDocumentImperfectionOverride(callInfo, parentId, documentCostId);
            return callInfo;
        }

        [NonAction]
        partial void ModifyDocumentImperfectionOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection.ViewModelCreateAndModifyDocumentImperfection request);

        [NonAction]
        public override System.Web.Mvc.ActionResult ModifyDocumentImperfection(ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection.ViewModelCreateAndModifyDocumentImperfection request)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ModifyDocumentImperfection);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            ModifyDocumentImperfectionOverride(callInfo, request);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
