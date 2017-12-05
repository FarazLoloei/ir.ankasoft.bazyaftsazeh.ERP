using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IDocumentRepository : IRepository<Document, long>
    {
        new IEnumerable<Document> LoadByFilter(IFilterDataSource request,
                                               out int totalRecords);
    }
}