using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.tools;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IPartyRepository : IRepository<Party, long>
    {
        IEnumerable<Party> LoadByFilter(PageFilterDataSource request,
                                        out int totalRecords);

        new void Add(Party entity);
    }
}