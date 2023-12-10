using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands;

public class RemoveLocationCommand:IRequest
{
    public string Id { get; set; }

    public RemoveLocationCommand(string id)
    {
        Id = id;
    }
}
