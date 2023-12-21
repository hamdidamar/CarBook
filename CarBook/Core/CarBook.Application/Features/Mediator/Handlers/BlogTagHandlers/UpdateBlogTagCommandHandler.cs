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

public class UpdateBlogTagCommandHandler : IRequestHandler<UpdateBlogTagCommand>
{
    private readonly IRepository<BlogTag> _repository;
    public UpdateBlogTagCommandHandler(IRepository<BlogTag> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBlogTagCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Title = request.Title;
        value.BlogId = request.BlogId;
        
        value.IsActive = request.IsActive;
        value.IsDeleted = request.IsDeleted;
        value.UpdatedDate = request.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
