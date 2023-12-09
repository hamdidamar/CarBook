using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands;

public class BaseUpdateCommand
{
    public BaseUpdateCommand()
    {
        IsActive = true;
        IsDeleted = false;
        UpdatedDate = DateTime.Now;
    }
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime UpdatedDate { get; set; }
}
