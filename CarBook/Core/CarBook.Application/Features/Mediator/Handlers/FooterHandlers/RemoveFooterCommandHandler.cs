using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Footers.Mediator.Handlers.FooterHandlers;

public class RemoveFooterCommandHandler : IRequestHandler<RemoveFooterCommand>
{
    private readonly IRepository<Footer> _repository;
    public RemoveFooterCommandHandler(IRepository<Footer> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveFooterCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.IsActive = false;
        value.IsDeleted = true;
        value.UpdatedDate = DateTime.Now;
        await _repository.RemoveAsync(value);
    }
}
