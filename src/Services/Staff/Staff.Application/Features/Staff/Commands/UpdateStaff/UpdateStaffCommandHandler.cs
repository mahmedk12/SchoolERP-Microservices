using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Contracts.Infrastructure.Helper;
using Staff.Application.Contracts.Persistance.Constant;
using Staff.Application.Contracts.Persistance.Department;
using Staff.Application.Contracts.Persistance.Staff;
using Staff.Application.Exceptions;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Shared;
using Staff.Domain.Entities.Constant;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Junction;
using Staff.Domain.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, ApiResponse<object>>
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;


        public UpdateStaffCommandHandler(IStaffRepository staffRepository, IMapper mapper, IImageHelper imageHelper)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
            _imageHelper = imageHelper;
        }

        public async Task<ApiResponse<object>> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
        {
            //List<Expression<Func<StaffPersonalInfo, object>>> expressions = new List<Expression<Func<StaffPersonalInfo, object>>>();
            var StaffInfo = await _staffRepository.GetStaffInfoById(request.Id);

            if (StaffInfo==null)
                throw new CustomNotFoundException(nameof(StaffInfo),"Staff Not Notfound");
            
            var imageGuidId = Guid.NewGuid().ToString();           
            request.StaffDto.nicImage = 
            await _imageHelper.UpdateImage(StaffInfo.NicImage,request.StaffDto?.nicImageFile, nameof(StaffPersonalInfo), imageGuidId);
             
            request.StaffDto.passportImage = 
                await _imageHelper.UpdateImage(StaffInfo.PassportImage,request.StaffDto?.passportImageFile, nameof(StaffPersonalInfo), imageGuidId);
          
            if (request.StaffDto?.educationDetails!=null)
            {
                foreach (var educationDetailDto in request.StaffDto.educationDetails)
                {
                    var staffeducationDetail = StaffInfo?.EducationDetails?.FirstOrDefault(x => x.Id == educationDetailDto.Id);
                    if (staffeducationDetail!=null)
                    {
                        educationDetailDto.certificateImage = 
                        await _imageHelper.UpdateImage(staffeducationDetail.CertificateImage,educationDetailDto?.certificateImageFile, nameof(StaffEducationDetail), imageGuidId);                      
                        
                    }
                    else
                    {
                        educationDetailDto.certificateImage = 
                        await _imageHelper.UploadImage(educationDetailDto?.certificateImageFile, nameof(StaffEducationDetail), imageGuidId);                      
                        
                    }

                   
                }
            }

            _mapper.Map(request.StaffDto, StaffInfo);
            await _staffRepository.UpdateAsync(StaffInfo);
           
            var staffDto = _mapper.Map<GetStaffDto>(StaffInfo);
            var response = new ApiResponse<object>();
            response.Data = staffDto;
            response.StatusCode = 200;
            response.Message = "Staff Successfully Updated";
            return response;
        }

    }
}
