﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class CarFeature:BaseEntity
{
    public bool Available { get; set; }
    public string CarId { get; set; }
    public string FeatureId { get; set; }
    public virtual Car? Car { get; set; }
    public virtual Feature? Feature { get; set; }
}
