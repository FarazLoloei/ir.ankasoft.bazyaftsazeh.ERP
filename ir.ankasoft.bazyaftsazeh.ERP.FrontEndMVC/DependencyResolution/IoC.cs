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
using ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StructureMap;
using System.Data.Entity;
using System.Web;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            var container = new Container(x =>
            {
                x.For<IUnitOfWorkFactory>().Use<EFUnitOfWorkFactory>();
                x.For<INotificationRepository>().Use<NotificationRepository>();
                x.For<IPartyRepository>().Use<PartyRepository>();
                x.For<IContextMenuItemRepository>().Use<ContextMenuItemRepository>();
                x.For<IProvinceRepository>().Use<ProvinceRepository>();
                x.For<ICityRepository>().Use<CityRepository>();
                x.For<ICommunicationRepository>().Use<CommunicationRepository>();
                x.For<IPostalAddressRepository>().Use<PostalAddressRepository>();
                x.For<IPersonRepository>().Use<PersonRepository>();
                x.For<IOrganizationRepository>().Use<OrganizationRepository>();
                x.For<IImporterRepository>().Use<ImporterRepository>();
                x.For<IVehicleRepository>().Use<VehicleRepository>();
                x.For<IVehicleTipRepository>().Use<VehicleTipRepository>();
                x.For<ICostRepository>().Use<CostRepository>();
                x.For<IPreDefineTitleRepository>().Use<PreDefineTitleRepository>();
                x.For<IImperfectionRepository>().Use<ImperfectionRepository>();
                x.For<IDocumentRepository>().Use<DocumentRepository>();
                x.For<IDocumentCostRepository>().Use<DocumentCostRepository>();
                x.For<IDocumentImperfectionRepository>().Use<DocumentImperfectionRepository>();
                x.For<IPaymentRepository>().Use<PaymentRepository>();


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