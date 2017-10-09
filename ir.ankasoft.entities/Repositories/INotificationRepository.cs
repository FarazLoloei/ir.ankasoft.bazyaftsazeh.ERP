using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.entities.Repositories
{
    public interface INotificationRepository : IRepository<Notification, long>
    {
        new IEnumerable<Notification> LoadByFilter(IFilterDataSource request,
                                        out int totalRecords);

        IEnumerable<Notification> GetLatestActivities(int count = 5);
    }
}