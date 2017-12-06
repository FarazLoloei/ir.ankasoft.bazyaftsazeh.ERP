using ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public static class Common
    {
        public static class sessionManager
        {
            [OutputCache(Duration = 300, Location = System.Web.UI.OutputCacheLocation.Client)]
            public static List<SelectListItem> getProvinceCities()
            {
                //string key = "anka_ProvinceCity";
                //if (HttpContext.Current.Session[key] == null)
                //{
                //    ICityRepository _cityRepository = new CityRepository();

                //    var provinceCityList = _cityRepository.GetProvinceCity(string.Empty).Select(_ =>
                //    {
                //        return new SelectListItem() { Text = _.Item1, Value = _.Item2 };
                //    }).ToList();

                //    HttpContext.Current.Session[key] = provinceCityList;
                //    return provinceCityList;
                //}
                //else
                //{
                //    return HttpContext.Current.Session[key] as List<SelectListItem>;
                //}
                ICityRepository _cityRepository = new CityRepository();
                return _cityRepository.GetProvinceCity(string.Empty).Select(_ =>
                    {
                        return new SelectListItem() { Text = _.Item1, Value = _.Item2 };
                    }).ToList();
            }

            public static void getContextMenu(string controllerTitle)
            {
                string key = $"ContextMenu_{controllerTitle}";
                string keyHeader = $"ContextMenu_{controllerTitle}_Header";
                IContextMenuItemRepository _contextMenuItemRepository = new ContextMenuItemRepository();
                if (HttpContext.Current.Session[key] == null)
                    HttpContext.Current.Session[key] = Map(_contextMenuItemRepository.GetContextMenu(controllerTitle, false, true));

                if (HttpContext.Current.Session[keyHeader] == null)
                    HttpContext.Current.Session[keyHeader] = Map(_contextMenuItemRepository.GetContextMenu(controllerTitle, true, false));
            }

            private static List<ViewModelContextMenu> Map(IEnumerable<ContextMenuItem> list)
            {
                return list.Select(_ => new ViewModelContextMenu()
                {
                    recId = _.recId,
                    Title = _.Title,
                    Priority = _.Priority,
                    Disable = _.Disable.ToString(),
                    GroupCode = _.GroupCode,
                    Icon = _.Icon
                }).ToList();
            }

            public static List<SelectListItem> getCosts(bool suggestPrice)
            {
                string key= "Costs";
                if (suggestPrice)
                    key = $"CostsWithPriceSuggestion";

                ICostRepository _costRepository = new CostRepository();
                int totalRow = 1;
                if (HttpContext.Current.Session[key] == null)
                {
                    var list = Map(_costRepository.LoadByFilter(new FilterDataSource() { }, out totalRow), suggestPrice);
                    list.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
                    HttpContext.Current.Session[key] = list;
                }
                return HttpContext.Current.Session[key] as List<SelectListItem>;
            }

            private static List<SelectListItem> Map(IEnumerable<entities.Cost> list, bool suggestPrice)
            {
                if (suggestPrice)
                    return list.Select(_ => new SelectListItem()
                    {
                        Value = $"{_.recId},{_.Value}",
                        Text = $"{_.Title.Title } - {_.ValueInDisplayMode} {DefaultValues.DefaultCurrency}"
                    }).ToList();

                return list.Select(_ => new SelectListItem()
                {
                    Value = $"{_.recId}",
                    Text = $"{_.Title.Title } - {_.ValueInDisplayMode} {DefaultValues.DefaultCurrency}"
                }).ToList();
            }

            //public static List<SelectListItem> getCosts()
            //{
            //    string key = $"CostsWithPriceSuggestion";
            //    ICostRepository _costRepository = new CostRepository();
            //    int totalRow = 1;
            //    if (HttpContext.Current.Session[key] == null)
            //    {
            //        var list = Map(_costRepository.LoadByFilter(new FilterDataSource() { }, out totalRow), false);
            //        list.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            //        HttpContext.Current.Session[key] = list;
            //    }
            //    return HttpContext.Current.Session[key] as List<SelectListItem>;
            //}

            public static List<SelectListItem> getImperfection()
            {
                string key = $"Imperfection";
                IImperfectionRepository _imperfectionRepository = new ImperfectionRepository();
                int totalRow = 1;
                if (HttpContext.Current.Session[key] == null)
                {
                    var list = Map(_imperfectionRepository.LoadByFilter(new FilterDataSource() { }, out totalRow));
                    list.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
                    HttpContext.Current.Session[key] = list;
                }
                return HttpContext.Current.Session[key] as List<SelectListItem>;
            }

            private static List<SelectListItem> Map(IEnumerable<entities.Imperfection> list)
            {
                return list.Select(_ => new SelectListItem()
                {
                    Value = $"{_.recId},{_.Value}",
                    Text = $"{_.Title.Title } - {_.Value} {DefaultValues.DefaultCurrency}"
                }).ToList();
            }

            public static List<SelectListItem> getVehicleTips()
            {
                string key = $"VehicleTip";
                IVehicleTipRepository _vehicleTipRepository = new VehicleTipRepository();
                int totalRow = 1;
                if (HttpContext.Current.Session[key] == null)
                {
                    var list = Map(_vehicleTipRepository.LoadByFilter(new FilterDataSource() { }, out totalRow));
                    list.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
                    HttpContext.Current.Session[key] = list;
                }
                return HttpContext.Current.Session[key] as List<SelectListItem>;
            }

            private static List<SelectListItem> Map(IEnumerable<entities.VehicleTip> list)
            {
                var _resource = new ResourceManager(typeof(resource.Resource));
                return list.Select(_ => new SelectListItem()
                {
                    Value = $"{_.recId}",
                    Text = $"{_resource.GetString(_.Type.ToString())} {_.System} ({_.Capasity} {_resource.GetString(_.CapasityType.ToString()) })"
                }).ToList();
            }

            //public static List<SelectListItem> getDocumentCostTips()
            //{
            //    string key = $"VehicleTip";
            //    IVehicleTipRepository _vehicleTipRepository = new VehicleTipRepository();
            //    int totalRow = 1;
            //    if (HttpContext.Current.Session[key] == null)
            //    {
            //        var list = Map(_vehicleTipRepository.LoadByFilter(new FilterDataSource() { }, out totalRow));
            //        list.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            //        HttpContext.Current.Session[key] = list;
            //    }
            //    return HttpContext.Current.Session[key] as List<SelectListItem>;
            //}

            //private static List<SelectListItem> Map(IEnumerable<entities.VehicleTip> list)
            //{
            //    var _resource = new ResourceManager(typeof(resource.Resource));
            //    return list.Select(_ => new SelectListItem()
            //    {
            //        Value = $"{_.recId}",
            //        Text = $"{_resource.GetString(_.Type.ToString())} {_.System} ({_.Capasity} {_resource.GetString(_.CapasityType.ToString()) })"
            //    }).ToList();
            //}
        }

        public static Tuple<string, string> getProvinceAndCityTitleById(string provinceCityId)
        {
            string _provinceCity = sessionManager.getProvinceCities().Where(x => x.Value == provinceCityId).FirstOrDefault().Text;
            string[] province_city = _provinceCity.Split('-');
            return new Tuple<string, string>(province_city[0].Trim(), province_city[1].Trim());
        }
    }
}