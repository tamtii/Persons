using System;
using System.Collections.Generic;
using System.Text;
using PersonPortal.Contracts.Models;

namespace PersonPortal.Contracts.Interfaces.Services
{
    public interface IGenderService
    {
        ICollection<GenderModel> GetGenders();
    }
}
