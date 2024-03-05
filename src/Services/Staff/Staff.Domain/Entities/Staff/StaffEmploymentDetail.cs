using Staff.Domain.Common;
using Staff.Domain.Entities.Constant;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Junction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Staff.Domain.Entities.Staff
{
    [Table("StaffEmploymentDetail")]
    public class StaffEmploymentDetail : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public int? StatusId { get; set; }
        public int? PositionLevelId { get; set; }
        public int? TypeId { get; set; }
        public DateTime EmployedAt { get; set; }
        public DateTime? LeftAt { get; set; }
        public int DepartmentCategoryId { get; set; }
        public int StaffId { get; set; }
        public StaffPositionLevel PositionLevel { get; set; }
        public StaffEmploymentStatus Status { get; set; }   
        public StaffEmploymentType Type { get; set; }   
        public StaffPersonalInfo StaffInfo { get; set; }
        public DepartmentCategory DepartmentCategory { get; set; }
        public ICollection<EmploymentDetailDepartment>? DepartmentInfos { get; set; }
    }

}

