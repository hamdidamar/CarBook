using CarBook.Application.Features.CQRS.Commands.ColorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ColorHandlers;

public class RemoveColorCommandHandler
{
    private readonly IRepository<Color> _repository;

    public RemoveColorCommandHandler(IRepository<Color> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveColorCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.IsActive = false;
        value.IsDeleted = true;
        value.UpdatedDate = DateTime.Now;
        await _repository.RemoveAsync(value);
    }
}
