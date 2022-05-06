using SPHF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.Services
{
    public interface ITankService
    {
        Tank Create(TankCreateViewModel createTank);
        List<Tank>GetAll();
        Tank FindById(int id);
        List<Tank> Search(string search);
       
        bool Edit(int id,TankCreateViewModel editTank);
        void Remove(int id);

    }
}
