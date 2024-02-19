using Staff.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Staff.Domain.Entities
{
    [Table("StaffInfos")]
    public class StaffPersonalInfo:EntityBase
    {
        [Key]
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

        public ICollection<StaffEducationDetail> educationDetails { get; set; }

    }
}
