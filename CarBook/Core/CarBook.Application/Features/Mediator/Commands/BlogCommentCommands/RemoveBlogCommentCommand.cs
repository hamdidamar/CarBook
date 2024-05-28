using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommentCommands;

public class RemoveBlogCommentCommand : IRequest
{
    public string Id { get; set; }

    public RemoveBlogCommentCommand(string id)
    {
        Id = id;
    }
}
