using CarBook.Application.Features.CQRS.Commands.TransmissionCommands;
using CarBook.Application.Features.CQRS.Handlers.TransmissionHandlers;
using CarBook.Application.Features.CQRS.Queries.TransmissionQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : ControllerBase
    {
        private readonly CreateTransmissionCommandHandler _createCommandHandler;
        private readonly GetTransmissionByIdQueryHandler _getTransmissionByIdQueryHandler;
        private readonly GetTransmissionQueryHandler _getTransmissionQueryHandler;
        private readonly UpdateTransmissionCommandHandler _updateTransmissionCommandHandler;
        private readonly RemoveTransmissionCommandHandler _removeTransmissionCommandHandler;

        public TransmissionsController(CreateTransmissionCommandHandler createCommandHandler, GetTransmissionByIdQueryHandler getTransmissionByIdQueryHandler, GetTransmissionQueryHandler getTransmissionQueryHandler, UpdateTransmissionCommandHandler updateTransmissionCommandHandler, RemoveTransmissionCommandHandler removeTransmissionCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
            _getTransmissionByIdQueryHandler = getTransmissionByIdQueryHandler;
            _getTransmissionQueryHandler = getTransmissionQueryHandler;
            _updateTransmissionCommandHandler = updateTransmissionCommandHandler;
            _removeTransmissionCommandHandler = removeTransmissionCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _getTransmissionQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _getTransmissionByIdQueryHandler.Handle(new GetTransmissionByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransmissionCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _removeTransmissionCommandHandler.Handle(new RemoveTransmissionCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTransmissionCommand command)
        {
            await _updateTransmissionCommandHandler.Handle(command);
            return Ok();
        }
    }
}
