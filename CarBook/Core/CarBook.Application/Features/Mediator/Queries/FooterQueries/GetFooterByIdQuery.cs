using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FooterQueries;

public class GetFooterByIdQuery : IRequest<GetFooterByIdQueryResult>
{
    public string Id { get; set; }

    public GetFooterByIdQuery(string id)
    {
        Id = id;
    }
}
