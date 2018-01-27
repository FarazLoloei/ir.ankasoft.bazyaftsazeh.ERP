using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class DocumentPreRequirementRepository : Repository<DocumentPreRequirement>, IDocumentPreRequirementRepository
    {
        //public override IEnumerable<DocumentPreRequirement> LoadByFilter(IFilterDataSource request,
        //                                   out int totalRecords)
        //{
        //    //IQueryable<Document> objects = FindAll(x => x.LastOwner.Title.Contains(request.keyword) ||
        //    //                                            x.PlateOwner.Title.Contains(request.keyword) ||
        //    //                                            x.Vehicle.VehicleTip.System.Contains(request.keyword) ||
        //    //                                            x.Vehicle.Plate.Number.Contains(request.keyword),
        //    //                                            y => y.LastOwner,
        //    //                                            y => y.PlateOwner,
        //    //                                            y => y.Vehicle,
        //    //                                            y => y.Vehicle.Plate,
        //    //                                            y => y.Vehicle.VehicleTip,
        //    //                                            y => y.CostCollection,
        //    //                                            y => y.DocumentStatusCollection.Select(_ => _.Status.Operation),
        //    //                                            y => y.DocumentStatusCollection.Select(_ => _.Status.Form)
        //    //                                         ).AsQueryable();
        //    totalRecords = objects.Count();
        //    return objects.OrderBy(BuildOrderBy(request.sort.Key, request.sort.Value.ToString())).Skip((request.page * request.pageSize) - request.pageSize).Take(request.pageSize);
        //}

        //private string BuildOrderBy(string sortOn, string sortDirection)
        //{
        //    return string.Format("{0} {1}", sortOn, sortDirection);
        //}
    }
}
