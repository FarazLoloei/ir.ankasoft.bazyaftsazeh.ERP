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

        public override IEnumerable<Party> LoadByFilter(IFilterDataSource request,
                                           out int totalRecords)
        {
            long partyNumber = 0;
            long.TryParse(request.keyword, out partyNumber);

            IQueryable<Party> parties = FindAll(x => x.Title.Contains(request.keyword) ||
                                                     x.NationalCode.Contains(request.keyword)
                                                     ).AsQueryable();
            totalRecords = parties.Count();
            return parties.OrderBy(BuildOrderBy(request.sort.Key, request.sort.Value.ToString())).Skip((request.page * request.pageSize) - request.pageSize).Take(request.pageSize);
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }

        public bool CheckExistingNationalCode(string nationalCode)
        {
            return FindAll(_ => _.NationalCode == nationalCode).Count() > 0 ? true : false;
        }

        public override void Remove(long id)
        {
            Party _party = FindById(id);
            foreach (var item in _party.CommunicationCollection)
            {
                new CommunicationRepository().Remove(item);
            }
            foreach (var item in _party.PostalAddressCollection)
            {
                new PostalAddressRepository().Remove(item);
            }
            base.Remove(id);
        }

        public Dictionary<long, string> GetForSelectors(string filter)
        {
            filter = filter ?? string.Empty;
            return FindAll(_ => _.NationalCode.Contains(filter) || _.Title.Contains(filter)).ToDictionary(x => x.recId, x => $"{x.Title} - {x.NationalCode}");
        }
    }

    
}