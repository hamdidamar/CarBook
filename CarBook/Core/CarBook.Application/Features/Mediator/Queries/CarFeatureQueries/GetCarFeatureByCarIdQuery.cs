using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery:IRequest<GetCarFeatureByCarIdQueryResult>
    {
        public string Id { get; set; }

        public GetCarFeatureByCarIdQuery(string id)
        {
            Id = id;
        }
    }
}
