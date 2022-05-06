using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPHF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.Repos
{
    public class DbTankRepo : ITankRepo
    {
        readonly TankDbContext _tankDbContext;
        public DbTankRepo(TankDbContext tankDbContext)
        {
            _tankDbContext = tankDbContext;

        }
        
        public Tank Create(Tank tank)
        {
            _tankDbContext.Tanks.Add(tank);
            _tankDbContext.SaveChanges();
            return tank;
        }

        public List<Tank> GetAll()
        {
            return _tankDbContext.Tanks.Include(tank => tank.Country).ToList();
        }

        public Tank FindById(int id)
        {
            return _tankDbContext.Tanks.Include(tank => tank.Country).SingleOrDefault(tank => tank.Id == id);
        }

        public bool Update(Tank tank)
        {
            _tankDbContext.Tanks.Update(tank);
            int result = _tankDbContext.SaveChanges();
            if (result == 0)
            {
                return false;

            }
            return true;
        }
        public void Delete(Tank tank)
        {
            _tankDbContext.Tanks.Remove(tank);
            _tankDbContext.SaveChanges();
        }
    }
}
