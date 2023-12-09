using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class Model:BaseEntity
{

    public string BrandId { get; set; }
    public string FuelId { get; set; }
    public string TransmissionId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }

    public virtual Brand? Brand { get; set; }
    public virtual ICollection<Car> Cars { get; set; }
    public virtual Fuel? Fuel { get; set; }
    public virtual Transmission? Transmission { get; set; }


}
