using System;
using PersonPortal.Contracts.Interfaces.Repositories;
using PersonPortal.Contracts.Models;
using PersonPortal.Data.DbModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PersonPortal.Repository
{
    public class PersonRepository : IPersonRepository
    {
        public ICollection<PersonModel> GetPersons()
        {
            using (var db = new PersonDBContext())
            {
                return db.Person.ToList().Select(Map).ToList();
            }
        }

        public PersonModel GetPersonById(int id)
        {
            using (var db = new PersonDBContext())
            {
                return db.Person.Include(i => i.PersonToPersonPerson)
                    .ThenInclude(i => i.RelatedPerson)
                    .Where(a => a.Id == id).ToList()
                    .Select(Map).FirstOrDefault();
            }
        }

        public void UpdatePerson(PersonModel person)
        {
            using (var db = new PersonDBContext())
            {
                var dbModel = db.Person.Single(a => a.Id == person.Id);
                dbModel.FirstName = person.FirstName;
                dbModel.LastName = person.LastName;
                dbModel.PersonalNumber = person.PersonalNumber;
                dbModel.GenderiD = person.GenderiD;
                dbModel.CityId = person.CityId;
                dbModel.BirthDate = person.BirthDate;
                dbModel.ImagePath = person.ImagePath ?? dbModel.ImagePath;
                db.Update(dbModel);
                db.SaveChanges();
            }
        }

        public void DeleteRelatedPerson(PersonModel person, PersonModel relatedPerson)
        {
            using (var db = new PersonDBContext())
            {
                var dbModel =
                    db.PersonToPerson.Single(a => a.PersonId == person.Id && a.RelatedPersonId == relatedPerson.Id);
                db.PersonToPerson.Remove(dbModel);
                db.SaveChanges();
            }
        }

        private PersonModel Map(Person i)
        {
            return new PersonModel
            {
                BirthDate = i.BirthDate,
                CityId = i.CityId,
                FirstName = i.FirstName,
                GenderiD = i.GenderiD,
                Id = i.Id,
                ImagePath = i.ImagePath,
                IsDeleted = i.IsDeleted,
                LastName = i.LastName,
                PersonalNumber = i.PersonalNumber,
                RelatedPersons = i.PersonToPersonPerson?.Select(i => Map(i.RelatedPerson)).ToList()
            };
        }
        private RelationTypeModel Map(RelationTypes i)
        {
            return new RelationTypeModel()
            {
                Id = i.Id,
                Name = i.Name
            };
        }

        public void AddRelatedPerson(PersonModel person, PersonModel relatedPerson, int relationTypeId)
        {
            using (var db = new PersonDBContext())
            {
                var model = new PersonToPerson();
                model.PersonId = person.Id;
                model.RelatedPersonId = relatedPerson.Id;
                model.RelationTypeId = relationTypeId;
                db.Add(model);
                db.SaveChanges();
            }
        }

        public ICollection<RelationTypeModel> GetPersonRelationTypes()
        {
            using (var db = new PersonDBContext())
            {
                return db.RelationTypes.ToList().Select(Map).ToList();
            }
        }

        public int CreatePerson(PersonModel person)
        {
            using (var db = new PersonDBContext())
            {
                var model = new Person
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    PersonalNumber = person.PersonalNumber,
                    GenderiD = person.GenderiD,
                    CityId = person.CityId,
                    BirthDate = person.BirthDate,
                    ImagePath = person.ImagePath
                };

                db.Add(model);
                db.SaveChanges();

                return model.Id;
            }
        }

        public ICollection<PhoneTypeModel> GetPhoneTypes()
        {
            using (var db=new PersonDBContext())
            {
                return db.PhoneType.ToList().Select(Map).ToList();
            }
        }

        private PhoneTypeModel Map(PhoneType i)
        {
            return new PhoneTypeModel()
            {
                Id = i.Id,
                Name = i.Name
            };
        }
    }
}
