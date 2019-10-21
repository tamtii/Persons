using System;
using System.Collections.Generic;
using System.Text;
using PersonPortal.Contracts.Models;

namespace PersonPortal.Contracts.Interfaces.Repositories
{
    public interface IGenderRepository
    {
        ICollection<GenderModel> GetGenders();
    }
}
