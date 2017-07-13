using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Models
{
    public class ForecastViewModel
    {
        public int Id { get; set; }
        public CityViewModel City { get; set; }
        public List<ForecastUnitViewModel> Units { get; set; }
    }
}