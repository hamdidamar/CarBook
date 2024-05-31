using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.SocialMediaDtos
{
    public class UpdateSocialMediaDto
    {
        public string Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
