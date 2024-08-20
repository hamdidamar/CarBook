using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetCarFeatureQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetAllWithIncludes")]
        public async Task<IActionResult> GetAllWithIncludes()
        {
            var values = await _mediator.Send(new GetCarFeatureWithIncludesQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetCarFeaturesWithIncludesByCarId/{id}")]
        public async Task<IActionResult> GetLastCarFeaturesWithIncludes(string id)
        {
            var values = await _mediator.Send(new GetCarFeatureWithIncludesQuery());
            return Ok(values.Where(x=>x.CarId == id).ToList());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCarId(string id)
        {
            var value = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _mediator.Send(new RemoveCarFeatureCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
