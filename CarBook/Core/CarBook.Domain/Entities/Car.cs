using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class Car:BaseEntity
{
    public string ColorId { get; set; }
    public string ModelId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short Seat { get; set; }
    public short Luggage { get; set; }
    public string ImageUrl { get; set; }
    public string DetailImageUrl { get; set; }
    public virtual Color? Color { get; set; }
    public virtual Model? Model { get; set; }
    public List<CarFeature> CarFeatures { get; set; }
    public List<CarDescription> CarDescriptions { get; set; }
    public List<CarPricing> CarPricings { get; set; }
}
