﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands;

public class UpdateLocationCommand:BaseUpdateCommand
{
    public string Name { get; set; }
}
