using CarBook.Application.Features.CQRS.Commands.TransmissionCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TransmissionHandlers;

public class RemoveTransmissionCommandHandler
{
    private readonly IRepository<Transmission> _repository;

    public RemoveTransmissionCommandHandler(IRepository<Transmission> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveTransmissionCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.IsActive = false;
        value.IsDeleted = true;
        value.UpdatedDate = DateTime.Now;
        await _repository.RemoveAsync(value);
    }
}
