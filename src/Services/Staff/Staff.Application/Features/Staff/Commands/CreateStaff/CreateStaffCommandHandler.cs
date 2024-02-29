using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Contracts.Persistance.Constant;
using Staff.Application.Contracts.Persistance.Department;
using Staff.Application.Contracts.Persistance.Staff;
using Staff.Application.Exceptions;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Reponse;
using Staff.Domain.Entities.Constant;
using Staff.Domain.Entities.Staff;
using System.ComponentModel.DataAnnotations;

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
           
            foreach (var educationDetail in request.educationDetails)
            {
                var degreelevel = await _degreeLevelRepository.GetByIdAsync(educationDetail.degreelevelId);
                if (degreelevel == null)
                        throw new CustomValidationException();
            }
          
            var departmentcategory = await _departmentcategoryRepository.GetByIdAsync(request.employmentDetail.departmentcategoryId);
            if (departmentcategory == null)
                throw new NotFoundException(nameof(DegreeLevel),"Degree Not Found");

            foreach (var departmentInfo in request.employmentDetail.departmentInfos)
            {
                var department = await _departmentinfoRepository.GetByIdAsync(departmentInfo.departmentinfoId);
                if (department == null)
                    throw new ValidationException("Department Not Exsist");
            }
            var staffinfo = _mapper.Map<StaffPersonalInfo>(request);

            var newstaffinfo = await _staffrepository.AddAsync(staffinfo);
            var staffDto = _mapper.Map<GetStaffDto>(newstaffinfo);
            var response = new ApiResponse<object>();
            response.Data = staffDto;
            return response;
        }
    }
}
