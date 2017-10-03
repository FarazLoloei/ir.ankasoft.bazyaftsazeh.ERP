using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class PartyRepository : Repository<Party>, IPartyRepository
    {

        public new void Add(Party entity)
        {

            DataContextFactory.GetDataContext().Set<Party>().Add(entity);
        }

        public IEnumerable<Party> LoadByFilter(string keyword,
                                           int currentPage,
                                           int pageSize,
                                           string sort,
                                           string sortDir,
                                           out int totalRecords)
        {
            long partyNumber = 0;
            long.TryParse(keyword, out partyNumber);

            IQueryable<Party> parties = FindAll(x => x.Title.Contains(keyword) ||
                                                               x.NationalCode.Contains(keyword))
                                                         .AsQueryable();
            totalRecords = parties.Count();
            return parties.OrderBy(BuildOrderBy(sort, sortDir)).Skip((currentPage * pageSize) - pageSize).Take(pageSize);
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }
}
