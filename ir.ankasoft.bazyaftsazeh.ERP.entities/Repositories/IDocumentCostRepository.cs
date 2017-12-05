using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IDocumentCostRepository : IRepository<DocumentCost, long>
    {
        new IEnumerable<DocumentCost> LoadByFilter(IFilterDataSource request,
                                                   out int totalRecords);
    }
}