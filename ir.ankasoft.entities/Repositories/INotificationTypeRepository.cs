using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.entities.Repositories
{
    public interface INotificationTypeRepository : IRepository<NotificationType, long>
    {
        new IEnumerable<NotificationType> LoadByFilter(string keyword,
                                                       string sort,
                                                       string sortDir,
                                                       out int totalRecords);
    }
}
