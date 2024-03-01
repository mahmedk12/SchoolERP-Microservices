using Staff.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Staff.Domain.Entities.Staff
{
    [Table("StaffInfos")]
    public class StaffPersonalInfo : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string StaffNo { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nic { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string? Religion { get; set; }
        public string? PermanentAddress { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string? PassportImage { get; set; }
        public string? NicImage { get; set; }

        public StaffEmploymentDetail? EmploymentDetail { get; set; }
        public ICollection<StaffEducationDetail>? EducationDetails { get; set; }


    }
}
