using MediatR;
using Staff.Application.Features.Staff.Queries;
using Staff.Domain.Entities;

namespace Staff.Application.Features.Staff.Commands.CreateStaffPersonalInfo
{
    public class CreateStaffCommand : IRequest<GetStaffDto>
    {
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
        public List<CreateStaffEducationDetailDto> educationDetails { get; set; }
    }
    public class CreateStaffEducationDetailDto
    {
        public string instituteName { get; set; }
        public int passingYear { get; set; }
        public decimal obtainedMarks { get; set; }
        public string Grade { get; set; }
        public string degreeLevel { get; set; }
        public string certificateImage { get; set; }
    }
}
