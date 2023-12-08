using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class CarPricing:BaseEntity
{
    public int CarId { get; set; }
    public int PricingId { get; set; }
    public virtual Car? Car { get; set; }
    public virtual Pricing? Pricing { get; set; }
}
