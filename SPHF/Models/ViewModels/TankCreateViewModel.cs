using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.ViewModels
{
    public class TankCreateViewModel
    {
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Tank info")]
        [Required]
        public string TankInfo { get; set; }
        public TankCreateViewModel()
        {

        }
        public TankType TankType { get; set; }
        public int CountryId { get; set; }

        public List<Country> Countries { get; set; }
    }
}

