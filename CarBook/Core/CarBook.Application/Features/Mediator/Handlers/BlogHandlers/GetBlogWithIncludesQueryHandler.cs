using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogWithIncludesQueryHandler:IRequestHandler<GetBlogWithIncludesQuery,List<GetBlogWithIncludesQueryResult>>
{
    private readonly IRepository<Blog> _repository;

    public GetBlogWithIncludesQueryHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBlogWithIncludesQueryResult>> Handle(GetBlogWithIncludesQuery request, CancellationToken cancellationToken)
    {
        var values = _repository.GetListWithPredicateAndIncludes(
           predicate: x => x.IsActive,
           include: c => c.Include(c => c.Author).Include(c => c.Category)
           );

        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetBlogWithIncludesQueryResult
        {
            Id = x.Id,
            Title = x.Title,
            Content = x.Content,
            ImgUrl = x.ImgUrl,
            AuthorId = x.AuthorId,
            AuthorName = x.Author.Name,
            AuthorImg = x.Author.ImgUrl,
            AuthorDesc = x.Author.Description,
            CategoryId = x.CategoryId,
            CategoryName = x.Category.Name,
            CoverImgUrl = x.CoverImgUrl,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).OrderByDescending(x => x.CreatedDate).ToList();
    }
}
