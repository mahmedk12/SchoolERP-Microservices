using Staff.Domain.Common;
using Staff.Domain.Entities.Staff;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Staff.Domain.Entities.Constant
{
    [Table("StaffEmploymentStatus")]
    public class StaffEmploymentStatus : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<StaffEmploymentDetail> EmploymentDetails { get; set; }
    }
}
