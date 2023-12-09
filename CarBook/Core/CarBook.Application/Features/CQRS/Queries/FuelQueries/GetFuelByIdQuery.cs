using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.FuelQueries;

public class GetFuelByIdQuery
{

    public string Id { get; set; }

    public GetFuelByIdQuery(string id)
    {
        Id = id;
    }
}
