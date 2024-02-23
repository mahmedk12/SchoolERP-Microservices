using Staff.Domain.Entities.Staff;
namespace Staff.Application.Contracts.Persistance
{
    public interface IStaffRepository:IAsyncRepository<StaffPersonalInfo>
    {
    }
}
