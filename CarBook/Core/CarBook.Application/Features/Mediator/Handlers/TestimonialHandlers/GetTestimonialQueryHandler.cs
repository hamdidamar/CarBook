using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
{
    private readonly IRepository<Testimonial> _repository;
    public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetTestimonialQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            Title = x.Title,
            Comment = x.Comment,
            ImgUrl = x.ImgUrl,
            CreatedDate = x.CreatedDate,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            UpdatedDate = x.UpdatedDate

        }).ToList();
    }
}
