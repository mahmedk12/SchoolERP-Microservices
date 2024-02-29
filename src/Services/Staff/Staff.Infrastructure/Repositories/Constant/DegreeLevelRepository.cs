using Staff.Application.Contracts.Persistance.Constant;
using Staff.Domain.Entities.Constant;
using Staff.Infrastructure.Persistence;
using Staff.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure.Repositories.Constant
{
    public class DegreeLevelRepository : RepositoryBase<DegreeLevel>, IDegreeLevelRepository
    {
        public DegreeLevelRepository(StaffDbContext dbContext) : base(dbContext)
        {

        }
    }
}
