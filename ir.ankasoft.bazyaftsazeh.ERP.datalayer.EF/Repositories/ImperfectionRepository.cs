using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class ImperfectionRepository : Repository<Imperfection>, IImperfectionRepository
    {
        public override IEnumerable<Imperfection> LoadByFilter(IFilterDataSource request,
                                           out int totalRecords)
        {
            IQueryable<Imperfection> objects = FindAll(x => x.Title.Title.Contains(request.keyword),
                                               y => y.Title).AsQueryable();
            totalRecords = objects.Count();
            return objects.OrderBy(BuildOrderBy(request.sort.Key, request.sort.Value.ToString())).Skip((request.page * request.pageSize) - request.pageSize).Take(request.pageSize);
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return tools.Utility.LinqHelper.LinqOrderByBuilder(sortOn, sortDirection);
        }
    }
}