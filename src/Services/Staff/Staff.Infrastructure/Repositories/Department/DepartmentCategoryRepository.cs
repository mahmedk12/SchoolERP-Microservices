using Staff.Application.Contracts.Persistance.Department;
using Staff.Domain.Entities.Department;
using Staff.Infrastructure.Persistence;
using Staff.Infrastructure.Repositories.Generic;

namespace Staff.Infrastructure.Repositories.Department
{
    public class DepartmentCategoryRepository : RepositoryBase<DepartmentCategory>, IDepartmentCategoryRepository
    {
        public DepartmentCategoryRepository(StaffDbContext dbContext) : base(dbContext)
        {

        }
    }
}
