using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeatureDtos;

public class GetAllCarFeatureWithIncludesDto
{
    public bool Available { get; set; }
    public string CarId { get; set; }
    public string FeatureId { get; set; }
    public string FeatureName { get; set; }
    public string id { get; set; }
    public bool isActive { get; set; }
    public bool isDeleted { get; set; }
    public DateTime createdDate { get; set; }
    public DateTime? updatedDate { get; set; }
}
