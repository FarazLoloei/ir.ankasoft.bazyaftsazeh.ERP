// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF;
using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using StructureMap;
using System.Data.Entity;
using System.Web;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            var container = new Container(x =>
            {
                x.For<IUnitOfWorkFactory>().Use<EFUnitOfWorkFactory>();
                //x.For<Entities.Repositories.ICategoryRepository>().Use<Repositories.CategoryRepository>();
                //x.For<Entities.Repositories.IInventSiteRepository>().Use<Repositories.InventSiteRepository>();
                //x.For<Entities.Repositories.IUnitOfMeasureRepository>().Use<Repositories.UnitOfMeasureRepository>();
                //x.For<Entities.Repositories.IUnitOfMeasureCategoryRepository>().Use<Repositories.UnitOfMeasureCategoryRepository>();
                //x.For<Entities.Repositories.IPersonalTitleRepository>().Use<Repositories.PersonalTitleRepository>();
                //x.For<Entities.Repositories.ICounterPartyRepository>().Use<Repositories.CounterPartyRepository>();
                //x.For<Entities.Repositories.IUnitConvertorRepository>().Use<Repositories.UnitConvertorRepository>();
                //x.For<Entities.Repositories.IInventLocationTypeRepository>().Use<Repositories.InventLocationTypeRepository>();
                //x.For<Entities.Repositories.IInventLocationRepository>().Use<Repositories.InventLocationRepository>();
                //x.For<Entities.Repositories.IInventRepository>().Use<Repositories.InventRepository>();
                //x.For<Entities.Repositories.IPurchTypeRepository>().Use<Repositories.PurchTypeRepository>();
                //x.For<Entities.Repositories.IPurchStatusRepository>().Use<Repositories.PurchStatusRepository>();
                //x.For<Entities.Repositories.IPurchOrderRepository>().Use<Repositories.PurchOrderRepository>();
                //x.For<Entities.Repositories.IInventTransRepository>().Use<Repositories.InventTransRepository>();
                //x.For<Entities.Repositories.IVehicleTypeRepository>().Use<Repositories.VehicleTypeRepository>();
                //x.For<Entities.Repositories.IVehicleInfoRepository>().Use<Repositories.VehicleInfoRepository>();
                //x.For<Entities.Repositories.IInvoiceRepository>().Use<Repositories.InvoiceRepository>();
                x.For<INotificationRepository>().Use<NotificationRepository>();
                x.For<INotificationTypeRepository>().Use<NotificationTypeRepository>();
                //x.For<Entities.Repositories.ITransferRepository>().Use<Repositories.TransferRepository>();
                //x.For<Entities.Repositories.ISalesTypeRepository>().Use<Repositories.SalesTypeRepository>();
                //x.For<Entities.Repositories.ISalesStatusRepository>().Use<Repositories.SalesStatusRepository>();
                //x.For<Entities.Repositories.ISalesOrderRepository>().Use<Repositories.SalesOrderRepository>();
                //x.For<Entities.Repositories.IWarehoseEgressionRepository>().Use<Repositories.WarehoseEgressionRepository>();

                x.For<IUserStore<ApplicationUser, long>>().Use<UserStore<ApplicationUser, ApplicationRole, long,
                                                                         ApplicationUserLogin, ApplicationUserRole,
                                                                         ApplicationUserClaim>>();
                x.For<DbContext>().Use(() => new ApplicationDbContext());

                x.For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
            });
            return container;
        }
    }
}