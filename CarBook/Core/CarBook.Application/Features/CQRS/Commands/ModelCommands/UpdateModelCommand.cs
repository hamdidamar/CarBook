using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ModelCommands;

public class UpdateModelCommand:BaseUpdateCommand
{
    public string BrandId { get; set; }
    public string FuelId { get; set; }
    public string TransmissionId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
}
