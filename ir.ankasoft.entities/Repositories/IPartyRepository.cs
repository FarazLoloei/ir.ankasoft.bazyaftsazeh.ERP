using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.entities.Repositories
{
    public interface IPartyRepository : IRepository<Party, long>
    {
        new IEnumerable<Party> LoadByFilter(IFilterDataSource request,
                                        out int totalRecords);

        new void Add(Party entity);

        bool CheckExistingNationalCode(string nationalCode);
    }
}