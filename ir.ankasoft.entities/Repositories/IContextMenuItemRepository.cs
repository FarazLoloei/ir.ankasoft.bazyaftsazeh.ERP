using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.entities.Repositories
{
    public interface IContextMenuItemRepository : IRepository<ContextMenuItem, long>
    {
        IEnumerable<ContextMenuItem> GetContextMenu(string controller, bool containHeaderItems = false, bool containRowItems = true);
    }
}