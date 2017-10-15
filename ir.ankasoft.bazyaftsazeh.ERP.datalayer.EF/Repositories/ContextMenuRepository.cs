using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class ContextMenuRepository : Repository<ContextMenu>, IContextMenuRepository
    {
        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }

    public class ContextMenuItemRepository : Repository<ContextMenuItem>, IContextMenuItemRepository
    {
        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }
}
