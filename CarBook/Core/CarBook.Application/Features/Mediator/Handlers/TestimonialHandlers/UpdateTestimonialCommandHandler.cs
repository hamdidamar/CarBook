using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
{
    private readonly IRepository<Testimonial> _repository;
    public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        value.Title = request.Title;
        value.Comment = request.Comment;
        value.ImgUrl = request.ImgUrl;
        value.IsActive = request.IsActive;
        value.IsDeleted = request.IsDeleted;
        value.UpdatedDate = request.UpdatedDate;

        await _repository.UpdateAsync(value);
    }
}
