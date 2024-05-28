using CarBook.Application.Features.Mediator.Queries.BlogCommentQueries;
using CarBook.Application.Features.Mediator.Results.BlogCommentResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogCommentHandlers;

public class GetBlogCommentQueryHandler : IRequestHandler<GetBlogCommentQuery, List<GetBlogCommentQueryResult>>
{
    private readonly IRepository<BlogComment> _repository;
    public GetBlogCommentQueryHandler(IRepository<BlogComment> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBlogCommentQueryResult>> Handle(GetBlogCommentQuery request, CancellationToken cancellationToken)
    {
        var values = _repository.GetListWithPredicateAndIncludes(
          predicate: x => x.IsActive,
          include: c => c.Include(c => c.Blog)
          );
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetBlogCommentQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            Content = x.Content,
            BlogId = x.BlogId,
            BlogTitle = x.Blog.Title,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).OrderBy(x => x.CreatedDate).ToList();
    }
}
