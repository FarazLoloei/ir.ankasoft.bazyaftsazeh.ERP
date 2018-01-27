using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public override IEnumerable<Vehicle> LoadByFilter(IFilterDataSource request,
                                           out int totalRecords)
        {
            throw new NotImplementedException();
            //IQueryable<Vehicle> objects = FindAll(
            //                                         //x => x.Name.Contains(request.keyword) ||
            //                                         //                                      x.Family.Contains(request.keyword), y => y.Party
            //                                         ).AsQueryable();
            //totalRecords = objects.Count();
            //return objects.OrderBy(BuildOrderBy(request.sort.Key, request.sort.Value.ToString())).Skip((request.page * request.pageSize) - request.pageSize).Take(request.pageSize);
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }
}