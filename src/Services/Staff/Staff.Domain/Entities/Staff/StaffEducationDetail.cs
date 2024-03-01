using Staff.Domain.Common;
using Staff.Domain.Entities.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Domain.Entities.Staff
{
    [Table("StaffEducationDetails")]
    public class StaffEducationDetail : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string PreviousInstituteName { get; set; }

        public string? CertificateImage { get; set; }
        public int StaffId { get; set; }
        public int DegreeLevelId { get; set; }
        public StaffPersonalInfo Staff { get; set; }
        public DegreeLevel DegreeLevel { get; set; }
    }
}
