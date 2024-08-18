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

public class CreateBlogCommentCommandHandler : IRequestHandler<CreateBlogCommentCommand>
{
    private readonly IRepository<BlogComment> _repository;
    public CreateBlogCommentCommandHandler(IRepository<BlogComment> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateBlogCommentCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(
         new BlogComment
         {
             Name = request.Name,
             Email = request.Email,
             Content = request.Content,
             BlogId = request.BlogId,
             CreatedDate = request.CreatedDate,
             Id = request.Id,
             IsActive = request.IsActive,
             IsDeleted = request.IsDeleted
         });
    }
}
