using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Weather.BLL.DTO
{
    class SearchHistoryDTO
    {
        public int Id { get; set; }
        public List<WeatherSummaryDTO> Results { get; set; }
        public List<CityDTO> CitiesPreset { get; set; }
    }
}
