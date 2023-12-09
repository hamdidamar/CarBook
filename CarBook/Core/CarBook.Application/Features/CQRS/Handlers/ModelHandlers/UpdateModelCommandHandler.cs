using CarBook.Application.Features.CQRS.Commands.ModelCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ModelHandlers;

public class UpdateModelCommandHandler
{

    private readonly IRepository<Model> _repository;

    public UpdateModelCommandHandler(IRepository<Model> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateModelCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        value.BrandId = command.BrandId;
        value.FuelId = command.FuelId;
        value.TransmissionId = command.TransmissionId;
        value.Name = command.Name;
        value.DailyPrice = command.DailyPrice;
        value.ImageUrl = command.ImageUrl;
        value.IsActive = command.IsActive;
        value.IsDeleted = command.IsDeleted;
        value.UpdatedDate = command.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
