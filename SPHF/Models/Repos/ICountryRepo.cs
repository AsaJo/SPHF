using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.Repos
{
    public interface ICountryRepo
    {
        Country Create(Country country);
        List<Country> GetAll();
        Country FindById(int id);

        bool Update(Country country);
        bool Delete(Country country);
    }
}

