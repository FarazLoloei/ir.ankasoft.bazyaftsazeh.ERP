﻿using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public override IEnumerable<Document> LoadByFilter(IFilterDataSource request,
                                           out int totalRecords)
        {

            IQueryable<Document> objects = FindAll(x => x.LastOwner.FullName.Contains(request.keyword) ||
                                                        x.PlateOwner.FullName.Contains(request.keyword)
                                                     ).AsQueryable();
            totalRecords = objects.Count();
            return objects.OrderBy(BuildOrderBy(request.sort.Key, request.sort.Value.ToString())).Skip((request.page * request.pageSize) - request.pageSize).Take(request.pageSize);
        }

        private string BuildOrderBy(string sortOn, string sortDirection)
        {
            return string.Format("{0} {1}", sortOn, sortDirection);
        }
    }
}