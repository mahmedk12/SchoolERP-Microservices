using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Features.Staff.Queries.GetFormData;
using Staff.Application.Features.Staff.Queries.GetSingleStaff;
using Staff.Application.Shared;
using Staff.Domain.Entities.Staff;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Staff.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [SwaggerTag("This is <b>Staff UI Form Related Data</b>")]
    public class FormDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormDataController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Form Related Data Succussfully Retrieved", Type = typeof(ApiResponse<GetFormDataDto>))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User is not authorized to access this url", Type = typeof(ApiResponse<>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Server has failed to read or execute data", Type = typeof(ApiResponse<>))]
        [Produces("application/json", "application/xml")]
        [Consumes("application/json", "application/xml")]
        [SwaggerOperation(
           Summary = "Get Constant Form Related Data",
           Description = "This function return dropdown information for related field such as Stafff Status ,Type, Position, DegreeLevel , Department Category & Thier Related Departmenents")]
        [HttpGet]
        public async Task<ActionResult<GetFormDataDto>> GetFormData()
        {

            var result = await _mediator.Send(new GetFormDataQuery());
            return StatusCode(result.StatusCode, result);
        }
    }
}
