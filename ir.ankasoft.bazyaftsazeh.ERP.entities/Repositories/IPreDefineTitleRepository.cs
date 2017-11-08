using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IPreDefineTitleRepository : IRepository<PreDefineTitle, long>
    {
        new IEnumerable<PreDefineTitle> LoadByFilter(IFilterDataSource request,
                                               out int totalRecords);

        PreDefineTitle FindByTitle(string title);
    }
}