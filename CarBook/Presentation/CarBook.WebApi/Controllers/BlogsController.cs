using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetAllWithIncludes")]
        public async Task<IActionResult> GetAllWithIncludes()
        {
            var values = await _mediator.Send(new GetBlogWithIncludesQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetLastBlogsWithIncludes")]
        public async Task<IActionResult> GetLastBlogsWithIncludes()
        {
            var values = await _mediator.Send(new GetBlogWithIncludesQuery());
            return Ok(values.OrderByDescending(x => x.CreatedDate).Take(5).ToList());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
