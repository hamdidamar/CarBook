using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BlogDtos;

public class GetAllBlogWithIncludesDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImgUrl { get; set; }
    public string AuthorId { get; set; }
    public string AuthorName { get; set; }
    public string AuthorImg { get; set; }
    public string AuthorDesc { get; set; }
    public string CoverImgUrl { get; set; }
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string id { get; set; }
    public bool isActive { get; set; }
    public bool isDeleted { get; set; }
    public DateTime createdDate { get; set; }
    public DateTime? updatedDate { get; set; }
}
