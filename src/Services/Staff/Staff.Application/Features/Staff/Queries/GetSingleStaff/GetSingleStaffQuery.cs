using MediatR;
using Staff.Application.Features.Staff.Queries.Dtos;

namespace Staff.Application.Features.Staff.Queries.GetSingleStaff
{
    public class GetSingleStaffQuery:IRequest<GetStaffDto>
    {
        public  int Id { get; set; }
        public GetSingleStaffQuery(int Id)
        {
                this.Id = Id;
        }
    }
   
}
