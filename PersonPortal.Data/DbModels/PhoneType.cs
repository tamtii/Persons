using System;
using System.Collections.Generic;

namespace PersonPortal.Data.DbModels
{
    public partial class PhoneType
    {
        public PhoneType()
        {
            PersonPhone = new HashSet<PersonPhone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonPhone> PersonPhone { get; set; }
    }
}
