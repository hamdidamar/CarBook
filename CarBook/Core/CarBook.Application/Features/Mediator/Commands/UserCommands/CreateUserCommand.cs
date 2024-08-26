using CarBook.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.UserCommands;

public class CreateUserCommand:BaseCreateCommand
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
	public string Password { get; set; }
	public string? Email { get; set; }
	public string? Phone { get; set; }
	public string RoleId { get; set; } = RoleTypeEnum.Member.ToString();
}
