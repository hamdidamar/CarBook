using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarCommands;

public class RemoveCarCommand
{
    public string Id { get; set; }

    public RemoveCarCommand(string id)
    {
        Id = id;
    }
}
