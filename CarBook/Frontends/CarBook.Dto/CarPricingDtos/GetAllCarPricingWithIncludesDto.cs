using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarPricingDtos;

public class GetAllCarPricingWithIncludesDto
{
    public string PricingId { get; set; }
    public string CarId { get; set; }
    public string ColorId { get; set; }
    public string ModelId { get; set; }
    public string BrandId { get; set; }
    public string FuelId { get; set; }
    public string TransmissionId { get; set; }
    public string TransmissionName { get; set; }
    public string ModelImageUrl { get; set; }
    public string BrandName { get; set; }
    public string FuelName { get; set; }
    public string PricingName { get; set; }
    public string ModelName { get; set; }
    public string ColorName { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short Seat { get; set; }
    public short Luggage { get; set; }
    public string CarImageUrl { get; set; }
    public string DetailImageUrl { get; set; }
    public decimal DailyPrice { get; set; }
    public decimal WeeklyPrice { get; set; }
    public decimal MonthlyPrice { get; set; }
    public decimal Amount { get; set; }
    public string id { get; set; }
    public bool isActive { get; set; }
    public bool isDeleted { get; set; }
    public DateTime createdDate { get; set; }
    public DateTime? updatedDate { get; set; }
}
