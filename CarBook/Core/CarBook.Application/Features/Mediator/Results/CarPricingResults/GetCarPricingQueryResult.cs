using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarPricingResults;

public class GetCarPricingQueryResult : BaseResult
{
    public string PricingId { get; set; }
    public string CarId { get; set; }
    public decimal Amount { get; set; }
}
