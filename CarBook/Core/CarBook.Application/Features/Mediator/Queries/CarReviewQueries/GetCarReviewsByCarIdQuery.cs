using CarBook.Application.Features.Mediator.Results.CarReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarReviewQueries;

public class GetCarReviewsByCarIdQuery : IRequest<List<GetCarReviewsByCarIdQueryResult>>
{
	public string Id { get; set; }

	public GetCarReviewsByCarIdQuery(string id)
	{
		Id = id;
	}
}
