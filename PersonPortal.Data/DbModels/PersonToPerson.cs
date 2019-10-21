using System;
using System.Collections.Generic;

namespace PersonPortal.Data.DbModels
{
    public partial class PersonToPerson
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public int? RelatedPersonId { get; set; }
        public int? RelationTypeId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Person RelatedPerson { get; set; }
        public virtual RelationTypes RelationType { get; set; }
    }
}
