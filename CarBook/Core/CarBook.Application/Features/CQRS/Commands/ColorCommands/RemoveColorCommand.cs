using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ColorCommands;

public class RemoveColorCommand
{
    public Guid Id { get; set; }

    public RemoveColorCommand(Guid id)
    {
        Id = id;
    }
}
