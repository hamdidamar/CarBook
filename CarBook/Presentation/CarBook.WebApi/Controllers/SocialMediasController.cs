using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
