using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x=>x.IsActive && !x.IsDeleted).Select(x=> new GetAboutQueryResult
        {
            Id = x.Id,
            Title = x.Title,
            CreatedDate = x.CreatedDate,
            Description = x.Description,
            ImgUrl = x.ImgUrl,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate=x.UpdatedDate
            
        }).OrderBy(x => x.CreatedDate).ToList();
    }
}
