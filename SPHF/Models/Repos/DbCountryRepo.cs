using SPHF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.Repos
{
    public class DbCountryRepo : ICountryRepo
    {
        readonly TankDbContext _tankDbContext;// Step 7
        public DbCountryRepo(TankDbContext tankDbContext)
        {
            _tankDbContext = tankDbContext;
        }
        public Country Create(Country country)
        {

            _tankDbContext.Countries.Add(country);
            _tankDbContext.SaveChanges();
            return country;
        }

        public List<Country> GetAll()
        {
            List<Country> countryList = _tankDbContext.Countries.ToList();
            return countryList;
        }

        public Country FindById(int id)
        {
            return _tankDbContext.Countries.Find(id);
        }
        public bool Update(Country country)
        {
            _tankDbContext.Countries.Update(country);
            int countryUp = _tankDbContext.SaveChanges();

            if (countryUp > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(Country country)
        {
            _tankDbContext.Countries.Remove(country);
            int countryDel = _tankDbContext.SaveChanges();

            if (countryDel > 0)
            {
                return true;
            }
            return false;
        }
    }
}
