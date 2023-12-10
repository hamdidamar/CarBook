using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
{
    public string Id { get; set; }

    public GetSocialMediaByIdQuery(string id)
    {
        Id = id;
    }
}