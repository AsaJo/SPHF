using SPHF.Models.Repos;
using SPHF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.Services
{
    public class TankService : ITankService
    {
        ITankRepo _tankRepo;
        ICountryRepo _countryRepo;
        public TankService(ITankRepo tankRepo, ICountryRepo countryRepo)
        {
            _tankRepo = tankRepo;
            _countryRepo = countryRepo;
        }

        public Tank Create(TankCreateViewModel createTank)
        {
            if (string.IsNullOrWhiteSpace(createTank.Name))

            {
                throw new ArgumentException("Name, Tank info or Country, not be consist of backspace(s)/whitespace(s)");
            }
            Tank tank = new Tank()
            {
                Name = createTank.Name,
                TankInfo = createTank.TankInfo,
                TankType = createTank.TankType,
                CountryId = createTank.CountryId
            };
            _tankRepo.Create(tank);
            return tank;
        }

        public List<Tank> GetAll()
        {
            List<Tank> tanks = _tankRepo.GetAll();
            foreach (var item in tanks)
            {
                item.Country = null;
                    
            }
            return tanks;
            //return _tankRepo.GetAll();
        }

        public bool Edit(int id,TankCreateViewModel editTank)
        {
            Tank tank = _tankRepo.FindById(id);
            if (tank != null)
            {
                tank.Name = editTank.Name;
                tank.CountryId = editTank.CountryId;
                tank.TankInfo = editTank.TankInfo;
                tank.TankType = editTank.TankType;
            }
            return _tankRepo.Update(tank);
        }

        public Tank FindById(int id)
        {
            Tank foundTank = _tankRepo.FindById(id);

            return foundTank;
        }

        public void Remove(int id)
        {
            Tank tankToDelete = _tankRepo.FindById(id);
            if (tankToDelete != null)
            {
                _tankRepo.Delete(tankToDelete);
            }
        }

        public List<Tank> Search(string search)
        {
            List<Tank> searchTank = _tankRepo.GetAll();
            //
            foreach (Tank item in _tankRepo.GetAll())
            {
                if (item.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    searchTank.Add(item);
                }
            }
            //searchPerson = searchPerson.Where(p => p.Name.ToUpper().Contains(search.ToUpper()) || p.City.Contains(search.ToUpper())).ToList();
            if (searchTank.Count == 0)
            {
                throw new ArgumentException("Could not find what you where looking for");
            }
            return searchTank;
        }
    }
}

    

