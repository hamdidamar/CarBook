using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandsController(CreateBrandCommandHandler createCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok();
        }
    }
}
