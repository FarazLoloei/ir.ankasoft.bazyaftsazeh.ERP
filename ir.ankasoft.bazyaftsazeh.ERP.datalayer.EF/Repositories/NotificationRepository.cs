using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public override IEnumerable<Notification> LoadByFilter(string keyword,
                                        int currentPage,
                                        int pageSize,
                                        string sort,
                                        string sortDir,
                                        out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetLatestActivities(int count = 5)
        {
            string sort = "PublishDate", sortDir = "DESC";
            IEnumerable<Notification> allNotifications = FindAll().OrderByDescending(x => x.PublishDate);
            allNotifications = allNotifications.Take(count);

            return allNotifications.OrderBy(BuildOrderBy(sort, sortDir));
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }
}