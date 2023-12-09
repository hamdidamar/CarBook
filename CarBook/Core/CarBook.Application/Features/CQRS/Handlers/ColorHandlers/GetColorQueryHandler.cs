using CarBook.Application.Features.CQRS.Results.ColorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ColorHandlers;

public class GetColorQueryHandler
{
    private readonly IRepository<Color> _repository;

    public GetColorQueryHandler(IRepository<Color> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetColorQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetColorQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            HexCode = x.HexCode,
            RGB= x.RGB,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).ToList();
    }
}
