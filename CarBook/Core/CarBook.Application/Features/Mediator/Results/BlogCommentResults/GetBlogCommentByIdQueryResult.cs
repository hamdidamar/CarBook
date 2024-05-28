using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogCommentResults;

public class GetBlogCommentByIdQueryResult : BaseResult
{
    public string Name { get; set; }
    public string Content { get; set; }
    public string BlogId { get; set; }
}
