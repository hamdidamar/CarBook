using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ColorCommands;

public class CreateColorCommand:BaseCreateCommand
{
    public string Name { get; set; }
    public string? HexCode { get; set; }
    public string? RGB { get; set; }
}
