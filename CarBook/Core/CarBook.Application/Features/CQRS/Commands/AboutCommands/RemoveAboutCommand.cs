﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommands;

public class RemoveAboutCommand
{
    public string Id { get; set; }

    public RemoveAboutCommand(string id)
    {
        Id = id;
    }
}
