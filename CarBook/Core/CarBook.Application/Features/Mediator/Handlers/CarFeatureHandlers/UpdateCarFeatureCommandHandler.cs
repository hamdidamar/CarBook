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

public class UpdateCarFeatureCommandHandler : IRequestHandler<UpdateCarFeatureCommand>
{
    private readonly IRepository<CarFeature> _repository;
    public UpdateCarFeatureCommandHandler(IRepository<CarFeature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarFeatureCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.CarId = request.CarId;
        value.FeatureId = request.FeatureId;
        value.Available = request.Available;
        value.IsActive = request.IsActive;
        value.IsDeleted = request.IsDeleted;
        value.UpdatedDate = request.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
