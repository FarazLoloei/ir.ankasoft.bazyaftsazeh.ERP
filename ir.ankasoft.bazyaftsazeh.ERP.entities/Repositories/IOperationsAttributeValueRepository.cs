using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IOperationsAttributeValueRepository : IRepository<OperationsAttributeValue, long>
    {
        new IEnumerable<OperationsAttributeValue> LoadByFilter(IFilterDataSource request,
                                              out int totalRecords);
    }
}
