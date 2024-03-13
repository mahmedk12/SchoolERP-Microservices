using Microsoft.AspNetCore.Http;
using Staff.Application.Features.Staff.Commands.UpdateStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Commands.Dtos
{
    public class UpdateStaffDto
    {
        public string? StaffNo { get; set; }
        public string? Name { get; set; }
        public DateTime? dateofBirth { get; set; }
        public string? Nic { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? Religion { get; set; }
        public string? permanentAddress { get; set; }
        public string? residentialAddress { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? mobileNumber { get; set; }
        public string? email { get; set; }
        public string? passportImage { get; set; }
        public IFormFile? passportImageFile { get; set; }
        public string? nicImage { get; set; }
        public IFormFile? nicImageFile { get; set; }
        public UpdateEmploymentDetailDto? employmentDetail { get; set; }
        public List<UpdateStaffEducationDetailDto>? educationDetails { get; set; }
    }
    public class UpdateStaffEducationDetailDto
    {
        public int Id { get; set; }
        public string previousinstituteName { get; set; }
        public int degreelevelId { get; set; }
        public string certificateImage { get; set; }
        public IFormFile? certificateImageFile { get; set; }
    }

    public class UpdateEmploymentDetailDto
    {
        public int? statusId { get; set; }
        public int? positionLevelId { get; set; }
        public int? typeId { get; set; }
        public DateTime? employedAt { get; set; }
        public DateTime? leftAt { get; set; }
        public int DepartmentCategoryId { get; set; }
        public List<StaffEmploymentDetailDepartmentInfoDto>? departmentInfos { get; set; }
    }

    public class UpdateStaffEmploymentDetailDepartmentInfoDto
    {
        public int departmentinfoId { get; set; }
    }
}
