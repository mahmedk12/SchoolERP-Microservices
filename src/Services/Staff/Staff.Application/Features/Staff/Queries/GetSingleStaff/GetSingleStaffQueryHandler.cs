using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Contracts.Persistance;
using Staff.Domain.Entities;
using System.Linq.Expressions;

namespace Staff.Application.Features.Staff.Queries.GetSingleStaff
{
    public class GetSingleStaffQueryHandler : IRequestHandler<GetSingleStaffQuery,GetStaffDto>
    {
        private readonly IStaffRepository _staffRepository;
        private readonly ILogger<GetSingleStaffQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetSingleStaffQueryHandler(IStaffRepository staffRepository, ILogger<GetSingleStaffQueryHandler> logger, IMapper mapper)
        {
            _staffRepository = staffRepository;
            _logger = logger;
            _mapper = mapper;
        }

        

        public async Task<GetStaffDto> Handle(GetSingleStaffQuery request, CancellationToken cancellationToken)
        {
            

            // Define the include expressions to eagerly load related entities like products
            List < Expression < Func<StaffPersonalInfo, object> >> includeExpressions = new List<Expression<Func<StaffPersonalInfo, object>>>();
            includeExpressions.Add(o => o.educationDetails); // Assuming 'Products' is the navigation property representing the related products

            // Define the orderBy function to order the results by some criteria, for example, order by OrderId
            Func<IQueryable<StaffPersonalInfo>, IOrderedQueryable<StaffPersonalInfo>> orderByFunction = query => query.OrderBy(o => o.CreatedDate);

            var staffInfos = await _staffRepository.GetAsync(x => x.Id == request.Id, orderByFunction, includeExpressions); 
            var StaffInfo=staffInfos.FirstOrDefault();
            var staffDto = _mapper.Map<GetStaffDto>(StaffInfo);
            return staffDto;
        }
    }
}
