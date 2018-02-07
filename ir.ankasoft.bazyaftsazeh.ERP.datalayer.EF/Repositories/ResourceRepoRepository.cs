using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class ResourceRepoRepository : Repository<ResourceRepo>, IResourceRepoRepository
    {
        public IEnumerable<ResourceRepo> GetDocumentResources(long documentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResourceRepo> GetDocumentResources(long documentId, long statusId)
        {
            throw new NotImplementedException();
        }
    }
}
