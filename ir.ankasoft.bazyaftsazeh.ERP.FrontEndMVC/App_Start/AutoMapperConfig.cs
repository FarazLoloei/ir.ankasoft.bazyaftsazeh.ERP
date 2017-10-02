using AutoMapper;
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
            //ConfigNotification(_);

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
    }
}