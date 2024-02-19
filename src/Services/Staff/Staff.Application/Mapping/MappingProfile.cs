using AutoMapper;
using Staff.Application.Features.Staff.Commands.CreateStaffPersonalInfo;
using Staff.Application.Features.Staff.Queries;
using Staff.Domain.Entities;

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
        }
    }
}
