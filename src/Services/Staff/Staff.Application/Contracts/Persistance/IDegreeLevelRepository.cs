using Staff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Contracts.Persistance
{
    public interface IDegreeLevelRepository:IAsyncRepository<DegreeLevel>
    {
    }
}
