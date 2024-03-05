using MediatR;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Shared;

namespace Staff.Application.Features.Staff.Queries.GetSingleStaff
{
    public class GetSingleStaffQuery:IRequest<ApiResponse<object>>
    {
        public  int Id { get; set; }
        public GetSingleStaffQuery(int Id)
        {
                this.Id = Id;
        }
    }
   
}
