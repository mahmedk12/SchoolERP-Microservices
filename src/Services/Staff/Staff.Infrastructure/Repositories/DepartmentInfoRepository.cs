using Staff.Application.Contracts.Persistance;
using Staff.Domain.Entities.Department;
using Staff.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure.Repositories
{
    public class DepartmentInfoRepository:RepositoryBase<DepartmentInfo>,IDepartmentInfoRepository
    {
        public DepartmentInfoRepository(StaffDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
