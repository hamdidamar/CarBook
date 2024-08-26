using CarBook.Application.Features.Mediator.Queries.UserQueries;
using CarBook.Application.Features.Mediator.Results.UserResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.UserHandlers;

public class GetCheckUserQueryHandler : IRequestHandler<GetCheckUserQuery, GetCheckUserQueryResult>
{
	private readonly IRepository<User> _userRepository;
	private readonly IRepository<Role> _roleRepository;

	public GetCheckUserQueryHandler(IRepository<User> userRepository, IRepository<Role> roleRepository)
	{
		_userRepository = userRepository;
		_roleRepository = roleRepository;
	}

	public async Task<GetCheckUserQueryResult> Handle(GetCheckUserQuery request, CancellationToken cancellationToken)
	{
		var result = new GetCheckUserQueryResult();
		var user = _userRepository.GetListWithPredicateAndIncludes(predicate:x=>x.Username == request.Username && x.Password == request.Password).FirstOrDefault();
		result.IsExist = user != null;

		if (result.IsExist) { 
			result.Id = user.Id;
			result.Username = user.Username;
			result.Role = _roleRepository.GetListWithPredicateAndIncludes(predicate:x=>x.Id == user.RoleId.ToString()).FirstOrDefault().Name;
		}
		return result;
	}
}
