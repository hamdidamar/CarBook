using CarBook.Application.Features.CQRS.Results.ModelResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ModelHandlers;

public class GetModelQueryHandler
{
    private readonly IRepository<Model> _repository;

    public GetModelQueryHandler(IRepository<Model> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetModelQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetModelQueryResult
        {
            Id = x.Id,
            BrandId = x.BrandId,
            FuelId = x.FuelId,
            TransmissionId = x.TransmissionId,
            Name = x.Name,
            DailyPrice = x.DailyPrice,
            ImageUrl = x.ImageUrl,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).ToList();
    }
}
