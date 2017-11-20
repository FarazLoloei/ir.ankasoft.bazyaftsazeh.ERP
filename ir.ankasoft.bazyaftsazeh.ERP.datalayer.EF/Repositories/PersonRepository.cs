using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public override IEnumerable<Person> LoadByFilter(IFilterDataSource request,
                                           out int totalRecords)
        {
            IQueryable<Person> objects = FindAll(x => x.Name.Contains(request.keyword) ||
                                                      x.Family.Contains(request.keyword), y => y.Party
                                                     ).AsQueryable();
            totalRecords = objects.Count();
            return objects.OrderBy(BuildOrderBy(request.sort.Key, request.sort.Value.ToString())).Skip((request.page * request.pageSize) - request.pageSize).Take(request.pageSize);
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }

        public Dictionary<long, string> GetForSelectors(string filter)
        {
            filter = filter ?? string.Empty;
            return FindAll(_ => _.Name.Contains(filter) || _.Family.Contains(filter)).ToDictionary(x => x.recId, x => $"{x.FullName}");
        }
    }
}