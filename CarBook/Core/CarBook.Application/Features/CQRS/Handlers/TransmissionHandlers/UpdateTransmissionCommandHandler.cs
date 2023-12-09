using CarBook.Application.Features.CQRS.Commands.TransmissionCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TransmissionHandlers;

public class UpdateTransmissionCommandHandler
{
    private readonly IRepository<Transmission> _repository;

    public UpdateTransmissionCommandHandler(IRepository<Transmission> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateTransmissionCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.Name = command.Name;
        value.IsActive = command.IsActive;
        value.IsDeleted = command.IsDeleted;
        value.UpdatedDate = command.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
