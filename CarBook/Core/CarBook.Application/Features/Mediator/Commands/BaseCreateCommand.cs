﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands;

public class BaseCreateCommand:IRequest
{
    public BaseCreateCommand()
    {

        Id = Guid.NewGuid().ToString();
        IsActive = true;
        IsDeleted = false;
        CreatedDate = DateTime.Now;
    }
    public string Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
}
