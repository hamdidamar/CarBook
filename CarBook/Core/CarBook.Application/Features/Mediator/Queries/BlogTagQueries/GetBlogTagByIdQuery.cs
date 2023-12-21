using CarBook.Application.Features.Mediator.Results.BlogTagResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlogTagQueries;

public class GetBlogTagByIdQuery : IRequest<GetBlogTagByIdQueryResult>
{
    public string Id { get; set; }

    public GetBlogTagByIdQuery(string id)
    {
        Id = id;
    }
}