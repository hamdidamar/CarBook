using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Commands.CarReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarReviewHandlers;

public class UpdateCarReviewCommandHandler : IRequestHandler<UpdateCarReviewCommand>
{
    private readonly IRepository<CarReview> _repository;
    public UpdateCarReviewCommandHandler(IRepository<CarReview> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarReviewCommand request, CancellationToken cancellationToken)
    {
		var value = await _repository.GetByIdAsync(request.Id);
		value.CarId = request.CarId;
		value.RatingValue = request.RatingValue;
		value.Comment = request.Comment;
		value.CustomerName = request.CustomerName;
		value.CustomerImg = request.CustomerImg;
		value.IsActive = request.IsActive;
		value.IsDeleted = request.IsDeleted;
		value.UpdatedDate = request.UpdatedDate;

		await _repository.UpdateAsync(value);
	}
}
