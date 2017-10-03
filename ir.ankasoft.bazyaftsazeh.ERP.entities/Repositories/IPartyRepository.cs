using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IPartyRepository : IRepository<Party, long>
    {
        IEnumerable<Party> LoadByFilter(string keyword,
                                        int currentPage,
                                        int pageSize,
                                        string sort,
                                        string sortDir,
                                        out int totalRecords);

        new void Add(Party entity);
    }
}