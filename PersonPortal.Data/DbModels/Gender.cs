using System;
using System.Collections.Generic;

namespace PersonPortal.Data.DbModels
{
    public partial class Gender
    {
        public Gender()
        {
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
