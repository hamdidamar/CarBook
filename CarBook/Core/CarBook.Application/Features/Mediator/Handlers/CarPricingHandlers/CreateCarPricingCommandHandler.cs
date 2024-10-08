﻿using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class CreateCarPricingCommandHandler : IRequestHandler<CreateCarPricingCommand>
{
    private readonly IRepository<CarPricing> _repository;
    public CreateCarPricingCommandHandler(IRepository<CarPricing> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(
         new CarPricing
         {
             CarId = request.CarId,
             PricingId = request.PricingId,
             Amount = request.Amount,
             CreatedDate = request.CreatedDate,
             Id = request.Id,
             IsActive = request.IsActive,
             IsDeleted = request.IsDeleted
         });
    }
}
