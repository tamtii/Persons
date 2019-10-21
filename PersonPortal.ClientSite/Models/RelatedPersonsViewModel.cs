using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonPortal.Contracts.Models;

namespace PersonPortal.ClientSite.Models
{
    public class RelatedPersonsViewModel
    {
        public int ID { get; set; }
        public List<PersonModel> RelatedPersons { get; set; }
    }
}
