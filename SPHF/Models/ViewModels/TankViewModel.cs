using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.ViewModels
{
    public class TankViewModel:TankCreateViewModel
    {
        public List<Tank> TanksList { get; set; }

        public string Search { get; set; }

        public TankViewModel()
        {
            TanksList = new List<Tank>();
        }

    }
}
