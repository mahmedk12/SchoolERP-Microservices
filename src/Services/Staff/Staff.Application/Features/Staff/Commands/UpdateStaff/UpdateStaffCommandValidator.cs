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
           
            RuleFor(p => p.Name)
                .Must(name => name == null || !string.IsNullOrEmpty(name))
                .WithMessage("Name is required.")
                .When(p => p.Name != null);

            RuleFor(p => p.email)
                .Must(mail => mail == null || !string.IsNullOrEmpty(mail))
                .WithMessage("Email Address is required")
                .When(p => p.email != null)
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(p => p.Nic)
                .Must(nic => nic == null || !string.IsNullOrEmpty(nic))
                .WithMessage("CNIC number is required")
                .When(p => p.Nic != null)
                .Length(13).WithMessage("CNIC Numbers must be 13 digits.");

             RuleFor(p => p.mobileNumber)
                .Must(mobileNumber => mobileNumber == null || !string.IsNullOrEmpty(mobileNumber))
                .WithMessage("Mobile number is required")
                .When(p => p.mobileNumber != null)
                .Length(11).WithMessage("Mobile number must be exactly 11 digits");

            //DATABASE VALIDATION
            RuleForEach(p => p.educationDetails)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (educationDetail, token) =>
                {
                    var degreeLevel = await _degreeLevelRepository.GetByIdAsync(educationDetail.degreelevelId);
                    return degreeLevel != null;
                })
                .WithMessage("Degree Not Exist")
                .When(p => p.educationDetails != null);

            RuleFor(p => p.employmentDetail.departmentcategoryId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (categoryId, token) =>
                {
                    var departmentCategory = await _departmentCategoryRepository.GetByIdAsync(categoryId);
                    return departmentCategory != null;
                })
                .WithMessage("Department Category Not Exist")
                .When(p => p.employmentDetail != null);

            RuleFor(p => p.employmentDetail.positionLevelId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (positionId, token) =>
                {
                    var positionLevel = await _positionLevelRepository.GetByIdAsync(positionId);
                    return positionLevel != null;
                })
                .WithMessage("Position Level Not Exist")
                 .When(p => p.employmentDetail != null);

            RuleFor(p => p.employmentDetail.statusId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (statusId, token) =>
                {
                    var employeeStatus = await _employeeStatusRepository.GetByIdAsync(statusId);
                    return employeeStatus != null;
                })
                .WithMessage("Employee Status Not Exist")
                .When(p => p.employmentDetail != null);

            RuleFor(p => p.employmentDetail.typeId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (typeId, token) =>
                {
                    var employeeType = await _employeeTypeRepository.GetByIdAsync(typeId);
                    return employeeType != null;
                })
                .WithMessage("Employee Type Not Exist")
                .When(p => p.employmentDetail != null);

            RuleForEach(p => p.employmentDetail.departmentInfos)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (departmentInfo, token) =>
                {
                    var department = await _departmentInfoRepository.GetByIdAsync(departmentInfo.departmentinfoId);
                    return department != null;
                })
                .WithMessage("Department Not Exist")
                .When(p => p.employmentDetail != null);

        }

    }
}
