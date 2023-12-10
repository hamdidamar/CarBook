using CarBook.Application.Features.Mediator.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries;

public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
{
    public string Id { get; set; }

    public GetPricingByIdQuery(string id)
    {
        Id = id;
    }
}
