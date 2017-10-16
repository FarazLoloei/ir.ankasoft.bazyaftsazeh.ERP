using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.entities.Repositories
{
    public interface IContextMenuItemRepository : IRepository<ContextMenuItem, long>
    {
        IEnumerable<ContextMenuItem> GetContextMenu(string controller, bool containHeaderItems = false, bool containRowItems = true);
    }
}
