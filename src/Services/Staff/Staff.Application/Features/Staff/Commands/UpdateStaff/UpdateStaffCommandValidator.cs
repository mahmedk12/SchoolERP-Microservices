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
            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("Name is required.");

            //RuleFor(p => p.email)
            //   .NotEmpty().WithMessage("EmailAddress is required.")
            //   .EmailAddress().WithMessage("Please enter a valid email address.");

            //RuleFor(p => p.Nic)
            //   .NotEmpty().WithMessage("CNIC Number is required.")
            //   .Length(13).WithMessage("CNIC Numbers must be 13 digits.");

            //RuleFor(p => p.mobileNumber)
            //   .NotEmpty().WithMessage("Mobile number is required")
            //   .Length(11).WithMessage("Mobile number must be exactly 11 digits");

            //DATABASE VALIDATION
            //RuleForEach(p => p.educationDetails).MustAsync(async (educationDetail, token) =>
            //{
            //    var degreeLevel = await _degreeLevelRepository.GetByIdAsync(educationDetail.degreelevelId);
            //    return degreeLevel != null;
            //}).WithMessage("Degree Not Exist");

            //RuleFor(p => p.employmentDetail.departmentcategoryId).MustAsync(async (categoryId, token) =>
            //{
            //    var departmentCategory = await _departmentCategoryRepository.GetByIdAsync(categoryId);
            //    return departmentCategory != null;
            //}).WithMessage("Department Category Not Exist");

            //RuleFor(p => p.employmentDetail.positionLevelId).MustAsync(async (positionId, token) =>
            //{
            //    var positionLevel = await _positionLevelRepository.GetByIdAsync(positionId);
            //    return positionLevel != null;
            //}).WithMessage("Position Level Not Exist");

            //RuleFor(p => p.employmentDetail.statusId).MustAsync(async (statusId, token) =>
            //{
            //    var employeeStatus = await _employeeStatusRepository.GetByIdAsync(statusId);
            //    return employeeStatus != null;
            //}).WithMessage("Employee Status Not Exist");

            //RuleFor(p => p.employmentDetail.typeId).MustAsync(async (typeId, token) =>
            //{
            //    var employeeType = await _employeeTypeRepository.GetByIdAsync(typeId);
            //    return employeeType != null;
            //}).WithMessage("Employee Type Not Exist");

            //RuleForEach(p => p.employmentDetail.departmentInfos).MustAsync(async (departmentInfo, token) =>
            //{
            //    var department = await _departmentInfoRepository.GetByIdAsync(departmentInfo.departmentinfoId);
            //    return department != null;
            //}).WithMessage("Department Not Exist");
        }

    }
}
