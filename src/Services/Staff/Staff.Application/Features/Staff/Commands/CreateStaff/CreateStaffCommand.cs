using MediatR;
using Staff.Application.Features.Staff.Queries;

namespace Staff.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommand : IRequest<GetStaffDto>
    {
        public string StaffNo { get; set; }
        public string Name { get; set; }
        public DateTime dateofBirth { get; set; }
        public string Nic { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string permanentAddress { get; set; }
        public string residentialAddress { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
        public string passportImage { get; set; }
        public string nicImage { get; set; }
        public CreateEmploymentDetailDto employmentDetail { get; set; }
        public List<CreateStaffEducationDetailDto>? educationDetails { get; set; }
    }
    public class CreateStaffEducationDetailDto
    {
        public string previousinstituteName { get; set; }
        public int degreelevelId { get; set; }
        public string certificateImage { get; set; }
    }
    public class CreateEmploymentDetailDto
    {
        public int statusId { get; set; }
        public int positionLevelId { get; set; }
        public int typeId { get; set; }
        public DateTime? employedAt { get; set; }
        public DateTime? leftAt { get; set; }
        public int departmentcategoryId { get; set; }
        public List<StaffEmploymentDetailDepartmentInfoDto> departmentInfos { get; set; }
    }
    public class StaffEmploymentDetailDepartmentInfoDto
    {
        public int departmentinfoId { get; set; }
    }
    
}
