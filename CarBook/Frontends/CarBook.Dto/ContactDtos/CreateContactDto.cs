using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.ContactDtos;

public class CreateContactDto
{
    public CreateContactDto()
    {
        Id = Guid.NewGuid().ToString();
        IsActive = true;
        IsDeleted = false;
        CreatedDate = DateTime.Now;
    }

    public string Name { get; set; }
    public string Mail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }

    public string Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
}
