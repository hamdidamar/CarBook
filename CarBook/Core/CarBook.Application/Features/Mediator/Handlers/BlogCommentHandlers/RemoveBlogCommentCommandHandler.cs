using CarBook.Application.Features.Mediator.Commands.BlogCommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogCommentHandlers;

public class RemoveBlogCommentCommandHandler : IRequestHandler<RemoveBlogCommentCommand>
{
    private readonly IRepository<BlogComment> _repository;
    public RemoveBlogCommentCommandHandler(IRepository<BlogComment> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveBlogCommentCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.IsActive = false;
        value.IsDeleted = true;
        value.UpdatedDate = DateTime.Now;
        await _repository.RemoveAsync(value);
    }
}