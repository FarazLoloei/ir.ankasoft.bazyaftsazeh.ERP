using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class ObjectiveRepository : Repository<Objective>, IObjectiveRepository
    {
        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }
}