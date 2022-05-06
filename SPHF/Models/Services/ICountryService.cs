using SPHF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.Services
{
    public interface ICountryService
    {
        Country Create(CreateCountryViewModel country);
        List<Country> GetAll();
        Country FindById(int id);
        
        List<Country> Search(string search);
        bool Edit(int id,CreateCountryViewModel editountry);
        bool Remove(int id);
    }
}
