﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.TransmissionResults;

public class GetTransmissionByIdQueryResult:BaseResult
{
    public string Name { get; set; }
}
