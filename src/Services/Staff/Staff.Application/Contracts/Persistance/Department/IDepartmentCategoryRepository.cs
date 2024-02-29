using Staff.Application.Contracts.Persistance.Generic;
using Staff.Domain.Entities.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Contracts.Persistance.Department
{
    public interface IDepartmentCategoryRepository : IAsyncRepository<DepartmentCategory>
    {
    }
}
