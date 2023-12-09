using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.BannerQueries;

public class GetBannerByIdQuery
{
    public string Id { get; set; }

    public GetBannerByIdQuery(string id)
    {
        Id = id;
    }
}
