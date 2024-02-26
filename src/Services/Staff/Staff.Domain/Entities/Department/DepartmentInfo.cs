using Staff.Domain.Common;
using Staff.Domain.Entities.Junction;
using Staff.Domain.Entities.Staff;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Staff.Domain.Entities.Department
{
    [Table("DepartmentInfo")]
    public class DepartmentInfo:EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentCategoryId { get; set; }
        public DepartmentCategory DepartmentCategory { get; set; }
        public ICollection<EmploymentDetailDepartment> EmploymentDetails { get; set; }
    }
}
