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
    public class DepartmentCategoryRepository:RepositoryBase<DepartmentCategory>,IDepartmentCategoryRepository
    {
        public DepartmentCategoryRepository(StaffDbContext dbContext):base(dbContext)
        {
                
        }
    }
}
