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

public class CreateCarReviewCommandHandler : IRequestHandler<CreateCarReviewCommand>
{
    private readonly IRepository<CarReview> _repository;
    public CreateCarReviewCommandHandler(IRepository<CarReview> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarReviewCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(
         new CarReview
		 {
             CarId = request.CarId,
             Comment = request.Comment,
             RatingValue = request.RatingValue,
             CustomerImg = request.CustomerImg, 
             CustomerName = request.CustomerName,
             CreatedDate = request.CreatedDate,
             Id = request.Id,
             IsActive = request.IsActive,
             IsDeleted = request.IsDeleted
         });
    }
}
