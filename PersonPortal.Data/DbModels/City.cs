using System;
using System.Collections.Generic;

namespace PersonPortal.Data.DbModels
{
    public partial class City
    {
        public City()
        {
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
