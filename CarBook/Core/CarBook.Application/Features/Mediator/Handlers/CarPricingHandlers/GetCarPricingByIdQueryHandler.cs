﻿using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
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

public class GetCarPricingByIdQueryHandler : IRequestHandler<GetCarPricingByIdQuery, GetCarPricingByIdQueryResult>
{
    private readonly IRepository<CarPricing> _repository;
    public GetCarPricingByIdQueryHandler(IRepository<CarPricing> repository)
    {
        _repository = repository;
    }

    public async Task<GetCarPricingByIdQueryResult> Handle(GetCarPricingByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetCarPricingByIdQueryResult
        {
            Id = value.Id,
            CarId = value.CarId,
            PricingId = value.PricingId,
            Amount = value.Amount,
            CreatedDate = value.CreatedDate,
            IsActive = value.IsActive,
            IsDeleted = value.IsDeleted,
            UpdatedDate = value.UpdatedDate

        };
    }
}
