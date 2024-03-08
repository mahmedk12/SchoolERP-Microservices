using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Contracts.Persistance.Constant;
using Staff.Application.Contracts.Persistance.Department;
using Staff.Application.Contracts.Persistance.Staff;
using Staff.Application.Exceptions;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Shared;
using Staff.Domain.Entities.Constant;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Junction;
using Staff.Domain.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, ApiResponse<object>>
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;


        public UpdateStaffCommandHandler(IStaffRepository staffRepository, IMapper mapper)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
        }

    public async Task<ApiResponse<object>> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        List<Expression<Func<StaffPersonalInfo, object>>> expressions = new List<Expression<Func<StaffPersonalInfo, object>>>();

        expressions.Add(t => t.EducationDetails);
        expressions.Add(t => (t.EducationDetails as StaffEducationDetail).DegreeLevel);
        expressions.Add(t => t.EmploymentDetail);
        expressions.Add(t => t.EmploymentDetail.PositionLevel);
        expressions.Add(t => t.EmploymentDetail.Type);
        expressions.Add(t => t.EmploymentDetail.Status);
        expressions.Add(t => t.EmploymentDetail.DepartmentCategory);
        expressions.Add(t => (t.EmploymentDetail.DepartmentInfos as EmploymentDetailDepartment).DepartmentInfo);

        Func<IQueryable<StaffPersonalInfo>, IOrderedQueryable<StaffPersonalInfo>> orderByFunction = query => query.OrderBy(o => o.CreatedDate);

        var staffInfos = await _staffRepository.GetAsync(x => x.Id == request.Id, orderByFunction, expressions, false);
        var StaffInfo = staffInfos.FirstOrDefault();

        var staffInfoProperties = typeof(StaffPersonalInfo).GetProperties();

        foreach (var property in typeof(UpdateStaffCommand).GetProperties())
        {
            var propertyName = char.ToUpper(property.Name[0]) + property.Name.Substring(1);
            var propertyValue = property.GetValue(request);
                
            var staffInfoProperty = staffInfoProperties.FirstOrDefault(p => p.Name == propertyName);

            if (propertyName == "EducationDetails" && propertyValue != null)
            {
                var educationDetails = (List<UpdateStaffEducationDetailDto>)propertyValue;
                var staffEducationDetails = educationDetails.Select(dto => _mapper.Map<StaffEducationDetail>(dto)).ToList();
                propertyValue = staffEducationDetails;
            }
            propertyValue = propertyName == "EmploymentDetail" ? _mapper.Map<StaffEmploymentDetail>(request.employmentDetail) : propertyValue;
                
            if (staffInfoProperty != null && propertyValue != null)
            {
                staffInfoProperty.SetValue(StaffInfo, propertyValue);
            }
        }

        await _staffRepository.UpdateAsync(StaffInfo);
  
        var staffDto = _mapper.Map<GetStaffDto>(StaffInfo);
        var response = new ApiResponse<object>();
        response.Data = staffDto;
        response.StatusCode = 200;
        response.Message = "Staff Successfully Updated";
        return response;
    }

    }
}
