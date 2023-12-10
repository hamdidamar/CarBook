using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers;

public class CreateFooterCommandHandler:IRequestHandler<CreateFooterCommand>
{
    private readonly IRepository<Footer> _repository;
    public CreateFooterCommandHandler(IRepository<Footer> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateFooterCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(
         new Footer
         {
             Description = request.Description,
             Address = request.Address,
             Mail = request.Mail,
             Phone = request.Phone,
             CreatedDate = request.CreatedDate,
             Id = request.Id,
             IsActive = request.IsActive,
             IsDeleted = request.IsDeleted
         });
    }
}
