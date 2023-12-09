﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.ContactResults;

public class GetContactByIdQueryResult:BaseResult
{
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
