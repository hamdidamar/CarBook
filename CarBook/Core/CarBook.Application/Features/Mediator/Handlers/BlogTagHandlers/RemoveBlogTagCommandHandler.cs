using CarBook.Application.Features.Mediator.Commands.BlogTagCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogTagHandlers;

public class RemoveBlogTagCommandHandler : IRequestHandler<RemoveBlogTagCommand>
{
    private readonly IRepository<BlogTag> _repository;
    public RemoveBlogTagCommandHandler(IRepository<BlogTag> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveBlogTagCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.IsActive = false;
        value.IsDeleted = true;
        value.UpdatedDate = DateTime.Now;
        await _repository.RemoveAsync(value);
    }
}