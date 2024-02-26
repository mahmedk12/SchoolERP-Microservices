using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using Staff.Application.Contracts.Persistance;
using Staff.Domain.Entities;
using Staff.Domain.Entities.Junction;
using Staff.Domain.Entities.Staff;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

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

            List<Expression<Func<StaffPersonalInfo, object>>> expressions =
                new List<Expression<Func<StaffPersonalInfo, object>>>();
            expressions.Add(t => (t.EducationDetails as StaffEducationDetail).DegreeLevel);
            expressions.Add(t =>t.EmploymentDetail.PositionLevel);
            expressions.Add(t =>t.EmploymentDetail.Type);
            expressions.Add(t =>t.EmploymentDetail.Status);
            expressions.Add(t =>t.EmploymentDetail.DepartmentCategory);
            expressions.Add(t =>(t.EmploymentDetail.DepartmentInfos as EmploymentDetailDepartment).DepartmentInfo);
            // Define the include expressions to eagerly load related entities like products






            // Define the orderBy function to order the results by some criteria, for example, order by OrderId
            Func<IQueryable<StaffPersonalInfo>, IOrderedQueryable<StaffPersonalInfo>> orderByFunction = query => query.OrderBy(o => o.CreatedDate);

            var staffInfos = await _staffRepository.GetAsync(x => x.Id == request.Id, orderByFunction, expressions); 
            var StaffInfo=staffInfos.FirstOrDefault();
            var staffDto = _mapper.Map<GetStaffDto>(StaffInfo);
            return staffDto;
        }
    }
}
