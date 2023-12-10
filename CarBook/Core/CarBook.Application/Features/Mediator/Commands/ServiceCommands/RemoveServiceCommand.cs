using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands;

public class RemoveServiceCommand:IRequest
{
    public string Id { get; set; }

    public RemoveServiceCommand(string id)
    {
        Id = id;
    }
}
