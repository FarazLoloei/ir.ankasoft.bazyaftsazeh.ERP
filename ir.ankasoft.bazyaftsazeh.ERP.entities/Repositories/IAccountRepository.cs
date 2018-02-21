using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IAccountRepository : IRepository<ApplicationUser, long>
    {
        new IEnumerable<ApplicationUser> LoadByFilter(IFilterDataSource request,
                                                      out int totalRecords);
    }
}
