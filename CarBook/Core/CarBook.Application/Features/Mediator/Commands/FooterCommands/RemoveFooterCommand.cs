﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FooterCommands;

public class RemoveFooterCommand:IRequest
{
    public string Id { get; set; }

    public RemoveFooterCommand(string id)
    {
        Id = id;
    }
}
