﻿using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.entities.Repositories
{
    public interface IProvinceRepository : IRepository<Province, long>
    {
        //new IEnumerable<Party> GetProvinceCity(string  keyword);
    }
}
