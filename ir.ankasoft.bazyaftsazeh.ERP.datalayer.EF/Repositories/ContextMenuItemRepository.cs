using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class ContextMenuItemRepository : Repository<ContextMenuItem>, IContextMenuItemRepository
    {
        public IEnumerable<ContextMenuItem> GetContextMenu(string controller, bool containHeaderItems = false, bool containRowItems = true)
        {
            IEnumerable<ContextMenuItem> menu = FindAll(x => x.Objective.Title == controller &&
                                                             x.Objective.Type == ankasoft.entities.Enums.ObjectiveType.Controller &&
                                                             (x.ShowOnHeader == containHeaderItems || x.ShowOnRow == containRowItems));
            menu = menu.OrderBy(_ => _.GroupCode)
                       .ThenBy(_ => _.Priority);
            if (containHeaderItems)
                menu = menu.Select(_ => { _.Disable = _.DisableOnHeader; return _; });
            else
                menu = menu.Select(_ => { _.Disable = _.DisableOnRow; return _; });
            //collection.Select(c => { c.PropertyToSet = value; return c; }).ToList();
            return menu;
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }
}