using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;

namespace ir.ankasoft.entities.Repositories
{
    public interface ICityRepository : IRepository<City, long>
    {
        IEnumerable<Tuple<string, string>> GetProvinceCity(string keyword);
    }
}