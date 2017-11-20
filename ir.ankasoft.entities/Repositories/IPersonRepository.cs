using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.entities.Repositories
{
    public interface IPersonRepository : IRepository<Person, long>
    {
        new IEnumerable<Person> LoadByFilter(IFilterDataSource request,
                                             out int totalRecords);

        Dictionary<long, string> GetForSelectors(string filter);
    }
}