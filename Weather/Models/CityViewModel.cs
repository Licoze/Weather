﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Weather.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}