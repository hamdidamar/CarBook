using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpGet]
        [Route("GetCarDescriptionsByCarId/{id}")]
        public async Task<IActionResult> GetCarDescriptionsByCarId(string id)
        {
            var values = await _mediator.Send(new GetCarDescriptionsByCarIdQuery(id));
            return Ok(values);
        }


    }
}
