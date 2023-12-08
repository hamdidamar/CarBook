using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class Color:BaseEntity
{
    public string Name { get; set; }
    public string? HexCode { get; set; }
    public string? RGB { get; set; }
    public List<Car> Cars { get; set; }
}
