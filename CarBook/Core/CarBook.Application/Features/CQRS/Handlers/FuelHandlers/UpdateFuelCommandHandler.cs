using CarBook.Application.Features.CQRS.Commands.FuelCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FuelHandlers;

public class UpdateFuelCommandHandler
{
    private readonly IRepository<Fuel> _repository;

    public UpdateFuelCommandHandler(IRepository<Fuel> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateFuelCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.Name = command.Name;
        value.IsActive = command.IsActive;
        value.IsDeleted = command.IsDeleted;
        value.UpdatedDate = command.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
