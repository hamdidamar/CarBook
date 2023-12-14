using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarPricingCommands;

public class UpdateCarPricingCommand : BaseUpdateCommand
{
    public string CarId { get; set; }
    public string PricingId { get; set; }
    public decimal Amount { get; set; }
}
