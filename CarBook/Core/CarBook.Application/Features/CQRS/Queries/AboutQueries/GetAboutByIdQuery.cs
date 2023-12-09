using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public Guid Id { get; set; }

        public GetAboutByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
