using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;

public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, GetCarFeatureByCarIdQueryResult>
{
    private readonly IRepository<CarFeature> _repository;
    public GetCarFeatureByCarIdQueryHandler(IRepository<CarFeature> repository)
    {
        _repository = repository;
    }

    public async Task<GetCarFeatureByCarIdQueryResult> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetCarFeatureByCarIdQueryResult
        {
            Id = value.Id,
            CarId = value.CarId,
            FeatureId = value.FeatureId,
            Available = value.Available,
            CreatedDate = value.CreatedDate,
            IsActive = value.IsActive,
            IsDeleted = value.IsDeleted,
            UpdatedDate = value.UpdatedDate

        };
    }
}