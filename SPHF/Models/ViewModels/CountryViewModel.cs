using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models.ViewModels
{
    public class CountryViewModel
    {
        public List<Country> Countries { get; set; }


        public CountryViewModel() { Countries = new List<Country>(); }
    }
}
