using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IPlateRepository : IRepository<Plate, long>
    {
        new IEnumerable<Plate> LoadByFilter(IFilterDataSource request,
                                               out int totalRecords);
    }
}