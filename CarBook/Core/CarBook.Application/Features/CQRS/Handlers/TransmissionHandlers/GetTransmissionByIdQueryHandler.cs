using CarBook.Application.Features.CQRS.Queries.TransmissionQueries;
using CarBook.Application.Features.CQRS.Results.TransmissionResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TransmissionHandlers;

public class GetTransmissionByIdQueryHandler
{
    private readonly IRepository<Transmission> _repository;

    public GetTransmissionByIdQueryHandler(IRepository<Transmission> repository)
    {
        _repository = repository;
    }

    public async Task<GetTransmissionByIdQueryResult> Handle(GetTransmissionByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return new GetTransmissionByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name,
            CreatedDate = value.CreatedDate,
            IsActive = value.IsActive,
            IsDeleted = value.IsDeleted,
            UpdatedDate = value.UpdatedDate

        };
    }
}
