using CarBook.Application.Features.CQRS.Commands.FuelCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FuelHandlers;

public class RemoveFuelCommandHandler
{
    private readonly IRepository<Fuel> _repository;

    public RemoveFuelCommandHandler(IRepository<Fuel> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveFuelCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.IsActive = false;
        value.IsDeleted = true;
        value.UpdatedDate = DateTime.Now;
        await _repository.RemoveAsync(value);
    }
}
