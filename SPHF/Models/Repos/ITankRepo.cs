using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.Repos
{
    public interface ITankRepo
    {
        Tank Create(Tank tank);
        List<Tank> GetAll();
        Tank FindById(int id);

        bool Update(Tank tank);
        void Delete(Tank tank);
    }
}
