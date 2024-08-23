using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;

public class GetCarDescriptionsByCarIdQuery:IRequest<List<GetCarDescriptionsByCarIdQueryResult>>
{
    public string Id { get; set; }

    public GetCarDescriptionsByCarIdQuery(string id)
    {
        Id = id;
    }
}
