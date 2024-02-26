using Staff.Application.Contracts.Persistance;
using Staff.Domain.Entities.Staff;
using Staff.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure.Repositories
{
    public class StaffRepository:RepositoryBase<StaffPersonalInfo>,IStaffRepository
    {
        public StaffRepository(StaffDbContext dbContext):base(dbContext)
        {
                
        }
    }
}
