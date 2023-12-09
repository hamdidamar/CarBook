using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands;

public class RemoveCategoryCommand
{
    public string Id { get; set; }

    public RemoveCategoryCommand(string id)
    {
        Id = id;
    }
}
