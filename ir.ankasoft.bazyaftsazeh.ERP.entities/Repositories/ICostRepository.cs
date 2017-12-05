using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface ICostRepository : IRepository<Cost, long>
    {
        new IEnumerable<Cost> LoadByFilter(IFilterDataSource request,
                                               out int totalRecords);
    }
}