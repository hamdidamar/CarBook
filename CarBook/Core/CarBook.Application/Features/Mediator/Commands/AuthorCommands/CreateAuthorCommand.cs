using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands;

public class CreateAuthorCommand:BaseCreateCommand
{
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public string Description { get; set; }
}
