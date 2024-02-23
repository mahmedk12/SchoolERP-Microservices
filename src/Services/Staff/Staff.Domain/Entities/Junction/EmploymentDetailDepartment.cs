using Staff.Domain.Common;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Domain.Entities.Junction
{
    [Table("StaffEmploymentDetialDepartment")]
    public class EmploymentDetailDepartment:EntityBase
    {
        [Column(Order =1)]
        public int EmploymentDetialId { get; set; }
        [Column(Order = 2)]
        public int DepartmentInfoId { get; set; }

        public StaffEmploymentDetail EmploymentDetail { get; set; }
        public DepartmentInfo DepartmentInfo { get; set; }
    }
}
