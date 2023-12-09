using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CategoryQueries;

public class GetCategoryByIdQuery
{
    public string Id { get; set; }

    public GetCategoryByIdQuery(string id)
    {
        Id = id;
    }
}
