using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BannerCommands;

public class RemoveBannerCommand
{
    public string Id { get; set; }

    public RemoveBannerCommand(string id)
    {
        Id = id;
    }
}
