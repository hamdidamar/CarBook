using CarBook.Application.Features.CQRS.Commands.FuelCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FuelHandlers;

public class CreateFuelCommandHandler
{
    private readonly IRepository<Fuel> _repository;

    public CreateFuelCommandHandler(IRepository<Fuel> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateFuelCommand command)
    {
        await _repository.CreateAsync(
            new Fuel
            {
                Name = command.Name,
                CreatedDate = command.CreatedDate,
                Id = command.Id,
                IsActive = command.IsActive,
                IsDeleted = command.IsDeleted
            });
    }
}
