using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class PartyRepository : Repository<Party>, IPartyRepository
    {
        public new void Add(Party entity)
        {
            DataContextFactory.GetDataContext().Set<Party>().Add(entity);
        }

        public IEnumerable<Party> LoadByFilter(IFilterDataSource request,
                                           out int totalRecords)
        {
            long partyNumber = 0;
            long.TryParse(request.keyword, out partyNumber);

            IQueryable<Party> parties = FindAll(x => x.Title.Contains(request.keyword) ||
                                                     x.NationalCode.Contains(request.keyword)
                                                     ).AsQueryable()
                                                     //.Select()
                                                     ;
            //IQueryable<Party> party = DataContextFactory.GetDataContext().Set<Party>();
            //IQueryable<Communication> communication = DataContextFactory.GetDataContext().Set<Communication>();

            //var s = from p in party
            //        join c in communication on p.recId equals c.PartyRefRecId
            //        select new Party() {
            //            recId = p.recId,
            //            Title = p.Title,
            //            NationalCode = p.NationalCode,
            //            Description = p.Description,
            //            PersonalTitle =p.PersonalTitle,
            //           CommunicationCollection = new Communication()
            //           {
            //               CommunicationType = c.CommunicationType,

            //           }
            //      }

            totalRecords = parties.Count();
            return parties.OrderBy(BuildOrderBy(request.sort.Key, request.sort.Value.ToString())).Skip((request.page * request.pageSize) - request.pageSize).Take(request.pageSize);
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }
}