using CarBook.Application.Features.CQRS.Results.FuelResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FuelHandlers;

public class GetFuelQueryHandler
{
    private readonly IRepository<Fuel> _repository;

    public GetFuelQueryHandler(IRepository<Fuel> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetFuelQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetFuelQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).ToList();
    }
}
