using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarDtos;

public class GetAllCarWithIncludesDto:BaseDto
{
    public string ColorId { get; set; }
    public string ModelId { get; set; }
    public string ColorName { get; set; }
    public string ModelName { get; set; }
    public string ModelPrice { get; set; }
    public string BrandName { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short Seat { get; set; }
    public short Luggage { get; set; }
    public string ImageUrl { get; set; }
    public string DetailImageUrl { get; set; }
}
