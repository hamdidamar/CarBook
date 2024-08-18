using CarBook.Application.Features.Mediator.Queries.BlogCommentQueries;
using CarBook.Application.Features.Mediator.Results.BlogCommentResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogCommentHandlers;

public class GetBlogCommentByIdQueryHandler : IRequestHandler<GetBlogCommentByIdQuery, GetBlogCommentByIdQueryResult>
{
    private readonly IRepository<BlogComment> _repository;
    public GetBlogCommentByIdQueryHandler(IRepository<BlogComment> repository)
    {
        _repository = repository;
    }

    public async Task<GetBlogCommentByIdQueryResult> Handle(GetBlogCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetBlogCommentByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name,
            Email = value.Email,
            Content = value.Content,
            BlogId = value.BlogId,
            CreatedDate = value.CreatedDate,
            IsActive = value.IsActive,
            IsDeleted = value.IsDeleted,
            UpdatedDate = value.UpdatedDate

        };
    }
}
