using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
{
    private readonly IRepository<Feature> _repository;
    public RemoveFeatureCommandHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.IsActive = false;
        value.IsDeleted = true;
        value.UpdatedDate = DateTime.Now;
        await _repository.RemoveAsync(value);
    }
}
