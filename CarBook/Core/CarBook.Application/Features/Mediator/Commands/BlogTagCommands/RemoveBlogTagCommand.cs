using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BlogTagCommands;

public class RemoveBlogTagCommand : IRequest
{
    public string Id { get; set; }

    public RemoveBlogTagCommand(string id)
    {
        Id = id;
    }
}
