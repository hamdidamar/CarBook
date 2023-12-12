using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.FooterDtos;

public class GetAllFooterDto
{
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string id { get; set; }
    public bool isActive { get; set; }
    public bool isDeleted { get; set; }
    public DateTime createdDate { get; set; }
    public DateTime? updatedDate { get; set; }
}
