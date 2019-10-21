using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonPortal.Contracts.Models;

namespace PersonPortal.ClientSite.Models
{
    public class AddPersonViewModel
    {
        public int Id { get; set; }
        public List<RelationTypeModel> RelationTypes { get; set; }
        public List<PersonModel> RelatedPersons { get; set; }

        public int RelatedPersonId { get; set; }
        public int RelationTypeId { get; set; }
    }
}
