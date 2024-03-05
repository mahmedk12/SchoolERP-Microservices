using Asp.Versioning;
using Azure;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Commands.UpdateStaff;
using Staff.Application.Features.Staff.Queries;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Features.Staff.Queries.GetSingleStaff;
using Staff.Application.Shared;
using Staff.Domain.Common;
using Staff.Domain.Entities.Staff;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;


namespace Staff.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [SwaggerTag("This is <b>Staff Module Api Controller</b>")]
    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Staff Successfully Created", Type = typeof(ApiResponse<GetStaffDto>))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User is not authorized to access this url", Type = typeof(ApiResponse<>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Some required field is not found", Type = typeof(ApiResponse<>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Server has failed to read or execute data", Type = typeof(ApiResponse<>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request is Invalid", Type = typeof(ApiResponse<>))]
        [Produces("application/json", "application/xml")]
        [Consumes("application/json", "application/xml")]
        [SwaggerOperation(
           Summary = "Create Staff",
           Description = "This function takes staff personinfo, employment details and education details and create and return staff info")]
        [HttpPost(Name = "CreateStaff")]
        public async Task<ActionResult<StaffPersonalInfo>> CreateStaff([FromBody] CreateStaffCommand createStaffCommandDto)
        {
            var result = await _mediator.Send(createStaffCommandDto);
            return StatusCode(result.StatusCode, result);
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Staff Data Succuessfully Retrived", Type = typeof(ApiResponse<GetStaffDto>))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User is not authorized to access this url", Type = typeof(ApiResponse<>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Some required field is not found", Type = typeof(ApiResponse<>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Server has failed to read or execute data", Type = typeof(ApiResponse<>))]
        [Produces("application/json", "application/xml")]
        [Consumes("application/json", "application/xml")]
        [SwaggerOperation(
           Summary = "Get Single Staff Details",
           Description = "This function takes staff ID as parameter and returns staff details")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<GetStaffDto>>> GetStaff(int id)
        {

            var result = await _mediator.Send(new GetSingleStaffQuery(id));
            return StatusCode(result.StatusCode, result);
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Staff Successfully Updated", Type = typeof(ApiResponse<GetStaffDto>))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User is not authorized to access this url", Type = typeof(ApiResponse<>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Some required field is not found", Type = typeof(ApiResponse<>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Server has failed to read or execute data", Type = typeof(ApiResponse<>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request is Invalid", Type = typeof(ApiResponse<>))]
        [Produces("application/json", "application/xml")]
        [Consumes("application/json", "application/xml")]
        [SwaggerOperation(
           Summary = "Update Staff",
           Description = "This function takes staff personinfo, employment details and education details and update and return staff info")]
        [HttpPut(Name = "UpdateStaff")]
        [ProducesResponseType(typeof(GetStaffDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateStaff([FromBody] UpdateStaffCommand updateStaffCommandDto)
        {
            var result = await _mediator.Send(updateStaffCommandDto);
            return StatusCode(result.StatusCode, result);
        }
    }
}
