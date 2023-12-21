using CarBook.Application.Features.Mediator.Results.BlogTagResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlogTagQueries;

public class GetBlogTagQuery : IRequest<List<GetBlogTagQueryResult>>
{
}
