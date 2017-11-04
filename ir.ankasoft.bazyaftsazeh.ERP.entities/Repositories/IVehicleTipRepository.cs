using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IVehicleTipRepository : IRepository<VehicleTip, long>
    {
        new IEnumerable<VehicleTip> LoadByFilter(IFilterDataSource request,
                                              out int totalRecords);
    }
}