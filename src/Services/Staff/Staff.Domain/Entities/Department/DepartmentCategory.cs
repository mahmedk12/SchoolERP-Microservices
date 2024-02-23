using Staff.Domain.Common;
using Staff.Domain.Entities.Staff;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Staff.Domain.Entities.Department
{
    [Table("DepartmentCategory")]
    public class DepartmentCategory : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<StaffEmploymentDetail> EmploymentDetails { get; set; }
        public ICollection<DepartmentInfo > DepartmentInfos { get; set; }
        

    }
}
