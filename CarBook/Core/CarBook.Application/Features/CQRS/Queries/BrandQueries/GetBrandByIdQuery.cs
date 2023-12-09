using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.BrandQueries;

public class GetBrandByIdQuery
{
    public string Id { get; set; }

    public GetBrandByIdQuery(string id)
    {
        Id = id;
    }
}
