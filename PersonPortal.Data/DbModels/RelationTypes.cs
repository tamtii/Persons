using System;
using System.Collections.Generic;

namespace PersonPortal.Data.DbModels
{
    public partial class RelationTypes
    {
        public RelationTypes()
        {
            PersonToPerson = new HashSet<PersonToPerson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonToPerson> PersonToPerson { get; set; }
    }
}
