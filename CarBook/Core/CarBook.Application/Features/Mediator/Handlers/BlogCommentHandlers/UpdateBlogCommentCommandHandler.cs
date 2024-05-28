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

public class UpdateBlogCommentCommandHandler : IRequestHandler<UpdateBlogCommentCommand>
{
    private readonly IRepository<BlogComment> _repository;
    public UpdateBlogCommentCommandHandler(IRepository<BlogComment> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBlogCommentCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        value.Content = request.Content;
        value.BlogId = request.BlogId;
        
        value.IsActive = request.IsActive;
        value.IsDeleted = request.IsDeleted;
        value.UpdatedDate = request.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
