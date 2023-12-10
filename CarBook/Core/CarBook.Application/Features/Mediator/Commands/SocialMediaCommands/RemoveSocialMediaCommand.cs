﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;

public class RemoveSocialMediaCommand:IRequest
{
    public string Id { get; set; }

    public RemoveSocialMediaCommand(string id)
    {
        Id = id;
    }
}
