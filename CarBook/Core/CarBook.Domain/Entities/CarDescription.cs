﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class CarDescription:BaseEntity
{
    public string Details { get; set; }
    public string CarId { get; set; }
    public virtual Car? Car { get; set; }
}
