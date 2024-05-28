using CarBook.Application.Features.Mediator.Results.BlogCommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlogCommentQueries;

public class GetBlogCommentQuery : IRequest<List<GetBlogCommentQueryResult>>
{
}
