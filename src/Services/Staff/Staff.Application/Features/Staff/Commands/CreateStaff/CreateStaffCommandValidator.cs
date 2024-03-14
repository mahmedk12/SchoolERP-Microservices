using FluentValidation;
using Staff.Application.Contracts.Persistance.Constant;
using Staff.Application.Contracts.Persistance.Department;
using Staff.Application.Features.Staff.Commands.Dtos;
using Staff.Application.Features.Staff.Commands.UpdateStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
    {
        private readonly IDegreeLevelRepository _degreeLevelRepository;
        private readonly IDepartmentCategoryRepository _departmentCategoryRepository;
        private readonly IPositionLevelRepository _positionLevelRepository;
        private readonly IEmploymentStatusRepository _employeeStatusRepository;
        private readonly IEmploymentTypeRepository _employeeTypeRepository;
        private readonly IDepartmentInfoRepository _departmentInfoRepository;

        public CreateStaffCommandValidator(
            IDegreeLevelRepository degreeLevelRepository,
            IDepartmentCategoryRepository departmentCategoryRepository,
            IPositionLevelRepository positionLevelRepository,
            IEmploymentStatusRepository employeeStatusRepository,
            IEmploymentTypeRepository employeeTypeRepository,
            IDepartmentInfoRepository departmentInfoRepository)
        {
            _degreeLevelRepository = degreeLevelRepository;
            _departmentCategoryRepository = departmentCategoryRepository;
            _positionLevelRepository = positionLevelRepository;
            _employeeStatusRepository = employeeStatusRepository;
            _employeeTypeRepository = employeeTypeRepository;
            _departmentInfoRepository = departmentInfoRepository;

            //FLUENT VALIDATION
            
            RuleFor(p => p.StaffDto.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(p => p.StaffDto.email)
               .NotEmpty().WithMessage("EmailAddress is required.")
               .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(p => p.StaffDto.Nic)
               .NotEmpty().WithMessage("CNIC Number is required.")
               .Length(13).WithMessage("CNIC Numbers must be 13 digits.");

            RuleFor(p => p.StaffDto.mobileNumber)
               .NotEmpty().WithMessage("Mobile number is required")
               .Length(11).WithMessage("Mobile number must be exactly 11 digits");

            //DATABASE VALIDATION

            RuleForEach(p => p.StaffDto.educationDetails)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (educationDetail, token) =>
                {
                    var degreeLevel = await _degreeLevelRepository.GetByIdAsync(educationDetail.degreelevelId);
                    return degreeLevel != null;
                })
                .WithMessage("Degree Not Exist")
                .When(p => p.StaffDto.educationDetails != null);

            RuleFor(p => p.StaffDto.employmentDetail.positionLevelId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (positionId, cancellationToken) =>
                {
                    if (positionId == null)
                    {
                        return true;
                    }
                    var position = await _positionLevelRepository.GetByIdAsync(positionId.Value);
                    return position != null;
                })
                .WithMessage("Position Level does not exist")
                .When(p => p.StaffDto.employmentDetail != null);

            RuleFor(p => p.StaffDto.employmentDetail.statusId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (statusId, cancellationToken) =>
                {
                    if (statusId == null)
                    {
                        return true;
                    }
                    var status = await _employeeStatusRepository.GetByIdAsync(statusId.Value);
                    return status != null;
                })
                .WithMessage("Status Level does not exist")
                .When(p => p.StaffDto.employmentDetail != null);

            RuleFor(p => p.StaffDto.employmentDetail.typeId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (typeId, cancellationToken) =>
                {
                    if (typeId == null)
                    {
                        return true;
                    }
                    var type = await _employeeTypeRepository.GetByIdAsync(typeId.Value);
                    return type != null;
                })
                .WithMessage("Employee Type does not exist")
                .When(p => p.StaffDto.employmentDetail != null);

            RuleForEach(p => p.StaffDto.employmentDetail.departmentInfos)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (departmentInfo, token) =>
                {
                    var department = await _departmentInfoRepository.GetByIdAsync(departmentInfo.departmentinfoId);
                    return department != null;
                })
                .WithMessage("Department Not Exist")
                .When(p => p.StaffDto.employmentDetail != null);

            RuleFor(p => p.StaffDto.employmentDetail.departmentcategoryId)
               .Cascade(CascadeMode.Stop)
               .MustAsync(async (categoryId, cancellationToken) =>
               {
                   var category = await _departmentCategoryRepository.GetByIdAsync(categoryId);
                   return category != null;
               })
               .WithMessage("Department Category Not Exist")
               .When(p => p.StaffDto.employmentDetail != null);
        }

    }
}
