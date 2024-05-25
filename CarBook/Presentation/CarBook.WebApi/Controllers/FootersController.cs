using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FootersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetFooterQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _mediator.Send(new GetFooterByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _mediator.Send(new RemoveFooterCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
