using MediatR;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Shared;

namespace Staff.Application.Features.Staff.Queries.GetSingleStaff
{
    public class GetAllStaffQuery:IRequest<ApiResponse<object>>
    {
    }
   
}
