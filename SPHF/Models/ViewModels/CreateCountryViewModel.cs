using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "Country")]
        public string CountryName { get; set; }
        public List<Tank> TankList { get; set; }
      
    }
}
