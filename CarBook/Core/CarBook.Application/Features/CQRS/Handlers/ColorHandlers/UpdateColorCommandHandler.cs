using CarBook.Application.Features.CQRS.Commands.ColorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ColorHandlers;

public class UpdateColorCommandHandler
{
    private readonly IRepository<Color> _repository;

    public UpdateColorCommandHandler(IRepository<Color> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateColorCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.Name = command.Name;
        value.HexCode = command.HexCode;
        value.RGB = command.RGB;
        value.IsActive = command.IsActive;
        value.IsDeleted = command.IsDeleted;
        value.UpdatedDate = command.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
