namespace Staff.Application.Features.Staff.Queries
{
    public class GetStaffDto
    {
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
        public GetStaffEmploymentDetailDto employmentDetial { get; set; }
        public IEnumerable<GetStaffEducationDetialDto> educationDetails { get; set; }
    }
    public class GetStaffEducationDetialDto
    {
        public int Id { get; set; }
        public GetDegreeLevelDto degreeLevel { get; set; }
        public string certificateImage { get; set; }
    }
    public class GetStaffEmploymentDetailDto
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int PositionLevelId { get; set; }
        public int TypeId { get; set; }
        public DateTime? EmployedAt { get; set; }
        public DateTime? LeftAt { get; set; }
        public GetPositionLevelDto PositionLevel { get; set; }
        public GetStatusDto Status { get; set; }
        public GetTypeDto Type { get; set; }
        public GetDepartmentCategoryDto DepartmentCategory { get; set; }
        public List<GetDepartmentInfoDto> DepartmentInfos { get; set; }
    }
    public class GetDegreeLevelDto
    {
        public int Id { get; set; }
        public string Level { get; set; }
    }
    public class GetStatusDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
    public class GetTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
    public class GetPositionLevelDto
    {
        public int Id { get; set; }
        public string Level { get; set; }
    }
    public class GetDepartmentCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class GetDepartmentInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
