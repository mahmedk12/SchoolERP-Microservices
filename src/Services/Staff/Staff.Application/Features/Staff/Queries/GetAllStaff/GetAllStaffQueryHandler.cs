using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Contracts.Persistance.Staff;
using Staff.Application.Exceptions;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Shared;
using Staff.Domain.Entities.Junction;
using Staff.Domain.Entities.Staff;
using System.Linq.Expressions;

namespace Staff.Application.Features.Staff.Queries.GetSingleStaff
{
    public class GetAllStaffQueryHandler : IRequestHandler<GetAllStaffQuery, ApiResponse<object>>
    {
        private readonly IStaffRepository _staffRepository;
        private readonly ILogger<GetAllStaffQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllStaffQueryHandler(IStaffRepository staffRepository, ILogger<GetAllStaffQueryHandler> logger, IMapper mapper)
        {
            _staffRepository = staffRepository;
            _logger = logger;
            _mapper = mapper;
        }
        
        public async Task<ApiResponse<object>> Handle(GetAllStaffQuery request, CancellationToken cancellationToken)
        {
            var staffInfo = await _staffRepository.GetStaffInfo();
            if (staffInfo==null)
            {
                throw new CustomNotFoundException(nameof(StaffPersonalInfo), "Staff Not Exsist");
            }
            var staffDto = _mapper.Map<List<GetStaffDto>>(staffInfo);
            var response = new ApiResponse<object>();
            response.Data = staffDto;
            response.StatusCode = 200;
            response.Message = "Staff Detail Succussfully Retrieved";
            return response;
        }
    }
}
