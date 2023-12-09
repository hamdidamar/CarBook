using CarBook.Application.Features.CQRS.Commands.ModelCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ModelHandlers;

public class CreateModelCommandHandler
{
    private readonly IRepository<Model> _repository;

    public CreateModelCommandHandler(IRepository<Model> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateModelCommand command)
    {
        await _repository.CreateAsync(
            new Model
            {
                BrandId = command.BrandId,
                FuelId = command.FuelId,
                TransmissionId = command.TransmissionId,
                Name = command.Name,
                DailyPrice = command.DailyPrice,
                ImageUrl = command.ImageUrl,
                CreatedDate = command.CreatedDate
            });
    }
}
