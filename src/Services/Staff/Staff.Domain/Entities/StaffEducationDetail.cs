using Staff.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Domain.Entities
{
    [Table("EducationDetails")]
    public class StaffEducationDetail:EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string instituteName { get; set; }
        public int passingYear { get; set; }
        public double obtainedMarks { get; set; }
        public string Grade { get; set; }
        public string degreeLevel { get; set; }
        public string certificateImage { get; set; }
        public int staffId { get; set; }
        public StaffPersonalInfo Staff { get; set; }
    }
}
