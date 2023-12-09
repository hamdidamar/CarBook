using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ModelQueries;

public class GetModelByIdQuery
{
    public Guid Id { get; set; }

    public GetModelByIdQuery(Guid id)
    {
        Id = id;
    }
}
