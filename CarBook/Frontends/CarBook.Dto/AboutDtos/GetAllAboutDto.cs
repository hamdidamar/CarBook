using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AboutDtos;

public class GetAllAboutDto
{
    public string title { get; set; }
    public string description { get; set; }
    public string imgUrl { get; set; }
    public string id { get; set; }
    public bool isActive { get; set; }
    public bool isDeleted { get; set; }
    public DateTime createdDate { get; set; }
    public DateTime? updatedDate { get; set; }

}
