using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class DocumentStatusRepository : Repository<City>, ICityRepository
    {
        public IEnumerable<Tuple<string, string>> GetProvinceCity(string cityTitle)
        {
            IEnumerable<City> cities = FindAll(_ => _.Title.Contains(cityTitle), y => y.Province);
            //using (var c = new ApplicationDbContext())
            //{
            //    var q = (from s in c.Cities.Include("province")
            //             where s.Title.Contains(cityTitle)
            //             select s);
            //}
            //var query = (from c in new ApplicationDbContext().Cities
            //            where c.Title.Contains(cityTitle)

            //            select c)
            //            ;
            return cities.Select(_ =>
            {
                return new Tuple<string, string>($"{_.Title} - {_.Province.Title}", $"{_.recId},{_.ProvinceRefRecID}");
            });
        }
    }
}