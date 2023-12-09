using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands;

public class UpdateCategoryCommand:BaseUpdateCommand
{
    public string Name { get; set; }
}
