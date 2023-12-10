using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands;

public class RemovePricingCommand:IRequest
{
    public string Id { get; set; }

    public RemovePricingCommand(string id)
    {
        Id = id;
    }
}
