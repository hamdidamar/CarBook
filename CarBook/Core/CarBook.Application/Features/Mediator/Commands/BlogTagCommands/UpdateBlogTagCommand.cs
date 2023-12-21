using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BlogTagCommands;

public class UpdateBlogTagCommand : BaseUpdateCommand
{
    public string Title { get; set; }
    public string BlogId { get; set; }
}
