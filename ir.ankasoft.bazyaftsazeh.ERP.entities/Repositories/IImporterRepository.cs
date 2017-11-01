using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IImporterRepository : IRepository<Importer, long>
    {
        new IEnumerable<Importer> LoadByFilter(IFilterDataSource request,
                                               out int totalRecords);
    }
}