using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ModelCommands;

public class RemoveModelCommand
{
    public Guid Id { get; set; }

    public RemoveModelCommand(Guid id)
    {
        Id = id;
    }
}
