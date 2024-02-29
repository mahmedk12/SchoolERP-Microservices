using Staff.Application.Contracts.Persistance.Generic;
using Staff.Domain.Entities.Staff;
namespace Staff.Application.Contracts.Persistance.Staff
{
    public interface IStaffRepository : IAsyncRepository<StaffPersonalInfo>
    {
    }
}
