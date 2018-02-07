using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IResourceRepoRepository : IRepository<ResourceRepo, long>
    {
        IEnumerable<ResourceRepo> GetDocumentResources(long documentId);

        IEnumerable<ResourceRepo> GetDocumentResources(long documentId, long statusId);
    }
}