using System;
using System.Collections.Generic;

namespace PersonPortal.Data.DbModels
{
    public partial class Person
    {
        public Person()
        {
            PersonPhone = new HashSet<PersonPhone>();
            PersonToPersonPerson = new HashSet<PersonToPerson>();
            PersonToPersonRelatedPerson = new HashSet<PersonToPerson>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderiD { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int? CityId { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }

        public virtual City City { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<PersonPhone> PersonPhone { get; set; }
        public virtual ICollection<PersonToPerson> PersonToPersonPerson { get; set; }
        public virtual ICollection<PersonToPerson> PersonToPersonRelatedPerson { get; set; }
    }
}
