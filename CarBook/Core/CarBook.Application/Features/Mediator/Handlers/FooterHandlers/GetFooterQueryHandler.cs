using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Footers.Mediator.Handlers.FooterHandlers;

public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery, List<GetFooterQueryResult>>
{
    private readonly IRepository<Footer> _repository;
    public GetFooterQueryHandler(IRepository<Footer> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetFooterQueryResult>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetFooterQueryResult
        {
            Id = x.Id,
            Description = x.Description,
            Address = x.Address,
            Mail = x.Mail,
            Phone = x.Phone,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).OrderBy(x => x.CreatedDate).ToList();
    }
}
