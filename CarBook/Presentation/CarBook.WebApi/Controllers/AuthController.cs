using CarBook.Application.Features.Mediator.Commands.UserCommands;
using CarBook.Application.Features.Mediator.Queries.UserQueries;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[HttpPost("Login")]
		public async Task<IActionResult> Login(GetCheckUserQuery query)
		{
			var values = await _mediator.Send(query);
			if (values.IsExist)
			{
				return Created("",JwtTokenGenarator.GenerateToken(values));
			}
			else
			{
				return BadRequest("Kullanıcı bilgileri hatalı");
			}	
		}

		[HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
		{
			await _mediator.Send(command);
			return Ok("Kullanıcı başarıyla oluşturuldu");
		}
	}
}
