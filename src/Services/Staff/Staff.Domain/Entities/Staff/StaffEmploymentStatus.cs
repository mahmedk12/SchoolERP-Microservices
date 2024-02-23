using Staff.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Staff.Domain.Entities.Staff
{
    [Table("StaffEmploymentStatus")]
    public class StaffEmploymentStatus:EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<StaffEmploymentDetail> EmploymentDetails { get; set; }
    }
}
