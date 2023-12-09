using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BannerCommands;

public class RemoveBannerCommand
{
    public Guid Id { get; set; }

    public RemoveBannerCommand(Guid id)
    {
        Id = id;
    }
}
