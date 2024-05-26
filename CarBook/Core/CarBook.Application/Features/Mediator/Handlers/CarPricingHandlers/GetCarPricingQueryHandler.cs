using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
{
    private readonly IRepository<CarPricing> _repository;
    public GetCarPricingQueryHandler(IRepository<CarPricing> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetCarPricingQueryResult
        {
            Id = x.Id,
            CarId = x.CarId,
            PricingId = x.PricingId,
            Amount = x.Amount,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).ToList();
    }
}

