using ir.ankasoft.entities;
using ir.ankasoft.entities.Enums;
using ir.ankasoft.entities.Repositories;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class PostalAddressRepository : Repository<PostalAddress>, IPostalAddressRepository
    {
        public void changePrimary(long id, PartyObjective ObjectiveType, bool status)
        {
            using (new EFUnitOfWorkFactory().Create())
            {
                var _postalAddress = FindById(id);
                IEnumerable<PostalAddress> list = new List<PostalAddress>();
                switch (ObjectiveType)
                {
                    case PartyObjective.Party:
                        list = FindAll(_ => _.PartyRefRecId == _postalAddress.PartyRefRecId && _.Type == _postalAddress.Type);
                        break;

                    case PartyObjective.Person:
                        list = FindAll(_ => _.PersonRefRecId == _postalAddress.PersonRefRecId && _.Type == _postalAddress.Type);
                        break;

                    case PartyObjective.Importer:
                        list = FindAll(_ => _.ImporterRefRecId == _postalAddress.ImporterRefRecId && _.Type == _postalAddress.Type);
                        break;

                    case PartyObjective.Organization:
                        list = FindAll(_ => _.OrganizationRefRecId == _postalAddress.OrganizationRefRecId && _.Type == _postalAddress.Type);
                        break;
                }
                if (status)
                {
                    foreach (var item in list)
                    {
                        if (item.recId == _postalAddress.recId)
                            item.IsPrimary = true;
                        else
                            item.IsPrimary = false;
                    }
                }
                else
                    _postalAddress.IsPrimary = status;
            }
        }
    }
}