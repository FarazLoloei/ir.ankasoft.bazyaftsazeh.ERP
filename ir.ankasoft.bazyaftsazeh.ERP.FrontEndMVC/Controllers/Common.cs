using ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
                //string controllerTitle = nameof(PartyController).Replace("Controller", "");

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
        }

        public static Tuple<string, string> getProvinceAndCityTitleById(string provinceCityId)
        {
            string _provinceCity = sessionManager.getProvinceCities().Where(x => x.Value == provinceCityId).FirstOrDefault().Text;
            string[] province_city = _provinceCity.Split('-');
            return new Tuple<string, string>(province_city[0].Trim(), province_city[1].Trim());
        }
    }
}