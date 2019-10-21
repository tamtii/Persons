using PersonPortal.Contracts.Interfaces.Repositories;
using PersonPortal.Contracts.Interfaces.Services;
using PersonPortal.Contracts.Models;
using System;
using System.Collections.Generic;

namespace PersonPortal.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public ICollection<PersonModel> GetPersons()
        {
            return _personRepository.GetPersons();
        }

        public PersonModel GetPersonById(int id)
        {
            return _personRepository.GetPersonById(id);
        }

        public void UpdatePerson(PersonModel person)
        {
            _personRepository.UpdatePerson(person);
        }

        public void DeleteRelatedPerson(PersonModel person, PersonModel relatedPerson)
        {
            _personRepository.DeleteRelatedPerson(person, relatedPerson);
        }

        public void AddRelatedPerson(PersonModel person, PersonModel relatedPerson, int relationTypeId)
        {
            _personRepository.AddRelatedPerson(person, relatedPerson, relationTypeId);
        }

        public ICollection<RelationTypeModel> GetPersonRelationTypes()
        {
            return _personRepository.GetPersonRelationTypes();
        }

        public int CreatePerson(PersonModel person)
        {
            return _personRepository.CreatePerson(person);
        }

        public ICollection<PhoneTypeModel> GetPhoneTypes()
        {
            return _personRepository.GetPhoneTypes();
        }
    }
}
