using MediatR;

namespace Staff.Application.Features.Staff.Queries.GetSingleStaff
{
    public class GetSingleStaffQuery:IRequest<GetStaffDto>
    {
        public int Id { get; set; }
    }
   
}
