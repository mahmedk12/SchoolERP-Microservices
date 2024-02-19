using Staff.Application.Features.Staff.Queries.GetSingleStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Queries
{
    public class GetStaffDto
    {
        public int Id { get; set; }
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

        public IEnumerable<GetStaffEducationDetialDto> educationDetails { get; set; }
    }
    public class GetStaffEducationDetialDto
    {
        public int Id { get; set; }
        public string instituteName { get; set; }
        public int passingYear { get; set; }
        public double obtainedMarks { get; set; }
        public string Grade { get; set; }
        public string degreeLevel { get; set; }
        public string certificateImage { get; set; }
    }
}
