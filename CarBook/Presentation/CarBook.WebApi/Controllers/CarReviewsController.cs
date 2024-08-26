using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Commands.CarReviewCommands;
using CarBook.Application.Features.Mediator.Queries.CarReviewQueries;
using CarBook.Application.Validators.CarReviewValidator;
using FluentValidation;
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


		[HttpPost]
		public async Task<IActionResult> Create(CreateCarReviewCommand command)
		{
			CreateCarReviewValidator validations = new CreateCarReviewValidator();
            var validationResult = validations.Validate(command);

			if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _mediator.Send(command);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateCarReviewCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}


	}
}
