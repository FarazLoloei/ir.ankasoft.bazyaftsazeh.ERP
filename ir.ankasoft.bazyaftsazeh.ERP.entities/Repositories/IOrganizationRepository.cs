using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IOrganizationRepository : IRepository<Organization, long>
    {
        new IEnumerable<Organization> LoadByFilter(IFilterDataSource request,
                                             out int totalRecords);

        Dictionary<long, string> GetForSelectors(string filter);
    }
}