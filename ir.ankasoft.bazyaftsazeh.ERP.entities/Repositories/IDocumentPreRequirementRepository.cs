using ir.ankasoft.infrastructure;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories
{
    public interface IDocumentPreRequirementRepository : IRepository<DocumentPreRequirement, long>
    {
        //new IEnumerable<DocumentPreRequirement> LoadByFilter(IFilterDataSource request,
        //                                                     out int totalRecords);
    }
}