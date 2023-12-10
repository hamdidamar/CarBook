﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.FooterResults;

public class GetFooterByIdQueryResult:BaseResult
{
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
}
