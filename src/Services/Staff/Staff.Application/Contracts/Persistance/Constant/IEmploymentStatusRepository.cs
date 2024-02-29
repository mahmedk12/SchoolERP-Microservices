using Staff.Application.Contracts.Persistance.Generic;
using Staff.Domain.Entities.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Contracts.Persistance.Constant
{
    public interface IEmploymentStatusRepository:IAsyncRepository<StaffEmploymentStatus>
    {
    }
}
