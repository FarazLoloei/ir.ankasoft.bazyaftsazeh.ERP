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
    public partial class PartyController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected PartyController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult Index()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Modify()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Modify);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Remove()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Remove);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CheckExistingNationalCode()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckExistingNationalCode);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CommunicationDetail()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CommunicationDetail);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult PostalAddressDetail()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PostalAddressDetail);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public PartyController Actions { get { return MVC.Party; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Party";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Party";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Create = "Create";
            public readonly string Modify = "Modify";
            public readonly string Remove = "Remove";
            public readonly string CheckExistingNationalCode = "CheckExistingNationalCode";
            public readonly string CommunicationDetail = "CommunicationDetail";
            public readonly string PostalAddressDetail = "PostalAddressDetail";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Create = "Create";
            public const string Modify = "Modify";
            public const string Remove = "Remove";
            public const string CheckExistingNationalCode = "CheckExistingNationalCode";
            public const string CommunicationDetail = "CommunicationDetail";
            public const string PostalAddressDetail = "PostalAddressDetail";
        }


        static readonly ActionParamsClass_Index s_params_Index = new ActionParamsClass_Index();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Index IndexParams { get { return s_params_Index; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Index
        {
            public readonly string request = "request";
        }
        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string request = "request";
            public readonly string communicationCollection = "communicationCollection";
            public readonly string postalAddressCollection = "postalAddressCollection";
        }
        static readonly ActionParamsClass_Modify s_params_Modify = new ActionParamsClass_Modify();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Modify ModifyParams { get { return s_params_Modify; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Modify
        {
            public readonly string id = "id";
            public readonly string request = "request";
            public readonly string communicationCollection = "communicationCollection";
            public readonly string postalAddressCollection = "postalAddressCollection";
        }
        static readonly ActionParamsClass_Remove s_params_Remove = new ActionParamsClass_Remove();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Remove RemoveParams { get { return s_params_Remove; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Remove
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_CheckExistingNationalCode s_params_CheckExistingNationalCode = new ActionParamsClass_CheckExistingNationalCode();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CheckExistingNationalCode CheckExistingNationalCodeParams { get { return s_params_CheckExistingNationalCode; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CheckExistingNationalCode
        {
            public readonly string nationalCode = "nationalCode";
        }
        static readonly ActionParamsClass_CommunicationDetail s_params_CommunicationDetail = new ActionParamsClass_CommunicationDetail();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CommunicationDetail CommunicationDetailParams { get { return s_params_CommunicationDetail; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CommunicationDetail
        {
            public readonly string request = "request";
        }
        static readonly ActionParamsClass_PostalAddressDetail s_params_PostalAddressDetail = new ActionParamsClass_PostalAddressDetail();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_PostalAddressDetail PostalAddressDetailParams { get { return s_params_PostalAddressDetail; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_PostalAddressDetail
        {
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
                public readonly string _List = "_List";
                public readonly string Create = "Create";
                public readonly string Index = "Index";
                public readonly string Modify = "Modify";
            }
            public readonly string _Detail = "~/Views/Party/_Detail.cshtml";
            public readonly string _List = "~/Views/Party/_List.cshtml";
            public readonly string Create = "~/Views/Party/Create.cshtml";
            public readonly string Index = "~/Views/Party/Index.cshtml";
            public readonly string Modify = "~/Views/Party/Modify.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_PartyController : ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers.PartyController
    {
        public T4MVC_PartyController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.FilterDataSource request);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index(ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.FilterDataSource request)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            IndexOverride(callInfo, request);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            CreateOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party.ViewModelCreateParty request, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication.ViewModelCommunication> communicationCollection, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress.ViewModelPostalAddress> postalAddressCollection);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party.ViewModelCreateParty request, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication.ViewModelCommunication> communicationCollection, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress.ViewModelPostalAddress> postalAddressCollection)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "communicationCollection", communicationCollection);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "postalAddressCollection", postalAddressCollection);
            CreateOverride(callInfo, request, communicationCollection, postalAddressCollection);
            return callInfo;
        }

        [NonAction]
        partial void ModifyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, long id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Modify(long id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Modify);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModifyOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void ModifyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party.ViewModelModifyParty request, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication.ViewModelCommunication> communicationCollection, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress.ViewModelPostalAddress> postalAddressCollection);

        [NonAction]
        public override System.Web.Mvc.ActionResult Modify(ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party.ViewModelModifyParty request, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication.ViewModelCommunication> communicationCollection, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress.ViewModelPostalAddress> postalAddressCollection)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Modify);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "communicationCollection", communicationCollection);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "postalAddressCollection", postalAddressCollection);
            ModifyOverride(callInfo, request, communicationCollection, postalAddressCollection);
            return callInfo;
        }

        [NonAction]
        partial void RemoveOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, long id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Remove(long id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Remove);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            RemoveOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void CheckExistingNationalCodeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string nationalCode);

        [NonAction]
        public override System.Web.Mvc.ActionResult CheckExistingNationalCode(string nationalCode)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckExistingNationalCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "nationalCode", nationalCode);
            CheckExistingNationalCodeOverride(callInfo, nationalCode);
            return callInfo;
        }

        [NonAction]
        partial void CommunicationDetailOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication.ViewModelCommunication> request);

        [NonAction]
        public override System.Web.Mvc.ActionResult CommunicationDetail(System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication.ViewModelCommunication> request)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CommunicationDetail);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            CommunicationDetailOverride(callInfo, request);
            return callInfo;
        }

        [NonAction]
        partial void PostalAddressDetailOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress.ViewModelPostalAddress> request);

        [NonAction]
        public override System.Web.Mvc.ActionResult PostalAddressDetail(System.Collections.Generic.List<ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress.ViewModelPostalAddress> request)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PostalAddressDetail);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            PostalAddressDetailOverride(callInfo, request);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
