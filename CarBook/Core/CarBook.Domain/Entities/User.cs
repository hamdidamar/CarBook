using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class User:BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string RoleId { get; set; }
    public virtual Role Role { get; set; }
}
