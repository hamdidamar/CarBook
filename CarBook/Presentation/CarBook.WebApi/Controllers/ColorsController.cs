using CarBook.Application.Features.CQRS.Commands.ColorCommands;
using CarBook.Application.Features.CQRS.Handlers.ColorHandlers;
using CarBook.Application.Features.CQRS.Queries.ColorQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly CreateColorCommandHandler _createCommandHandler;
        private readonly GetColorByIdQueryHandler _getColorByIdQueryHandler;
        private readonly GetColorQueryHandler _getColorQueryHandler;
        private readonly UpdateColorCommandHandler _updateColorCommandHandler;
        private readonly RemoveColorCommandHandler _removeColorCommandHandler;

        public ColorsController(CreateColorCommandHandler createCommandHandler, GetColorByIdQueryHandler getColorByIdQueryHandler, GetColorQueryHandler getColorQueryHandler, UpdateColorCommandHandler updateColorCommandHandler, RemoveColorCommandHandler removeColorCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
            _getColorByIdQueryHandler = getColorByIdQueryHandler;
            _getColorQueryHandler = getColorQueryHandler;
            _updateColorCommandHandler = updateColorCommandHandler;
            _removeColorCommandHandler = removeColorCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _getColorQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _getColorByIdQueryHandler.Handle(new GetColorByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateColorCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Remove(string id)
        {
            await _removeColorCommandHandler.Handle(new RemoveColorCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateColorCommand command)
        {
            await _updateColorCommandHandler.Handle(command);
            return Ok();
        }
    }
}
