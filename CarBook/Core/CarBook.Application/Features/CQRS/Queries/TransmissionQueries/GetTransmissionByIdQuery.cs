using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.TransmissionQueries;

public class GetTransmissionByIdQuery
{
    public string Id { get; set; }

    public GetTransmissionByIdQuery(string id)
    {
        Id = id;
    }
}
