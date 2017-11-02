using AutoMapper;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.AutoMapperCustomMap
{
    public class CustomResolverEnumToPersianTitles : IValueResolver<int, string, string>
    {
        //private readonly IInventTransRepository _inventTransRepository;

        public CustomResolverEnumToPersianTitles()
        {
        }

        public string Resolve(int source, string destination, string destMember, ResolutionContext context)
        {
            return "استاندارد";
        }

        //public CustomResolverPurchOrder_Operation(IInventTransRepository inventTransRepository)
        //{
        //    _inventTransRepository = inventTransRepository;
        //}

        //public int Resolve(int source, string destination, int destMember, ResolutionContext context)
        //{
        //    switch (source.PurchStatusRefRecId)
        //    {
        //        case (long)Entities.Enums.EnumPurchaseStatus.Invoiced:
        //        case (long)Entities.Enums.EnumPurchaseStatus.Canceled:
        //            return 0;
        //        default:
        //            return 1;
        //    }
        //}
    }
}