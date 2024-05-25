using CarBook.Application.Features.Mediator.Commands.BlogTagCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Queries.BlogTagQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogTagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetBlogTagQuery());
            return Ok(values);
        }


        [HttpGet]
        [Route("GetAllByBlogId/{id}")]
        public async Task<IActionResult> GetAllByBlogId(string id)
        {
            var values = await _mediator.Send(new GetBlogTagQuery());
            return Ok(values.Where(x=>x.BlogId == id));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _mediator.Send(new GetBlogTagByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogTagCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _mediator.Send(new RemoveBlogTagCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogTagCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
