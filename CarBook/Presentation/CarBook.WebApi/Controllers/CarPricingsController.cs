using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetCarPricingQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetAllWithIncludes")]
        public async Task<IActionResult> GetAllWithIncludes()
        {
            var values = await _mediator.Send(new GetCarPricingWithIncludesQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetLastCarPricingsWithIncludes")]
        public async Task<IActionResult> GetLastCarPricingsWithIncludes()
        {
            var values = await _mediator.Send(new GetCarPricingWithIncludesQuery());
            return Ok(values.OrderByDescending(x => x.CreatedDate).Take(3).ToList());
        }



        [HttpGet("id")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _mediator.Send(new GetCarPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _mediator.Send(new RemoveCarPricingCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
