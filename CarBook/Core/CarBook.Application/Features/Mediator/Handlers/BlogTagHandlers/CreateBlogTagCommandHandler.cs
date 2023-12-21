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

public class CreateBlogTagCommandHandler : IRequestHandler<CreateBlogTagCommand>
{
    private readonly IRepository<BlogTag> _repository;
    public CreateBlogTagCommandHandler(IRepository<BlogTag> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateBlogTagCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(
         new BlogTag
         {
             Title = request.Title,
             BlogId = request.BlogId,
             CreatedDate = request.CreatedDate,
             Id = request.Id,
             IsActive = request.IsActive,
             IsDeleted = request.IsDeleted
         });
    }
}
