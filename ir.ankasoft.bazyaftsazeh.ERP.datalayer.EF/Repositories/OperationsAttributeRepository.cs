using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class OperationsAttributeRepository : Repository<OperationsAttribute>, IOperationsAttributeRepository
    {
        public new  IEnumerable<OperationsAttribute> LoadByFilter(IFilterDataSource request,
                                              out int totalRecords)
        {
            totalRecords = 0;
            return new List<OperationsAttribute>();
        }

        public IEnumerable<OperationsAttribute> GetOperationsAttribute(long operationId)
        {
            return FindAll(_ => _.OperationRefRecId == operationId);
        }
    }
}
