﻿using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
{
    private readonly IRepository<Blog> _repository;
    public GetBlogQueryHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetBlogQueryResult
        {
            Id = x.Id,
            Title = x.Title,
            Content = x.Content,
            ImgUrl = x.ImgUrl,
            AuthorId = x.AuthorId,
            CoverImgUrl = x.CoverImgUrl,
            CategoryId = x.CategoryId,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).OrderByDescending(x => x.CreatedDate).ToList();
    }
}
