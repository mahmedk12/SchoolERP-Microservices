using MediatR;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Commands.Dtos;
using Staff.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommand : IRequest<ApiResponse<object>>
    {
        public int Id { get; set; }
        public UpdateStaffDto StaffDto { get; set; }
    }

   

}
