using CarBook.Application.Features.CQRS.Queries.FuelQueries;
using CarBook.Application.Features.CQRS.Results.FuelResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FuelHandlers;

public class GetFuelByIdQueryHandler
{
    private readonly IRepository<Fuel> _repository;

    public GetFuelByIdQueryHandler(IRepository<Fuel> repository)
    {
        _repository = repository;
    }

    public async Task<GetFuelByIdQueryResult> Handle(GetFuelByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return new GetFuelByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name,
            CreatedDate = value.CreatedDate,
            IsActive = value.IsActive,
            IsDeleted = value.IsDeleted,
            UpdatedDate = value.UpdatedDate

        };
    }
}
