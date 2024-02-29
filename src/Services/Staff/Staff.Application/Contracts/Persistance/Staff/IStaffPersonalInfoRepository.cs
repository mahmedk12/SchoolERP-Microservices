using Staff.Domain.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Contracts.Persistance.Staff
{
    public interface IStaffPersonalInfoRepository
    {
        Task<StaffPersonalInfo> MapStaffPersonalInfo();
    }
}
