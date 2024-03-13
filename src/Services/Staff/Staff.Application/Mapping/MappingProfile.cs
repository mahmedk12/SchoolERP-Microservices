using AutoMapper;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Commands.Dtos;
using Staff.Application.Features.Staff.Commands.UpdateStaff;
using Staff.Application.Features.Staff.Queries;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Domain.Entities.Constant;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Junction;
using Staff.Domain.Entities.Staff;

namespace Staff.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
                CreateMap<StaffPersonalInfo,CreateStaffDto>().ReverseMap();
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

                CreateMap<StaffEmploymentDetail, GetStaffEmploymentDetailDto>()
                 .ForPath(dest => dest.DepartmentCategory, opt => opt.MapFrom(source => source.DepartmentCategory))
                 .ForPath(dest => dest.DepartmentCategory.DepartmentInfos, opt => opt.MapFrom(source => source.DepartmentInfos.Select(x=>x.DepartmentInfo)))
                 .ReverseMap();
                CreateMap<DepartmentInfo, GetDepartmentInfoDto>().ReverseMap();
            

                //Update CommandDto Mapping 
                CreateMap<UpdateStaffDto, StaffPersonalInfo>()
                 .ForAllMembers(opts =>
                 {
                     opts.AllowNull();//Allow List type to be Null
                     opts.Condition((src, dest, srcMember) => srcMember != null);//Allow All Other Members Tobe Null
                 });
                CreateMap<UpdateStaffEducationDetailDto, StaffEducationDetail>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
                CreateMap<UpdateEmploymentDetailDto, StaffEmploymentDetail>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
                CreateMap<UpdateStaffEmploymentDetailDepartmentInfoDto, EmploymentDetailDepartment>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
