using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.entities.Repositories
{
    public interface IContextMenuRepository : IRepository<ContextMenu, long>
    {

    }

    public interface IContextMenuItemRepository : IRepository<ContextMenuItem, long>
    {

    }
}
