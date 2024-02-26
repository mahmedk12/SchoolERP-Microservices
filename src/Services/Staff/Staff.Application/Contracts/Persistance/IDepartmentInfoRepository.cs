using Staff.Domain.Entities.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Contracts.Persistance
{
    public interface IDepartmentInfoRepository:IAsyncRepository<DepartmentInfo>
    {
    }
}
