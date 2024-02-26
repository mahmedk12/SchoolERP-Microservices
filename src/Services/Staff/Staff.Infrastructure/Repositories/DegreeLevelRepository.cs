using Staff.Application.Contracts.Persistance;
using Staff.Domain.Entities;
using Staff.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure.Repositories
{
    public class DegreeLevelRepository:RepositoryBase<DegreeLevel>,IDegreeLevelRepository
    {
        public DegreeLevelRepository(StaffDbContext dbContext):base(dbContext)
        {
                
        }
    }
}
