using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands;

public class RemoveTestimonialCommand:IRequest
{
    public string Id { get; set; }

    public RemoveTestimonialCommand(string id)
    {
        Id = id;
    }
}
