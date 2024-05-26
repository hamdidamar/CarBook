using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class GetCarPricingWithIncludesQueryHandler : IRequestHandler<GetCarPricingWithIncludesQuery, List<GetCarPricingWithIncludesQueryResult>>
{
    private readonly IRepository<CarPricing> _repository;

    public GetCarPricingWithIncludesQueryHandler(IRepository<CarPricing> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarPricingWithIncludesQueryResult>> Handle(GetCarPricingWithIncludesQuery request, CancellationToken cancellationToken)
    {
        var values = _repository.GetListWithPredicateAndIncludes(
           predicate: x => x.IsActive && x.Pricing.IsActive,
           include: c => c.Include(c => c.Car)
           .Include(c => c.Car.Model)
           .Include(c => c.Car.Color)
           .Include(c => c.Car.Model.Brand)
           .Include(c => c.Car.Model.Fuel)
           .Include(c => c.Car.Model.Transmission)
           .Include(c => c.Pricing)
           );

        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetCarPricingWithIncludesQueryResult
        {
            Id = x.Id,
            PricingId = x.PricingId,
            CarId = x.CarId,
            ColorId = x.Car.ColorId,
            ModelId = x.Car.ModelId,
            BrandId = x.Car.Model.BrandId,
            FuelId = x.Car.Model.FuelId,
            TransmissionId = x.Car.Model.TransmissionId,
            TransmissionName = x.Car.Model.Transmission.Name,
            ModelImageUrl = x.Car.Model.ImageUrl,
            BrandName = x.Car.Model.Brand.Name,
            FuelName = x.Car.Model.Fuel.Name,
            PricingName =x.Pricing.Name,
            ModelName = x.Car.Model.Name,
            ColorName = x.Car.Color.Name,
            Kilometer = x.Car.Kilometer,
            ModelYear = x.Car.ModelYear,
            Plate = x.Car.Plate,
            Seat = x.Car.Seat,
            Luggage = x.Car.Luggage,
            CarImageUrl = x.Car.ImageUrl,
            DetailImageUrl = x.Car.DetailImageUrl,
            DailyPrice = x.Car.Model.DailyPrice,
            Amount = x.Amount,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).OrderBy(x => x.CreatedDate).ToList();
    }
}

