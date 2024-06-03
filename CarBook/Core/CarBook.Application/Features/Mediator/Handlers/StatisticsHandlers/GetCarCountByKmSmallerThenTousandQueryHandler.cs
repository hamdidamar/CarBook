using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByKmSmallerThenTousandQueryHandler : IRequestHandler<GetCarCountByKmSmallerThenTousandQuery, GetCarCountByKmSmallerThenTousandQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByKmSmallerThenTousandQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByKmSmallerThenTousandQueryResult> Handle(GetCarCountByKmSmallerThenTousandQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByKmSmallerThenTousand();
            return new GetCarCountByKmSmallerThenTousandQueryResult { Count = value };
        }
    }
}
