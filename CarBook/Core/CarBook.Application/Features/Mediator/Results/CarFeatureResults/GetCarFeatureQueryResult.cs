using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarFeatureResults
{
    public class GetCarFeatureQueryResult : BaseResult
    {
        public bool Available { get; set; }
        public string CarId { get; set; }
        public string FeatureId { get; set; }
        public string FeatureName { get; set; }
    }
}
