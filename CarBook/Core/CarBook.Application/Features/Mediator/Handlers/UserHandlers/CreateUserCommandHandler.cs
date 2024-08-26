using CarBook.Application.Features.Mediator.Commands.UserCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.UserHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
	private readonly IRepository<User> _repository;
	public CreateUserCommandHandler(IRepository<User> repository)
	{
		_repository = repository;
	}
	public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		await _repository.CreateAsync(
		 new User
		 {
			 Name = request.Name,
			 Surname = request.Surname,
			 Username = request.Username,
			 Email = request.Email,
			 Password = request.Password,
			 Phone = request.Phone,
			 RoleId = request.RoleId,
			 CreatedDate = request.CreatedDate,
			 Id = request.Id,
			 IsActive = request.IsActive,
			 IsDeleted = request.IsDeleted
		 });
	}
}
