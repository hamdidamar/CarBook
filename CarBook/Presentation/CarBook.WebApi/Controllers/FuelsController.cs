using CarBook.Application.Features.CQRS.Commands.FuelCommands;
using CarBook.Application.Features.CQRS.Handlers.FuelHandlers;
using CarBook.Application.Features.CQRS.Queries.FuelQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        private readonly CreateFuelCommandHandler _createCommandHandler;
        private readonly GetFuelByIdQueryHandler _getFuelByIdQueryHandler;
        private readonly GetFuelQueryHandler _getFuelQueryHandler;
        private readonly UpdateFuelCommandHandler _updateFuelCommandHandler;
        private readonly RemoveFuelCommandHandler _removeFuelCommandHandler;

        public FuelsController(CreateFuelCommandHandler createCommandHandler, GetFuelByIdQueryHandler getFuelByIdQueryHandler, GetFuelQueryHandler getFuelQueryHandler, UpdateFuelCommandHandler updateFuelCommandHandler, RemoveFuelCommandHandler removeFuelCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
            _getFuelByIdQueryHandler = getFuelByIdQueryHandler;
            _getFuelQueryHandler = getFuelQueryHandler;
            _updateFuelCommandHandler = updateFuelCommandHandler;
            _removeFuelCommandHandler = removeFuelCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _getFuelQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _getFuelByIdQueryHandler.Handle(new GetFuelByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFuelCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Remove(string id)
        {
            await _removeFuelCommandHandler.Handle(new RemoveFuelCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFuelCommand command)
        {
            await _updateFuelCommandHandler.Handle(command);
            return Ok();
        }
    }
}
