using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ColorCommands;

public class RemoveColorCommand
{
    public string Id { get; set; }

    public RemoveColorCommand(string id)
    {
        Id = id;
    }
}
