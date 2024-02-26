using AutoMapper;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Queries;
using Staff.Domain.Entities;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Junction;
using Staff.Domain.Entities.Staff;

namespace Staff.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
                CreateMap<StaffPersonalInfo,CreateStaffCommand>().ReverseMap();
                CreateMap<StaffEducationDetail,CreateStaffEducationDetailDto>().ReverseMap(); 
                CreateMap<StaffPersonalInfo,GetStaffDto>().ReverseMap();
                CreateMap<StaffEducationDetail, GetStaffEducationDetialDto>().ReverseMap();
                CreateMap<DegreeLevel,GetDegreeLevelDto>().ReverseMap();
                CreateMap<StaffEmploymentDetail,CreateEmploymentDetailDto>().ReverseMap();
                CreateMap<EmploymentDetailDepartment, StaffEmploymentDetailDepartmentInfoDto>().ReverseMap();
                CreateMap<StaffPositionLevel,GetPositionLevelDto>().ReverseMap();
                CreateMap<StaffEmploymentStatus,GetStatusDto>().ReverseMap();   
                CreateMap<StaffEmploymentType,GetTypeDto>().ReverseMap();
                CreateMap<DepartmentCategory, GetDepartmentCategoryDto>().ReverseMap();
                CreateMap<StaffEmploymentDetail, GetStaffEmploymentDetailDto>().ReverseMap();
                CreateMap<EmploymentDetailDepartment, GetDepartmentInfoDto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.DepartmentInfo.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.DepartmentInfo.Name))
                  .ReverseMap();
                  
                
        }
    }
}
