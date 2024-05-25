using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok();
        }

    }
}
