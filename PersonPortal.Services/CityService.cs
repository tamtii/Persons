using System;
using System.Collections.Generic;
using System.Text;
using PersonPortal.Contracts.Interfaces.Repositories;
using PersonPortal.Contracts.Interfaces.Services;
using PersonPortal.Contracts.Models;

namespace PersonPortal.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public ICollection<CityModel> GetCities()
        {
            return _cityRepository.GetCities();
        }
    }
}
