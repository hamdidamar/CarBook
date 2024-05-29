using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.PricingDtos
{
    public class UpdatePricingDto
    {
        public string Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string Title { get; set; }
        public string Name { get; set; }
    }
}
