using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureCommand:BaseCreateCommand
    {
        public bool Available { get; set; }
        public string CarId { get; set; }
        public string FeatureId { get; set; }
    }
}
