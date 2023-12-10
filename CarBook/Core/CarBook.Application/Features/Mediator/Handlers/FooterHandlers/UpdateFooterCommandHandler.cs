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

public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand>
{
    private readonly IRepository<Footer> _repository;
    public UpdateFooterCommandHandler(IRepository<Footer> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Description = request.Description;
        value.Address = request.Address;
        value.Mail = request.Mail;
        value.Phone = request.Phone;
        value.IsActive = request.IsActive;
        value.IsDeleted = request.IsDeleted;
        value.UpdatedDate = request.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
