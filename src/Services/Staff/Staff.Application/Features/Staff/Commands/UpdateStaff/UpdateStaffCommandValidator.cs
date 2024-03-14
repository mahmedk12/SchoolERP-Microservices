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
using Staff.Domain.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommandValidator : AbstractValidator<UpdateStaffCommand>
    {
        private readonly IDegreeLevelRepository _degreeLevelRepository;
        private readonly IDepartmentCategoryRepository _departmentCategoryRepository;
        private readonly IPositionLevelRepository _positionLevelRepository;
        private readonly IEmploymentStatusRepository _employeeStatusRepository;
        private readonly IEmploymentTypeRepository _employeeTypeRepository;
        private readonly IDepartmentInfoRepository _departmentInfoRepository;

        public UpdateStaffCommandValidator(
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
                .Must(name => name == null || !string.IsNullOrEmpty(name))
                .WithMessage("Name is required.")
                .When(p => p.StaffDto.Name != null);

            RuleFor(p => p.StaffDto.email)
                .Must(mail => mail == null || !string.IsNullOrEmpty(mail))
                .WithMessage("Email Address is required")
                .When(p => p.StaffDto.email != null)
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(p => p.StaffDto.Nic)
                .Must(nic => nic == null || !string.IsNullOrEmpty(nic))
                .WithMessage("CNIC number is required")
                .When(p => p.StaffDto.Nic != null)
                .Length(13).WithMessage("CNIC Numbers must be 13 digits.");

            RuleFor(p => p.StaffDto.mobileNumber)
               .Must(mobileNumber => mobileNumber == null || !string.IsNullOrEmpty(mobileNumber))
               .WithMessage("Mobile number is required")
               .When(p => p.StaffDto.mobileNumber != null)
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

            RuleFor(p => p.StaffDto.employmentDetail.DepartmentCategoryId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (categoryId, cancellationToken) =>
                {
                    var category = await _departmentCategoryRepository.GetByIdAsync(categoryId);
                    return category != null;
                })
                .WithMessage("Department Category Not Exist")
                .When(p => p.StaffDto.employmentDetail != null);

            RuleFor(p => p.StaffDto.employmentDetail.positionLevelId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (positionId, cancellationToken) =>
                {
                    var position = await _positionLevelRepository.GetByIdAsync(positionId.Value);
                    return position != null;
                })
                .WithMessage("Position Level does not exist")
                .When(p => p.StaffDto.employmentDetail != null);

            RuleFor(p => p.StaffDto.employmentDetail.statusId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (statusId, cancellationToken) =>
                {
                    var status = await _employeeStatusRepository.GetByIdAsync(statusId.Value);
                    return status != null;
                })
                .WithMessage("Status Level does not exist")
                .When(p => p.StaffDto.employmentDetail != null);

            RuleFor(p => p.StaffDto.employmentDetail.typeId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (typeId, cancellationToken) =>
                {
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
        }

    }
}
