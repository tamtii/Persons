using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonPortal.Contracts.Interfaces.Repositories;
using PersonPortal.Contracts.Models;
using PersonPortal.Data.DbModels;

namespace PersonPortal.Repository
{
    public class GenderRepository : IGenderRepository
    {
        public ICollection<GenderModel> GetGenders()
        {
            using (var db = new PersonDBContext())
            {
                return db.Gender.ToList().Select(Map).ToList();
            }
        }
        private GenderModel Map(Gender i)
        {
            return new GenderModel()
            {
                Id = i.Id,
                Name = i.Name
            };
        }
    }
}
