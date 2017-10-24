﻿using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Cities;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Notification;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Province;
using ir.ankasoft.entities;
using System.Linq;

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

                /*Communication*/
                ConfigCommunication(_);

                /*PostalAddress*/
                ConfigPostalAddress(_);

                /*Province*/
                ConfigProvince(_);

                /*City*/
                ConfigCity(_);

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
            //Display
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

            //Create
            _.CreateMap<ViewModelCreateParty, Party>()
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Party, ViewModelCreateParty>();

            //Modify
            _.CreateMap<ViewModelModifyParty, Party>()
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Party, ViewModelModifyParty>();

            _.CreateMap<ViewModelPartyCommunication, Party>()
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.Description, t => t.Ignore())
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Party, ViewModelPartyCommunication>();
        }

        private static void ConfigCommunication(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelCommunication, Communication>()
                .ForMember(p => p.CommunicationType, opt => opt.MapFrom(dest => dest.Type))
                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.PersonRefRecId, t => t.Ignore())
                .ForMember(p => p.ImporterRefRecId, t => t.Ignore())
                .ForMember(p => p.OrganizationRefRecId, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<Communication, ViewModelCommunication>()
                .ForMember(p => p.ParentId, opt => opt.MapFrom(dest => dest.PartyRefRecId))
                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.CommunicationType));

            _.CreateMap<ViewModelModifyCommunication, Communication>()
                .ForMember(p => p.CommunicationType, t => t.Ignore())
                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.PersonRefRecId, t => t.Ignore())
                .ForMember(p => p.ImporterRefRecId, t => t.Ignore())
                .ForMember(p => p.OrganizationRefRecId, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<Communication, ViewModelModifyCommunication>()
                .ForMember(p => p.ParentId, t => t.Ignore())
                .ForMember(p => p.PersonalTitle, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.NationalCode, t => t.Ignore())
                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.CommunicationType));

        }

        private static void ConfigPostalAddress(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelPostalAddress, PostalAddress>()
                .ForMember(p => p.Province, t => t.Ignore())
                .ForMember(p => p.City, t => t.Ignore())

                .ForMember(p => p.IsPrimary, opt => opt.MapFrom(dest => dest.Postal_IsPrimary))
                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.Postal_Type))
                .ForMember(p => p.Value, opt => opt.MapFrom(dest => dest.Postal_Value))
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.Postal_recId))

                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.PersonRefRecId, t => t.Ignore())
                .ForMember(p => p.ImporterRefRecId, t => t.Ignore())
                .ForMember(p => p.OrganizationRefRecId, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<PostalAddress, ViewModelPostalAddress>()
                .ForMember(p => p.Postal_recId, opt => opt.MapFrom(dest => dest.recId))
                .ForMember(p => p.Postal_IsPrimary, opt => opt.MapFrom(dest => dest.IsPrimary))
                .ForMember(p => p.Postal_Type, opt => opt.MapFrom(dest => dest.Type))
                .ForMember(p => p.Postal_Value, opt => opt.MapFrom(dest => dest.Value))
                .ForMember(p => p.ProvinceCity, opt => opt.MapFrom(dest => $"{dest.CityRefRecId},{dest.ProvinceRefRecId}"))
                .ForMember(p => p.Province, opt => opt.MapFrom(dest => dest.Province.Title))
                .ForMember(p => p.City, opt => opt.MapFrom(dest => dest.City.Title))
                .ForMember(p => p.ProvinceCityList, t => t.Ignore());
        }

        private static void ConfigProvince(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelDisplayProvince, Province>()
                .ForMember(p => p.Cities, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Province, ViewModelDisplayProvince>();
        }

        private static void ConfigCity(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelDisplayCity, City>()
                .ForMember(p => p.ProvinceRefRecID, t => t.Ignore())
                .ForMember(p => p.Province, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<City, ViewModelDisplayCity>()
                .ForMember(p => p.Province, opt => opt.MapFrom(dest => dest.Province.Title));
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
        }
    }
}