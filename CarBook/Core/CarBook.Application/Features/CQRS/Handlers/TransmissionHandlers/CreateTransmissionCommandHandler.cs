using CarBook.Application.Features.CQRS.Commands.TransmissionCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TransmissionHandlers;

public class CreateTransmissionCommandHandler
{
    private readonly IRepository<Transmission> _repository;

    public CreateTransmissionCommandHandler(IRepository<Transmission> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateTransmissionCommand command)
    {
        await _repository.CreateAsync(
            new Transmission
            {
                Name = command.Name,
                CreatedDate = command.CreatedDate,
                Id = command.Id,
                IsActive = command.IsActive,
                IsDeleted = command.IsDeleted
            });
    }
}
