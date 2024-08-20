using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;

public class CreateCarFeatureCommandHandler : IRequestHandler<CreateCarFeatureCommand>
{
    private readonly IRepository<CarFeature> _repository;
    public CreateCarFeatureCommandHandler(IRepository<CarFeature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarFeatureCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(
         new CarFeature
         {
             CarId = request.CarId,
             FeatureId = request.FeatureId,
             Available = request.Available,
             CreatedDate = request.CreatedDate,
             Id = request.Id,
             IsActive = request.IsActive,
             IsDeleted = request.IsDeleted
         });
    }
}
