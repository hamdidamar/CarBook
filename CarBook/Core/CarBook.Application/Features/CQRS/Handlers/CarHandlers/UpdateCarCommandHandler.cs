using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public UpdateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.ColorId = command.ColorId;
        value.ModelId = command.ModelId;
        value.Kilometer = command.Kilometer;
        value.ModelYear = command.ModelYear;
        value.Plate = command.Plate;
        value.Seat = command.Seat;
        value.Luggage = command.Luggage;
        value.ImageUrl = command.ImageUrl;
        value.DetailImageUrl = command.DetailImageUrl;
        value.IsActive = command.IsActive;
        value.IsDeleted = command.IsDeleted;
        value.UpdatedDate = command.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
