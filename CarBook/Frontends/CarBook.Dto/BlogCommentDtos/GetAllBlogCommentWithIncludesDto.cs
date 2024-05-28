using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BlogCommentDtos;

public class GetAllBlogCommentWithIncludesDto:BaseDto
{
    public string Name { get; set; }
    public string Content { get; set; }
    public string BlogId { get; set; }
    public string BlogTitle { get; set; }
}
