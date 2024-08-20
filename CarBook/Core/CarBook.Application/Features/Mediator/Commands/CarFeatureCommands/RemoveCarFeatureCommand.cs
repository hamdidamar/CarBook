using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class RemoveCarFeatureCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveCarFeatureCommand(string id)
        {
            Id = id;
        }
    }
}
