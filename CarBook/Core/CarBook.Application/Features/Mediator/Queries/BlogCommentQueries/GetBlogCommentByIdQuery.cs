using CarBook.Application.Features.Mediator.Results.BlogCommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlogCommentQueries;

public class GetBlogCommentByIdQuery : IRequest<GetBlogCommentByIdQueryResult>
{
    public string Id { get; set; }

    public GetBlogCommentByIdQuery(string id)
    {
        Id = id;
    }
}