using CarBook.Application.Features.Mediator.Queries.CarReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpGet]
        [Route("GetCarReviewsByCarId/{id}")]
        public async Task<IActionResult> GetCarReviewsByCarId(string id)
        {
            var values = await _mediator.Send(new GetCarReviewsByCarIdQuery(id));
            return Ok(values);
        }


    }
}
