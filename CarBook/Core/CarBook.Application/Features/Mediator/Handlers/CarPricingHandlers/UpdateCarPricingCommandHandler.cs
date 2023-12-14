using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class UpdateCarPricingCommandHandler : IRequestHandler<UpdateCarPricingCommand>
{
    private readonly IRepository<CarPricing> _repository;
    public UpdateCarPricingCommandHandler(IRepository<CarPricing> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.CarId = request.CarId;
        value.PricingId = request.PricingId;
        value.Amount = request.Amount;
        value.IsActive = request.IsActive;
        value.IsDeleted = request.IsDeleted;
        value.UpdatedDate = request.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}

