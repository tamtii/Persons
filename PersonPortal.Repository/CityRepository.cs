using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonPortal.Contracts.Interfaces.Repositories;
using PersonPortal.Contracts.Models;
using PersonPortal.Data.DbModels;

namespace PersonPortal.Repository
{
    public class CityRepository:ICityRepository
    {
        public ICollection<CityModel> GetCities()
        {
            using (var db = new PersonDBContext())
            {
                return db.City.ToList().Select(Map).ToList();
            }
        }

        private CityModel Map(City i)
        {
            return new CityModel()
            {
                Id = i.Id,
                Name = i.Name
            };
        }
    }
}
