using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarDescriptionResults;

public class GetCarDescriptionsByCarIdQueryResult : BaseResult
{
    public string Details { get; set; }
}
