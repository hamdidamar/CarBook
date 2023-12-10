﻿using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IRepository<Location> _repository;
    public UpdateLocationCommandHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        value.IsActive = request.IsActive;
        value.IsDeleted = request.IsDeleted;
        value.UpdatedDate = request.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
