using CarBook.Application.Features.CQRS.Commands.ColorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ColorHandlers;

public class CreateColorCommandHandler
{
    private readonly IRepository<Color> _repository;

    public CreateColorCommandHandler(IRepository<Color> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateColorCommand command)
    {
        await _repository.CreateAsync(
            new Color
            {
                Name = command.Name,
                HexCode = command.HexCode,
                RGB= command.RGB,
                CreatedDate = command.CreatedDate,
                Id = command.Id,
                IsActive = command.IsActive,
                IsDeleted = command.IsDeleted
            });
    }
}
