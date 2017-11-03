using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle, long>
    {
        new IEnumerable<Vehicle> LoadByFilter(IFilterDataSource request,
                                              out int totalRecords);
    }
}