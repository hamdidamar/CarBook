using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands;

public class UpdateBlogCommand:BaseUpdateCommand
{
    public string Title { get; set; }
    public string ImgUrl { get; set; }
    public string AuthorId { get; set; }
    public string CoverImgUrl { get; set; }
    public string CategoryId { get; set; }
}
