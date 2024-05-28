using CarBook.Application.Features.Mediator.Commands.BlogCommentCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Queries.BlogCommentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogCommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetBlogCommentQuery());
            return Ok(values);
        }


        [HttpGet]
        [Route("GetAllByBlogId/{id}")]
        public async Task<IActionResult> GetAllByBlogId(string id)
        {
            var values = await _mediator.Send(new GetBlogCommentQuery());
            return Ok(values.Where(x=>x.BlogId == id));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _mediator.Send(new GetBlogCommentByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _mediator.Send(new RemoveBlogCommentCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
