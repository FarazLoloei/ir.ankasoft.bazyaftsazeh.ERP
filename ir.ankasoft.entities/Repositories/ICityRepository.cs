﻿using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.entities.Repositories
{
    public interface ICityRepository : IRepository<City, long>
    {
        IEnumerable<Tuple<string, string>> GetProvinceCity(string keyword);
    }
}
