using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithIncludesQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarWithIncludesQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarWithIncludesQueryResult>> Handle()
    {
        var values = _repository.GetListWithPredicateAndIncludes(
            predicate:x=>x.IsActive, 
            include:c => c.Include(c => c.Model).Include(c => c.Model.Brand).Include(c => c.Color)
            );

        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetCarWithIncludesQueryResult
        {
            Id = x.Id,
            ColorId = x.ColorId,
            ColorName = x.Color.Name,
            BrandName = x.Model.Brand.Name,
            ModelName = x.Model.Name,
            ModelPrice = x.Model.DailyPrice.ToString(),
            ModelId = x.ModelId,
            Kilometer = x.Kilometer,
            ModelYear = x.ModelYear,
            Plate = x.Plate,
            Seat = x.Seat,
            Luggage = x.Luggage,
            ImageUrl = x.ImageUrl,
            DetailImageUrl = x.DetailImageUrl,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).ToList();
    }
}
