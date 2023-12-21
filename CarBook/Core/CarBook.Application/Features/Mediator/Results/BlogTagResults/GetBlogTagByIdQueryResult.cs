using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogTagResults;

public class GetBlogTagByIdQueryResult : BaseResult
{
    public string Title { get; set; }
    public string BlogId { get; set; }
}
