﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.FuelResults;

public class GetFuelByIdQueryResult:BaseResult
{
    public string Name { get; set; }
}
