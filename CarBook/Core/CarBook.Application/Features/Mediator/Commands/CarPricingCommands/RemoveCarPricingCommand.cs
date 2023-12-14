using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarPricingCommands;

public class RemoveCarPricingCommand : IRequest
{
    public string Id { get; set; }

    public RemoveCarPricingCommand(string id)
    {
        Id = id;
    }
}
