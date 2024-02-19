using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Contracts.Persistance;
using Staff.Application.Features.Staff.Queries;
using Staff.Domain.Entities;

namespace Staff.Application.Features.Staff.Commands.CreateStaffPersonalInfo
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, GetStaffDto>
    {
        private readonly IStaffRepository _staffrepository;
        private readonly ILogger<CreateStaffCommandHandler> _logger;
        private readonly IMapper _mapper;
        public CreateStaffCommandHandler(IStaffRepository staffRepository, ILogger<CreateStaffCommandHandler> logger, IMapper mapper)
        {
            _staffrepository = staffRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<GetStaffDto> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var staffinfo = _mapper.Map<StaffPersonalInfo>(request);
            var newstaffinfo = await _staffrepository.AddAsync(staffinfo);
            var staffDto=_mapper.Map<GetStaffDto>(newstaffinfo);
            return staffDto;
        }
    }
}
