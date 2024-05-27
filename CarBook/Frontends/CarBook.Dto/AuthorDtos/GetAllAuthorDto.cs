using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AuthorDtos;

public class GetAllAuthorDto:BaseDto
{
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public string Description { get; set; }
    
}
