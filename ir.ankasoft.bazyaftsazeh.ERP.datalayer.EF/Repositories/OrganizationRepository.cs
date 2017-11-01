using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public override IEnumerable<Organization> LoadByFilter(IFilterDataSource request,
                                           out int totalRecords)
        {
            IQueryable<Organization> objects = FindAll(x => x.Title.Contains(request.keyword) ||
                                                      x.RegistrationNumber.Contains(request.keyword) ||
                                                      x.RegistrationPlace.Contains(request.keyword) ||
                                                      x.CommercialNumber.Contains(request.keyword), y => y.Party
                                                      ).AsQueryable();
            totalRecords = objects.Count();
            return objects.OrderBy(BuildOrderBy(request.sort.Key, request.sort.Value.ToString())).Skip((request.page * request.pageSize) - request.pageSize).Take(request.pageSize);
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }
}