using CarBook.Application.Features.CQRS.Commands.ModelCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ModelHandlers;

public class RemoveModelCommandHandler
{
    private readonly IRepository<Model> _repository;

    public RemoveModelCommandHandler(IRepository<Model> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveModelCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.IsActive = false;
        value.IsDeleted = true;
        value.UpdatedDate = DateTime.Now;
        await _repository.RemoveAsync(value);
    }
}
