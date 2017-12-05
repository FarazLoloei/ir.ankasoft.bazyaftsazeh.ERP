using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class PreDefineTitleRepository : Repository<PreDefineTitle>, IPreDefineTitleRepository
    {
        public override IEnumerable<PreDefineTitle> LoadByFilter(IFilterDataSource request,
                                           out int totalRecords)
        {
            IQueryable<PreDefineTitle> objects = FindAll(x => x.Title.Contains(request.keyword)).AsQueryable();
            totalRecords = objects.Count();
            return objects.OrderBy(BuildOrderBy(request.sort.Key, request.sort.Value.ToString())).Skip((request.page * request.pageSize) - request.pageSize).Take(request.pageSize);
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }

        public PreDefineTitle FindByTitle(string title)
        {
            return FindAll(x => x.Title == title).FirstOrDefault();
        }
    }
}