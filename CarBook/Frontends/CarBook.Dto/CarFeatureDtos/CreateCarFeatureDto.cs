using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeatureDtos;

public class CreateCarFeatureDto
{
    public bool Available { get; set; }
    public string CarId { get; set; }
    public string FeatureId { get; set; }
}
