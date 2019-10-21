using System;
using System.Collections.Generic;
using System.Text;
using PersonPortal.Contracts.Interfaces.Repositories;
using PersonPortal.Contracts.Interfaces.Services;
using PersonPortal.Contracts.Models;

namespace PersonPortal.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        public ICollection<GenderModel> GetGenders()
        {
            return _genderRepository.GetGenders();
        }
    }
}
