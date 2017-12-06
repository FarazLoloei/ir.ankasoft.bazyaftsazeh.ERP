using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IDocumentImperfectionRepository : IRepository<DocumentImperfection, long>
    {
        new IEnumerable<DocumentImperfection> LoadByFilter(IFilterDataSource request,
                                                   out int totalRecords);
    }
}