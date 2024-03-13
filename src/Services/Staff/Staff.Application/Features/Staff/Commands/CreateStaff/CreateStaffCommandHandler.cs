using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Contracts.Infrastructure.Helper;
using Staff.Application.Contracts.Persistance;
using Staff.Application.Contracts.Persistance.Constant;
using Staff.Application.Contracts.Persistance.Department;
using Staff.Application.Contracts.Persistance.Staff;
using Staff.Application.Exceptions;
using Staff.Application.Features.Staff.Queries;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Shared;
using Staff.Domain.Entities.Constant;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Staff;
using System.ComponentModel.DataAnnotations;

namespace Staff.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, ApiResponse<object>>
    {
        private readonly IStaffRepository _staffrepository;
        private readonly IImageHelper _imageHelper;
        private readonly IMapper _mapper;
        public CreateStaffCommandHandler(IStaffRepository staffRepository, IMapper mapper, IImageHelper imageHelper)
        {
            _staffrepository = staffRepository;
            _mapper = mapper;
            _imageHelper = imageHelper;
        }
        public async Task<ApiResponse<object>> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var imageGuidId = Guid.NewGuid().ToString();
            if (request.StaffDto?.nicImageFile != null)
                request.StaffDto.nicImage = await _imageHelper.UploadImage(request.StaffDto.nicImageFile, nameof(StaffPersonalInfo), imageGuidId);

            if (request.StaffDto?.passportImageFile != null)
                request.StaffDto.passportImage = await _imageHelper.UploadImage(request.StaffDto.passportImageFile, nameof(StaffPersonalInfo), imageGuidId);

            foreach (var educationDetail in request.StaffDto.educationDetails)
            {
                if (educationDetail.certificateImageFile!=null)
                    educationDetail.certificateImage= await _imageHelper.UploadImage(educationDetail.certificateImageFile, nameof(StaffEducationDetail), imageGuidId);
            }
            var staffinfo = _mapper.Map<StaffPersonalInfo>(request.StaffDto);
            var newstaffinfo = await _staffrepository.AddAsync(staffinfo);
            var staffDto=_mapper.Map<GetStaffDto>(newstaffinfo);
            var response = new ApiResponse<object>();
            response.Data = staffDto;
            response.StatusCode = 200;
            response.Message = "Staff Successfully Added";
            return response;
        }
    }
}
