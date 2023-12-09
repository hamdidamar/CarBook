using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommands;

public class RemoveBrandCommand
{
    public string Id { get; set; }

    public RemoveBrandCommand(string id)
    {
        Id = id;
    }
}
