﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands;

public class RemoveFeatureCommand:IRequest
{
    public string Id { get; set; }

    public RemoveFeatureCommand(string id)
    {
        Id = id;
    }
}
