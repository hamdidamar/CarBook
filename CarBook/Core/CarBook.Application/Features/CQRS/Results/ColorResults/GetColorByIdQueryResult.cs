using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.ColorResults;

public class GetColorByIdQueryResult:BaseResult
{
    public string Name { get; set; }
    public string? HexCode { get; set; }
    public string? RGB { get; set; }
}
