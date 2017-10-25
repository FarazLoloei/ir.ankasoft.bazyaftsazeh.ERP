using ir.ankasoft.entities.Enums;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.entities.Repositories
{
    public interface IPostalAddressRepository : IRepository<PostalAddress, long>
    {
        void changePrimary(long id, PartyObjective ObjectiveType, bool status);
    }
}
