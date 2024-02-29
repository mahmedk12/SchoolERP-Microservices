using AutoMapper;
using MediatR;
using Staff.Application.Contracts.Persistance.Constant;
using Staff.Application.Contracts.Persistance.Department;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Shared;
using Staff.Domain.Common;
using Staff.Domain.Entities.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Queries.GetFormData
{
    public class GetFormDataQueryHandler : IRequestHandler<GetFormDataQuery, ApiResponse<GetFormDataDto>>
    {

        private readonly IEmploymentStatusRepository _employmentStatusRepository;
        private readonly IEmploymentTypeRepository _employmentTypeRepository;
        private readonly IPositionLevelRepository _positionLevelRepository;
        private readonly IDegreeLevelRepository _degreeLevelRepository;
        private readonly IDepartmentCategoryRepository _departmentCategoryRepository;
        private readonly IMapper _mapper;

        public GetFormDataQueryHandler(IEmploymentStatusRepository employmentStatusRepository, 
            IEmploymentTypeRepository employmentTypeRepository, 
            IPositionLevelRepository positionLevelRepository, 
            IDegreeLevelRepository degreeLevelRepository, 
            IDepartmentCategoryRepository departmentCategoryRepository,
            IMapper mapper)
        {
            _employmentStatusRepository = employmentStatusRepository;
            _employmentTypeRepository = employmentTypeRepository;
            _positionLevelRepository = positionLevelRepository;
            _degreeLevelRepository = degreeLevelRepository;
            _departmentCategoryRepository = departmentCategoryRepository;
            _mapper=mapper;
        }

        public async Task<ApiResponse<GetFormDataDto>> Handle(GetFormDataQuery request, CancellationToken cancellationToken)
        {
            var degreelevels = await _degreeLevelRepository.GetAllAsync();
            var types=await _employmentTypeRepository.GetAllAsync();
            var statuses=await _employmentStatusRepository.GetAllAsync();
            var positions=await _positionLevelRepository.GetAllAsync();
            var departmentcategories = await _departmentCategoryRepository
                .GetAsync(null, null, new List<Expression<Func<DepartmentCategory, object>>>() { o=>o.DepartmentInfos});

            var formdataDto = new GetFormDataDto();
            formdataDto.commonValues.degreeLevels=_mapper.Map<List<GetDegreeLevelDto>>(degreelevels);
            formdataDto.commonValues.positionLevels= _mapper.Map<List<GetPositionLevelDto>>(positions);
            formdataDto.commonValues.statuses= _mapper.Map<List<GetStatusDto>>(statuses);
            formdataDto.commonValues.types= _mapper.Map<List<GetTypeDto>>(types);
            formdataDto.commonValues.departmentCategories= _mapper.Map<List<GetDepartmentCategoryDto>>(departmentcategories);
            var response = new ApiResponse<GetFormDataDto>();
            response.Data = formdataDto;
            return response;

        }
    }
}
