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
    public class GetSingleStaffQueryHandler : IRequestHandler<GetSingleStaffQuery, ApiResponse<object>>
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

        

        public async Task<ApiResponse<object>> Handle(GetSingleStaffQuery request, CancellationToken cancellationToken)
        {
            List<Expression<Func<StaffPersonalInfo, object>>> expressions =
                new List<Expression<Func<StaffPersonalInfo, object>>>();
            expressions.Add(t => (t.EducationDetails as StaffEducationDetail).DegreeLevel);
            expressions.Add(t => t.EmploymentDetail);
            expressions.Add(t =>t.EmploymentDetail.PositionLevel);
            expressions.Add(t =>t.EmploymentDetail.Type);
            expressions.Add(t =>t.EmploymentDetail.Status);
            expressions.Add(t =>t.EmploymentDetail.DepartmentCategory);
           // expressions.Add(t => t.EmploymentDetail.DepartmentCategory.DepartmentInfos);
            expressions.Add(t =>(t.EmploymentDetail.DepartmentInfos as EmploymentDetailDepartment).DepartmentInfo);
            // Define the include expressions to eagerly load related entities like products






            // Define the orderBy function to order the results by some criteria, for example, order by OrderId
            //Func<IQueryable<StaffPersonalInfo>, IOrderedQueryable<StaffPersonalInfo>> orderByFunction = query => query.OrderBy(o => o.CreatedDate);

            var staffInfo = await _staffRepository.GetByIdAsync(o=>o.Id==request.Id, expressions);
            if (staffInfo==null)
            {
                throw new CustomNotFoundException(nameof(StaffPersonalInfo), "Staff Not Exsist");
            }
            var staffDto = _mapper.Map<GetStaffDto>(staffInfo);
            var response = new ApiResponse<object>();
            response.Data = staffDto;
            response.StatusCode = 200;
            response.Message = "Staff Detail Succussfully Retrieved";
            return response;
        }
    }
}
