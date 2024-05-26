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

public class GetBlogTagQueryHandler : IRequestHandler<GetBlogTagQuery, List<GetBlogTagQueryResult>>
{
    private readonly IRepository<BlogTag> _repository;
    public GetBlogTagQueryHandler(IRepository<BlogTag> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBlogTagQueryResult>> Handle(GetBlogTagQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetBlogTagQueryResult
        {
            Id = x.Id,
            Title = x.Title,
            BlogId = x.BlogId,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).ToList();
    }
}
