using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AuthDtos;

public class CreateLoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
