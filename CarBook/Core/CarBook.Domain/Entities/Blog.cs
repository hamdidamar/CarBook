using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class Blog:BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImgUrl { get; set; }
    public string AuthorId { get; set; }
    public string CoverImgUrl { get; set; }
    public string CategoryId { get; set; }
    public virtual Author Author { get; set; }
    public virtual Category Category { get; set; }
    public List<BlogTag> BlogTags { get; set; }
}
