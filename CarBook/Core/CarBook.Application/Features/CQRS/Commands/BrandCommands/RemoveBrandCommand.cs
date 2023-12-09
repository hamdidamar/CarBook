using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommands;

public class RemoveBrandCommand
{
    public Guid Id { get; set; }

    public RemoveBrandCommand(Guid id)
    {
        Id = id;
    }
}
