using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ModelQueries;

public class GetModelByIdQuery
{
    public string Id { get; set; }

    public GetModelByIdQuery(string id)
    {
        Id = id;
    }
}
