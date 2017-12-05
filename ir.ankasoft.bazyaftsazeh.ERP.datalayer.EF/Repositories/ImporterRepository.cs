using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class ImporterRepository : Repository<Importer>, IImporterRepository
    {
        public override IEnumerable<Importer> LoadByFilter(IFilterDataSource request,
                                           out int totalRecords)
        {
            IQueryable<Importer> objects = FindAll(x => x.Name.Contains(request.keyword) ||
                                                      x.Family.Contains(request.keyword) ||
                                                      x.ImporterNumber.Contains(request.keyword), y => y.Party
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
            return FindAll(_ => _.Name.Contains(filter) || _.Family.Contains(filter) || _.ImporterNumber.Contains(filter))
                .ToDictionary(x => x.recId, x => $"{x.FullName} - {x.ImporterNumber}");
        }
    }
}