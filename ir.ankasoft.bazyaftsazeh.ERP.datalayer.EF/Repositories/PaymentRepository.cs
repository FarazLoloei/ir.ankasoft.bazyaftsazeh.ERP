using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public override IEnumerable<Payment> LoadByFilter(IFilterDataSource request,
                                                          out int totalRecords)
        {
            IQueryable<Payment> objects = FindAll(x => x.Title.Contains(request.keyword),
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