﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AboutDtos;

public class GetAllAboutDto:BaseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
   

}
