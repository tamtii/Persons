using PersonPortal.Contracts.Models;
using System.Collections.Generic;

namespace PersonPortal.Contracts.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        ICollection<PersonModel> GetPersons();
        PersonModel GetPersonById(int id);
        void UpdatePerson(PersonModel person);
        void DeleteRelatedPerson(PersonModel person, PersonModel relatedPerson);
        void AddRelatedPerson(PersonModel person, PersonModel relatedPerson,int relationTypeId);
        ICollection<RelationTypeModel> GetPersonRelationTypes();
        int CreatePerson(PersonModel person);
        ICollection<PhoneTypeModel> GetPhoneTypes();
    }
}
