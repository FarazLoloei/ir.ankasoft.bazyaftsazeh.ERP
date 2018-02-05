using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IDocumentOperationRepository : IRepository<DocumentOperation, long>
    {
        new IEnumerable<DocumentOperation> LoadByFilter(IFilterDataSource request,
                                                        out int totalRecords);

        IEnumerable<DocumentOperation> getAll();
    }
}