using CarBook.Application.Features.Mediator.Queries.CarReviewQueries;
using CarBook.Application.Features.Mediator.Results.CarReviewResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarReviewHandlers;

public class GetCarReviewsByCarIdQueryHandler : IRequestHandler<GetCarReviewsByCarIdQuery, List<GetCarReviewsByCarIdQueryResult>>
{
	private readonly IRepository<CarReview> _repository;
	public GetCarReviewsByCarIdQueryHandler(IRepository<CarReview> repository)
	{
		_repository = repository;
	}

	public async Task<List<GetCarReviewsByCarIdQueryResult>> Handle(GetCarReviewsByCarIdQuery request, CancellationToken cancellationToken)
	{
		var values = await _repository.GetAllAsync();
		return values.Where(x => x.IsActive && !x.IsDeleted && x.CarId == request.Id).Select(x => new GetCarReviewsByCarIdQueryResult
		{
			Id = x.Id,
			CarId = x.CarId,
			Comment = x.Comment,
			CustomerImg = x.CustomerImg,
			CustomerName = x.CustomerName,
			RatingValue = x.RatingValue,
			CreatedDate = x.CreatedDate,
			IsActive = x.IsActive,
			IsDeleted = x.IsDeleted,
			UpdatedDate = x.UpdatedDate

		}).OrderBy(x => x.CreatedDate).ToList();
	}
}