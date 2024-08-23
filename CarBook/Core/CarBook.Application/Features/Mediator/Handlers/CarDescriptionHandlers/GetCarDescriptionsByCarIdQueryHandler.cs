using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers;

public class GetCarDescriptionsByCarIdQueryHandler : IRequestHandler<GetCarDescriptionsByCarIdQuery, List<GetCarDescriptionsByCarIdQueryResult>>
{
    private readonly IRepository<CarDescription> _repository;
    public GetCarDescriptionsByCarIdQueryHandler(IRepository<CarDescription> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarDescriptionsByCarIdQueryResult>> Handle(GetCarDescriptionsByCarIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted && x.CarId == request.Id).Select(x => new GetCarDescriptionsByCarIdQueryResult
        {
            Id = x.Id,
            Details = x.Details,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).OrderBy(x => x.CreatedDate).ToList();
    }
}
