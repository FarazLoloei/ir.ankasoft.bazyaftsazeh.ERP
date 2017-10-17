using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.AutoMapperCustomMap;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Notification;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party;
using ir.ankasoft.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(_ =>
            {
                /*Category */
                //ConfigCategory(_);

                ///*Invent Site*/
                //ConfigInventSite(_);

                ///*Unit Of Measure*/
                //ConfigUnitOfMeasure(_);

                /*CounterParty*/
                ConfigParty(_);

                ///*UnitConvertor*/
                //ConfigUnitConvertor(_);

                ///*InventLocation*/
                //ConfigInventLocation(_);

                ///*Invent*/
                //ConfigInvent(_);

                ///*PurchOrder*/
                //ConfigPurchOrder(_);

                ///*Invent Trans*/
                //ConfigInventTrans(_);

                ///*Invnet Dim*/
                //ConfigInventDim(_);

                ///*Vehicle Info*/
                //ConfigVehicleInfo(_);

                ///*Invoice*/
                //ConfigInvoice(_);

                ///*Dashborad*/
                ConfigNotification(_);

                ///*InventOnHand*/
                //ConfigInventOnHand(_);

                ///*InventTransfer*/
                //ConfigInventTransfer(_);

                ///*SalesOrder*/
                //ConfigSalesOrder(_);

                ///*Shared */
                //ConfigShared(_);

                ConfigContextMenu(_);
            });

            MapperConfiguration.AssertConfigurationIsValid();
        }

        private static void ConfigParty(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelPartyDisplay, Party>()
                .ForMember(p => p.PersonalTitle, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
                .ForMember(p => p.CommunicationCollection, t => t.Ignore())
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));
            _.CreateMap<Party, ViewModelPartyDisplay>()
                .ForMember(p => p.Roles, t => t.Ignore())
                .ForMember(p => p.Telephone, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Telephone)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.Mobile, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Mobile)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));

            _.CreateMap<ViewModelCreateAndEditParty, Party>()
                .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
                .ForMember(p => p.CommunicationCollection, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Party, ViewModelCreateAndEditParty>();




            //_.CreateMap<PartyDisplayViewModel, Party>()
            //    .ForMember(p => p.PersonalTitle, t => t.Ignore())
            //    .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
            //    .ForMember(p => p.creatorUser, t => t.Ignore())
            //    .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
            //    .ForMember(p => p.modifierUser, t => t.Ignore())
            //    .ForMember(p => p.createdDateTime, t => t.Ignore())
            //    .ForMember(p => p.modifiedDateTime, t => t.Ignore())
            //    .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
            //    .ForMember(p => p.CommunicationCollection, t => t.Ignore())
            //    .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.Id));
            //_.CreateMap<Party, PartyDisplayViewModel>()
            //    .ForMember(p => p.PersonalTitle, opt => opt.MapFrom(dest => dest.PersonalTitle.ToString()));
            //_.CreateMap<Party, ViewModelExportToExcelCounterParty>()
            //    .ForMember(p => p.PersonalTitle, opt => opt.MapFrom(dest => dest.PersonalTitle.ToString()));
        }

        private static void ConfigNotification(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelDisplayNotification, Notification>()
                .ForMember(p => p.Body, t => t.Ignore())
                .ForMember(p => p.PublishDate, t => t.Ignore())
                .ForMember(p => p.PublishDateShamsi, t => t.Ignore())
                .ForMember(p => p.Type, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<Notification, ViewModelDisplayNotification>()
                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.Type.ToString()))
                .ForMember(p => p.Age, opt => opt.MapFrom(dest => dest.PublishDateAge));
        }

        private static void ConfigContextMenu(IMapperConfigurationExpression _)
        {
            _.CreateMap<ContextMenuItem, ViewModelContextMenu>();
                //.ForMember(p => p.ObjectiveRefRecId, t => t.Ignore())
                //.ForMember(p => p.Objective, t => t.Ignore())
                //.ForMember(p => p.RoleRefRecId, t => t.Ignore())
                //.ForMember(p => p.Role, t => t.Ignore())
                //.ForMember(p => p.ShowOnHeader, t => t.Ignore())
                //.ForMember(p => p.DisableOnHeader, t => t.Ignore())
                //.ForMember(p => p.ShowOnRow, t => t.Ignore())
                //.ForMember(p => p.DisableOnRow, t => t.Ignore())
                //.ForMember(p => p.createdDateTime, t => t.Ignore())
                //.ForMember(p => p.modifiedDateTime, t => t.Ignore())
                //.ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                //.ForMember(p => p.creatorUser, t => t.Ignore())
                //.ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                //.ForMember(p => p.modifierUser, t => t.Ignore());
        }
    }
}