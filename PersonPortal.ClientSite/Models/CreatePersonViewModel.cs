using PersonPortal.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonPortal.ClientSite.Models
{
    public class CreatePersonViewModel
    {
        public PersonModel Person { get; set; }
        public ICollection<CityModel> Cities { get; set; }
        public ICollection<PersonModel> Persons { get; set; }
        public int PersonId { get; set; }
        public int CityId { get; set; }
    }
}
