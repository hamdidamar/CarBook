using CarBook.Application.Features.CQRS.Queries.ColorQueries;
using CarBook.Application.Features.CQRS.Results.ColorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ColorHandlers;

public class GetColorByIdQueryHandler
{
    private readonly IRepository<Color> _repository;

    public GetColorByIdQueryHandler(IRepository<Color> repository)
    {
        _repository = repository;
    }

    public async Task<GetColorByIdQueryResult> Handle(GetColorByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return new GetColorByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name,
            HexCode = value.HexCode,
            RGB=value.RGB,
            CreatedDate = value.CreatedDate,
            IsActive = value.IsActive,
            IsDeleted = value.IsDeleted,
            UpdatedDate = value.UpdatedDate

        };
    }
}
