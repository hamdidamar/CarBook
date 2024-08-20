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

public class GetCarFeatureQueryHandler : IRequestHandler<GetCarFeatureQuery, List<GetCarFeatureQueryResult>>
{
    private readonly IRepository<CarFeature> _repository;
    public GetCarFeatureQueryHandler(IRepository<CarFeature> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarFeatureQueryResult>> Handle(GetCarFeatureQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetCarFeatureQueryResult
        {
            Id = x.Id,
            CarId = x.CarId,
            FeatureId = x.FeatureId,
            Available = x.Available,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).OrderBy(x => x.CreatedDate).ToList();
    }
}
