﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommands;

public class CreateAboutCommand:BaseCreateCommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
}
