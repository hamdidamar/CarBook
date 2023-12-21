using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AuthorDtos;

public class GetAuthorDto
{
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public string Description { get; set; }
    public string id { get; set; }
    public bool isActive { get; set; }
    public bool isDeleted { get; set; }
    public DateTime createdDate { get; set; }
    public DateTime? updatedDate { get; set; }
}
