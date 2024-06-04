﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class Location:BaseEntity
{
    public string Name { get; set; }
    public List<RentACar> RentACars { get; set; }

}
