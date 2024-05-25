using CarBook.Application.Features.CQRS.Commands.ModelCommands;
using CarBook.Application.Features.CQRS.Handlers.ModelHandlers;
using CarBook.Application.Features.CQRS.Queries.ModelQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {

        private readonly CreateModelCommandHandler _createCommandHandler;
        private readonly GetModelByIdQueryHandler _getModelByIdQueryHandler;
        private readonly GetModelQueryHandler _getModelQueryHandler;
        private readonly UpdateModelCommandHandler _updateModelCommandHandler;
        private readonly RemoveModelCommandHandler _removeModelCommandHandler;

        public ModelsController(CreateModelCommandHandler createCommandHandler, GetModelByIdQueryHandler getModelByIdQueryHandler, GetModelQueryHandler getModelQueryHandler, UpdateModelCommandHandler updateModelCommandHandler, RemoveModelCommandHandler removeModelCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
            _getModelByIdQueryHandler = getModelByIdQueryHandler;
            _getModelQueryHandler = getModelQueryHandler;
            _updateModelCommandHandler = updateModelCommandHandler;
            _removeModelCommandHandler = removeModelCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _getModelQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _getModelByIdQueryHandler.Handle(new GetModelByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModelCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _removeModelCommandHandler.Handle(new RemoveModelCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateModelCommand command)
        {
            await _updateModelCommandHandler.Handle(command);
            return Ok();
        }
    }
}
