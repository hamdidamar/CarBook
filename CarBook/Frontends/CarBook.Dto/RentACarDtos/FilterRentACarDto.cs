using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.RentACarDtos
{
    public class FilterRentACarDto
    {
        public string LocationId { get; set; }
        public bool Avaible { get; set; }=true;
    }
}
