using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weather.Models
{
    public class SearchFormViewModel
    {
        [Required(ErrorMessage = "Enter city name")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Choose days")]
        [Range(1,16, ErrorMessage = "Days count should be from 1 to 16")]
        public int ResultCount { get; set; }
    }
}