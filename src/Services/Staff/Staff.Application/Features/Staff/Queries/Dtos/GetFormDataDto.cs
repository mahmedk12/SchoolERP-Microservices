namespace Staff.Application.Features.Staff.Queries.Dtos
{
    public class GetFormDataDto
    {
        public GetFormDataDto()
        {
            commonValues=new ConmmonValues();
        }
        public ConmmonValues commonValues { get; set; }
    }
    public class ConmmonValues
    {
        public IEnumerable<GetTypeDto>? types { get; set; }
        public IEnumerable<GetPositionLevelDto>? positionLevels { get; set; } 
        public IEnumerable<GetStatusDto>? statuses { get; set; }
        public IEnumerable<GetDegreeLevelDto>? degreeLevels { get; set; } 
        public IEnumerable<GetDepartmentCategoryDto>? departmentCategories { get; set; }

    }
}
