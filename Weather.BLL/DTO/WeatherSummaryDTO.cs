using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.BLL.DTO
{
    public class WeatherSummaryDTO
    {
        public int Id { get; set; }
        public CityDTO City { get; set; }
        public List<WeatherUnitDTO> Units { get; set; }
    }
}
