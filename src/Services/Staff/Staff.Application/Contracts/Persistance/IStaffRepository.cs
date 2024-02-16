using Staff.Domain.Entities;
namespace Staff.Application.Contracts.Persistance
{
    public interface IStaffRepository:IAsyncRepository<StaffPersonalInfo>
    {
    }
}
