using Staff.Application.Contracts.Persistance.Department;
using Staff.Domain.Entities.Department;
using Staff.Infrastructure.Persistence;
using Staff.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure.Repositories.Department
{
    public class DepartmentInfoRepository : RepositoryBase<DepartmentInfo>, IDepartmentInfoRepository
    {
        public DepartmentInfoRepository(StaffDbContext dbContext) : base(dbContext)
        {

        }
    }
}
