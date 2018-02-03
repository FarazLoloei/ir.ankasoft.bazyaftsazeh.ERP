﻿using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IOperationsAttributeRepository : IRepository<OperationsAttribute, long>
    {
        new IEnumerable<OperationsAttribute> LoadByFilter(IFilterDataSource request,
                                              out int totalRecords);

        IEnumerable<OperationsAttribute> GetOperationsAttribute(long operationId);

    }
}
