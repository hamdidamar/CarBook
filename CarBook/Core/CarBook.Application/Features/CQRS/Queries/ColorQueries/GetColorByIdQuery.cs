using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ColorQueries;

public class GetColorByIdQuery
{
    public Guid Id { get; set; }

    public GetColorByIdQuery(Guid id)
    {
        Id = id;
    }
}
