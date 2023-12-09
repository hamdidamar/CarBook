using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ContactCommands;

public class RemoveContactCommand
{
    public string Id { get; set; }

    public RemoveContactCommand(string id)
    {
        Id = id;
    }
}
