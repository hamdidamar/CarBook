﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.ServiceResults;

public class GetServiceQueryResult:BaseResult
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}
