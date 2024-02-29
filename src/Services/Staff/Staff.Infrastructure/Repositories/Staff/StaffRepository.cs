using Staff.Application.Contracts.Persistance.Staff;
using Staff.Domain.Entities.Staff;
using Staff.Infrastructure.Persistence;
using Staff.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure.Repositories.Staff
{
    public class StaffRepository : RepositoryBase<StaffPersonalInfo>, IStaffRepository
    {
        public StaffRepository(StaffDbContext dbContext) : base(dbContext)
        {

        }
    }
}
