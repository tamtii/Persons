using PersonPortal.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonPortal.Contracts.Interfaces.Services
{
    public interface ICityService
    {
        ICollection<CityModel> GetCities();
    }
}
