using CarBook.Application.Features.CQRS.Results.TransmissionResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TransmissionHandlers;

public class GetTransmissionQueryHandler
{
    private readonly IRepository<Transmission> _repository;

    public GetTransmissionQueryHandler(IRepository<Transmission> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetTransmissionQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetTransmissionQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).ToList();
    }
}
