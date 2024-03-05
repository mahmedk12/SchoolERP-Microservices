using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Contracts.Persistance;
using Staff.Application.Contracts.Persistance.Constant;
using Staff.Application.Contracts.Persistance.Department;
using Staff.Application.Contracts.Persistance.Staff;
using Staff.Application.Exceptions;
using Staff.Application.Features.Staff.Queries;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Shared;
using Staff.Domain.Entities.Constant;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Staff;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Staff.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, ApiResponse<object>>
    {
        private readonly IStaffRepository _staffrepository;
        private readonly IDepartmentCategoryRepository _departmentcategoryRepository;
        private readonly IDepartmentInfoRepository _departmentinfoRepository;
        private readonly IDegreeLevelRepository _degreeLevelRepository;
        private readonly ILogger<CreateStaffCommandHandler> _logger;
        private readonly IMapper _mapper;
        public CreateStaffCommandHandler(IStaffRepository staffRepository,
            IDepartmentCategoryRepository departmentcategoryRepository,
            IDepartmentInfoRepository departmentinfoRepository,
            IDegreeLevelRepository degreeLevelRepository,
            ILogger<CreateStaffCommandHandler> logger, IMapper mapper)
        {
            _staffrepository = staffRepository;
            _departmentcategoryRepository = departmentcategoryRepository;
            _departmentinfoRepository = departmentinfoRepository;
            _degreeLevelRepository = degreeLevelRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ApiResponse<object>> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            if (request.educationDetails!=null)
            {
                foreach (var educationDetail in request.educationDetails)
                {
                    var degreelevel = await _degreeLevelRepository.GetByIdAsync(educationDetail.degreelevelId);
                    if (degreelevel == null)
                        throw new CustomNotFoundException(nameof(DegreeLevel), "Degree Not Exsist");
                   
                }
            }
            if (request.employmentDetail!=null)
            {
                var departmentcategory = await _departmentcategoryRepository.GetByIdAsync(o=>o.Id==request.employmentDetail.departmentcategoryId,
                    new List<Expression<Func<DepartmentCategory, object>>>() {o=>o.DepartmentInfos});
                if (departmentcategory == null)
                    throw new CustomNotFoundException(nameof(DepartmentCategory), "Department Category Not Exsist");

                foreach (var departmentInfo in request.employmentDetail.departmentInfos)
                {
                    var department = departmentcategory.DepartmentInfos.Where(x=>x.Id==departmentInfo.departmentinfoId).FirstOrDefault();
                    if (department == null)
                        throw new CustomNotFoundException(nameof(DepartmentInfo), "Department Not Exsist");
                }
            }

           
            var staffinfo = _mapper.Map<StaffPersonalInfo>(request);

            var newstaffinfo = await _staffrepository.AddAsync(staffinfo);
            var staffDto=_mapper.Map<GetStaffDto>(newstaffinfo);
            var response = new ApiResponse<object>();
            response.Data = staffDto;
            response.StatusCode = 200; 
            return response;
        }
    }
}
