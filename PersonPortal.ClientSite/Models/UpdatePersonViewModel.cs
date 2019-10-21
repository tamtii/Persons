using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonPortal.Contracts.Models;

namespace PersonPortal.ClientSite.Models
{
    public class UpdatePersonViewModel
    {
        public PersonModel Person { get; set; }
        public ICollection<CityModel> Cities { get; set; }
        public ICollection<PersonModel> Persons { get; set; }
    }
}
