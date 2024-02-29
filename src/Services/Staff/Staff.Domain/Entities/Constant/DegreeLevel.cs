using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Staff.Domain.Common;
using Staff.Domain.Entities.Staff;

namespace Staff.Domain.Entities.Constant
{
    [Table("DegreeLevel")]
    public class DegreeLevel : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Level { get; set; }
        public ICollection<StaffEducationDetail> EducationDetials { get; set; }
    }
}
