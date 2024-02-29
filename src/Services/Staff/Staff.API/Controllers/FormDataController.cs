using MediatR;
using Microsoft.AspNetCore.Mvc;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Features.Staff.Queries.GetFormData;
using Staff.Application.Features.Staff.Queries.GetSingleStaff;
using Staff.Domain.Entities.Staff;
using System.Net;

namespace Staff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormDataController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetFormDataDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetFormDataDto>> GetFormData()
        {

            var result = await _mediator.Send(new GetFormDataQuery());
            return Ok(result);
        }
    }
}
