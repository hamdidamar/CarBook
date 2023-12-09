using CarBook.Application.Features.CQRS.Queries.ModelQueries;
using CarBook.Application.Features.CQRS.Results.ModelResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ModelHandlers;

public class GetModelByIdQueryHandler
{
    private readonly IRepository<Model> _repository;

    public GetModelByIdQueryHandler(IRepository<Model> repository)
    {
        _repository = repository;
    }

    public async Task<GetModelByIdQueryResult> Handle(GetModelByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return new GetModelByIdQueryResult
        {
            Id = value.Id,
            BrandId = value.BrandId,
            FuelId = value.FuelId,
            TransmissionId = value.TransmissionId,
            Name = value.Name,
            DailyPrice = value.DailyPrice,
            ImageUrl = value.ImageUrl,
            CreatedDate = value.CreatedDate,
            IsActive = value.IsActive,
            IsDeleted = value.IsDeleted,
            UpdatedDate = value.UpdatedDate

        };
    }
}
