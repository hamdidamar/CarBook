using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class BlogTag:BaseEntity
{
    public string Title { get; set; }
    public string BlogId { get; set; }
    public virtual Blog Blog { get; set; }
}
