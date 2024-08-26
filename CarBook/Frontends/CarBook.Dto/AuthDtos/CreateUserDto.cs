using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AuthDtos;

public class CreateUserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string RoleId { get; set; } = "3";
}
