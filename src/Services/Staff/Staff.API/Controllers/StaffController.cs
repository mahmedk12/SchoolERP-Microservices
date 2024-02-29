using Azure;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Queries;
using Staff.Application.Features.Staff.Queries.GetSingleStaff;
using Staff.Domain.Common;
using Staff.Domain.Entities.Staff;
using System.Net;


namespace Staff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(Name = "CreateStaff")]
        [ProducesResponseType(typeof(ApiResponse<GetStaffDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StaffPersonalInfo>> CreateStaff([FromBody] CreateStaffCommand createStaffCommandDto)
        {
            var response = await _mediator.Send(createStaffCommandDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetStaffDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStaffDto>> GetStaff(int id)
        {

            var result = await _mediator.Send(new GetSingleStaffQuery(id));
            return Ok(result);
        }
    }
}
