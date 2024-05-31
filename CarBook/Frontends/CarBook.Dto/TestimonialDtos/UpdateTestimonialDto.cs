using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public string Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImgUrl { get; set; }
    }
}
