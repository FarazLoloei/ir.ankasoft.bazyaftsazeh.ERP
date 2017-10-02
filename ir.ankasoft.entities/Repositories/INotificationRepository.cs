using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.entities.Repositories
{
    public interface INotificationRepository : IRepository<Notification, long>
    {
        new IEnumerable<Notification> LoadByFilter(string keyword,
                                                   string sort,
                                                   string sortDir,
                                                   out int totalRecords);

        IEnumerable<Notification> GetLatestActivities(int count = 5);
    }
}
