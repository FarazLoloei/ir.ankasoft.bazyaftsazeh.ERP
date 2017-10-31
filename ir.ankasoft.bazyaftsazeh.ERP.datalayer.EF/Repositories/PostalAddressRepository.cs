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
                if (_postalAddress.PartyRefRecId != null)
                    list = FindAll(_ => _.PartyRefRecId == _postalAddress.PartyRefRecId && _.Type == _postalAddress.Type);
                else if (_postalAddress.PersonRefRecId != null)
                    list = FindAll(_ => _.PersonRefRecId == _postalAddress.PersonRefRecId && _.Type == _postalAddress.Type);
                else if (_postalAddress.ImporterRefRecId != null)
                    list = FindAll(_ => _.ImporterRefRecId == _postalAddress.ImporterRefRecId && _.Type == _postalAddress.Type);
                else
                    list = FindAll(_ => _.OrganizationRefRecId == _postalAddress.OrganizationRefRecId && _.Type == _postalAddress.Type);

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