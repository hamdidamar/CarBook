using CarBook.Application.Features.Mediator.Queries.BlogTagQueries;
using CarBook.Application.Features.Mediator.Results.BlogTagResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogTagHandlers;

public class GetBlogTagByIdQueryHandler : IRequestHandler<GetBlogTagByIdQuery, GetBlogTagByIdQueryResult>
{
    private readonly IRepository<BlogTag> _repository;
    public GetBlogTagByIdQueryHandler(IRepository<BlogTag> repository)
    {
        _repository = repository;
    }

    public async Task<GetBlogTagByIdQueryResult> Handle(GetBlogTagByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetBlogTagByIdQueryResult
        {
            Id = value.Id,
            Title = value.Title,
            BlogId = value.BlogId,
            CreatedDate = value.CreatedDate,
            IsActive = value.IsActive,
            IsDeleted = value.IsDeleted,
            UpdatedDate = value.UpdatedDate

        };
    }
}
