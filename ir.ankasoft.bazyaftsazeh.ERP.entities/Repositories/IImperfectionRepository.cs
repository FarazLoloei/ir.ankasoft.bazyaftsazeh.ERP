using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IImperfectionRepository : IRepository<Imperfection, long>
    {
        new IEnumerable<Imperfection> LoadByFilter(IFilterDataSource request,
                                               out int totalRecords);
    }
}