using System;
using System.Collections.Generic;

namespace PersonPortal.Data.DbModels
{
    public partial class PersonPhone
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public int? PhoneTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Person Person { get; set; }
        public virtual PhoneType PhoneType { get; set; }
    }
}
