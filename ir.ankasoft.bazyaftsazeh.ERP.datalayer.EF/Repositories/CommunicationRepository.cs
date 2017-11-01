using ir.ankasoft.entities;
using ir.ankasoft.entities.Enums;
using ir.ankasoft.entities.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class CommunicationRepository : Repository<Communication>, ICommunicationRepository
    {
        public void changePrimary(long id, bool status)
        {
            using (new EFUnitOfWorkFactory().Create())
            {
                var _communication = FindById(id);
                IEnumerable<Communication> list = new List<Communication>();
                if (_communication.PartyRefRecId != null)
                    list = FindAll(_ => _.PartyRefRecId == _communication.PartyRefRecId && _.CommunicationType == _communication.CommunicationType);
                else if (_communication.PersonRefRecId != null)
                    list = FindAll(_ => _.PersonRefRecId == _communication.PersonRefRecId && _.CommunicationType == _communication.CommunicationType);
                else if (_communication.ImporterRefRecId != null)
                    list = FindAll(_ => _.ImporterRefRecId == _communication.ImporterRefRecId && _.CommunicationType == _communication.CommunicationType);
                else
                    list = FindAll(_ => _.OrganizationRefRecId == _communication.OrganizationRefRecId && _.CommunicationType == _communication.CommunicationType);
                if (status)
                {
                    foreach (var item in list)
                    {
                        if (item.recId == _communication.recId)
                            item.IsPrimary = true;
                        else
                            item.IsPrimary = false;
                    }
                }
                else
                    _communication.IsPrimary = status;
            }

        }
    }
}