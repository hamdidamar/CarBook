using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.TransmissionCommands;

public class UpdateTransmissionCommand:BaseUpdateCommand
{
    public string Name { get; set; }
}
