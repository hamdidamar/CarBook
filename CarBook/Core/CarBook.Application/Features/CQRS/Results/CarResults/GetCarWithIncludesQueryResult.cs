using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarResults;

public class GetCarWithIncludesQueryResult:BaseResult
{
    public Guid ColorId { get; set; }
    public Guid ModelId { get; set; }
    public string ColorName { get; set; }
    public string ModelName { get; set; }
    public string BrandName { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short Seat { get; set; }
    public short Luggage { get; set; }
    public string ImageUrl { get; set; }
    public string DetailImageUrl { get; set; }
}
