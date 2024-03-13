using MediatR;
using Microsoft.AspNetCore.Http;
using Staff.Application.Features.Staff.Commands.Dtos;
using Staff.Application.Features.Staff.Queries;
using Staff.Application.Shared;
using Staff.Domain.Common;

namespace Staff.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommand : IRequest<ApiResponse<object>>
    {
        public CreateStaffDto StaffDto { get; set; }
    }
   
    
}
