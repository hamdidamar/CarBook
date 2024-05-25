using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarDtos
{
    public class UpdateCarDto
    {
        public string Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public string ColorId { get; set; }
        public string ModelId { get; set; }
        public int Kilometer { get; set; }
        public short ModelYear { get; set; }
        public string Plate { get; set; }
        public short Seat { get; set; }
        public short Luggage { get; set; }
        public string ImageUrl { get; set; } = "/img/car-empty.png";
        public string DetailImageUrl { get; set; } = "/img/car-empty.png";
    }
}
