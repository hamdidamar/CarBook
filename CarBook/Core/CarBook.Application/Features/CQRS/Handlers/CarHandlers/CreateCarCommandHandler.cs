using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public CreateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarCommand command)
    {
        await _repository.CreateAsync(
            new Car
            {
                ColorId = command.ColorId,
                ModelId = command.ModelId,
                Kilometer = command.Kilometer,
                ModelYear = command.ModelYear,
                Plate = command.Plate,
                Seat = command.Seat,
                Luggage = command.Luggage,
                ImageUrl = command.ImageUrl,
                DetailImageUrl = command.DetailImageUrl,
                CreatedDate = command.CreatedDate,
                Id = command.Id,
                IsActive = command.IsActive,
                IsDeleted = command.IsDeleted
            });
    }
}
