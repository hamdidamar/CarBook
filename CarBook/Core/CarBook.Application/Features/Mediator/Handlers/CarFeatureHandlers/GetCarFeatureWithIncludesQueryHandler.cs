using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;

public class GetCarFeatureWithIncludesQueryHandler : IRequestHandler<GetCarFeatureWithIncludesQuery, List<GetCarFeatureWithIncludesQueryResult>>
{
    private readonly IRepository<CarFeature> _repository;

    public GetCarFeatureWithIncludesQueryHandler(IRepository<CarFeature> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarFeatureWithIncludesQueryResult>> Handle(GetCarFeatureWithIncludesQuery request, CancellationToken cancellationToken)
    {
        var values = _repository.GetListWithPredicateAndIncludes(
           predicate: x => x.IsActive && x.Feature.IsActive,
           include: c => c.Include(c => c.Feature)
           );

        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetCarFeatureWithIncludesQueryResult
        {
            Id = x.Id,
            FeatureId = x.FeatureId,
            FeatureName = x.Feature.Name,
            CarId = x.CarId,
            Available = x.Available,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).OrderBy(x => x.CreatedDate).ToList();
    }
}