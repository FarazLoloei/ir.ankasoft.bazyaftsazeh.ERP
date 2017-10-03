using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.AutoMapperCustomMap;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Notification;
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

            ///*CounterParty*/
            //ConfigCounterParty(_);

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
        });

            MapperConfiguration.AssertConfigurationIsValid();
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
                //.ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.Type.Title))
                .ForMember(p => p.Type, opt => opt.MapFrom(dest=>dest.Type.ToString()))
                .ForMember(p => p.Age, opt => opt.MapFrom(dest => dest.PublishDateAge));
        }
    }
}